using Ion.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ion.Infrastructure;

public class CarRentContext : DbContext
{
    public CarRentContext(DbContextOptions<CarRentContext> contextOptions) : base(contextOptions)
    {
        Database.EnsureCreated();
    }

    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<License> Licenses { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<TripRecord> TripRecords { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Announcement>()
            .HasMany(a => a.Bookings)
            .WithOne(a => a.Announcement)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder
            .Entity<User>()
            .HasMany(u => u.UserBookings)
            .WithOne(b => b.Client)
            .OnDelete(DeleteBehavior.NoAction);
    }
}