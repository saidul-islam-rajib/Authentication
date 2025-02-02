using Authentication.Application.Common.Interfaces.Services;

namespace Authentication.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
