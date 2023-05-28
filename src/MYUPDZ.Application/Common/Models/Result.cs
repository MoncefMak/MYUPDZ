namespace MYUPDZ.Application.Common.Models;

public class Result
{

    internal Result(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }

    internal Result(bool succeeded, string errors)
    {
        Succeeded = succeeded;
        Error = errors;
    }

    public Result(bool succeeded, string errors, string token)
    {
        Succeeded = succeeded;
        Token = token;
    }

    public bool Succeeded { get; set; }

    public string[] Errors { get; set; }

    public string Error { get; set; }

    public string Token { get; set; }

    public static Result Success()
    {
        return new Result(true, Array.Empty<string>());
    }

    public static Result Success(string userId, string token)
    {
        return new Result(true, userId, token);
    }

    public static Result Failure(IEnumerable<string> errors)
    {
        return new Result(false, errors);
    }

    public static Result Failure(string error)
    {
        return new Result(false, error);
    }


}
