namespace Ion.Server.RequestEntities.License;

public class LicenseToPatch
{
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}