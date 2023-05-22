using MediatR;
using MYUPDZ.Application.Common.Exceptions;
using MYUPDZ.Application.Common.Interfaces;
using System.Reflection;

namespace MYUPDZ.Application.Common.Behaviours;

public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IIdentityService _identityService;

    public AuthorizationBehaviour(ICurrentUserService currentUserService, IIdentityService identityService)
    {
        _currentUserService = currentUserService;
        _identityService = identityService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        IEnumerable<AuthorizeAttribute> authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        if (!authorizeAttributes.Any())
        {
            return await next();
        }

        // Must be authenticated user
        if (_currentUserService.UserId == null)
        {
            throw new UnauthorizedAccessException();
        }

        // Role-based authorization
        IEnumerable<AuthorizeAttribute> authorizeAttributesWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));
        if (authorizeAttributesWithRoles.Any())
        {
            bool authorized = false;

            foreach (string[] roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
            {
                foreach (string role in roles)
                {
                    bool isInRole = await _identityService.IsInRoleAsync(_currentUserService.UserId, role.Trim());
                    if (isInRole)
                    {
                        authorized = true;
                        break;
                    }
                }
            }

            // Must be a member of at least one role in roles
            if (!authorized)
            {
                throw new ForbiddenAccessException();
            }
        }

        // Policy-based authorization
        IEnumerable<AuthorizeAttribute> authorizeAttributesWithPolicies = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Policy));
        if (authorizeAttributesWithPolicies.Any())
        {
            foreach (string policy in authorizeAttributesWithPolicies.Select(a => a.Policy))
            {
                bool authorized = await _identityService.AuthorizeAsync(_currentUserService.UserId, policy);

                if (!authorized)
                {
                    throw new ForbiddenAccessException();
                }
            }
        }

        // User is authorized / authorization not required
        return await next();
    }
}
