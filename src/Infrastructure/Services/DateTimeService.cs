using nfc_pos.Application.Common.Interfaces;

namespace nfc_pos.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
