using MYUPDZ.Application.Common.Interfaces;

namespace MYUPDZ.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}
