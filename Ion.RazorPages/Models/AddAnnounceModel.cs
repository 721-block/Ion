using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.Car;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Models;

[IgnoreAntiforgeryToken]
public class AddAnnounceModel
{
    public AnnouncementToPost Announcement { get; set; } = new();
    public CarToPost Car { get; set; }
}
