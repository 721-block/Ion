using Ion.Domain.Common;

namespace Ion.Domain.Entities;

public class License : BaseEntity<int>
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}