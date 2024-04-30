namespace Ion.Server.RequestEntities.License;

public class LicenseToGet
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}