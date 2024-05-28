using Ion.Domain.Common;

namespace Ion.Domain.Entities;

public class License : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}