using System.Text.Json;
using Ion.Domain.Entities;
using Ion.Domain.ValueObjects;
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
            .WithOne(b => b.Announcement)
            .OnDelete(DeleteBehavior.ClientCascade);
        
        modelBuilder
            .Entity<User>()
            .HasMany(u => u.UserBookings)
            .WithOne(b => b.Client)
            .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder
            .Entity<User>()
            .HasMany(u => u.SendedMessages)
            .WithOne(m => m.Sender)
            .OnDelete(DeleteBehavior.ClientCascade);
    
        modelBuilder
            .Entity<User>()
            .HasMany(u => u.RecievedMessages)
            .WithOne(m => m.Reciever)
            .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder
            .Entity<User>()
            .HasMany(u => u.Announcements)
            .WithOne(a => a.Author)
            .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder
            .Entity<User>()
            .HasMany(u => u.Reviews)
            .WithOne(r => r.User)
            .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder
            .Entity<User>()
            .HasMany(u => u.TripRecords)
            .WithOne(t => t.User)
            .OnDelete(DeleteBehavior.ClientCascade);
        
        modelBuilder
            .Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder
            .Entity<Announcement>()
            .Property(a => a.CarLocation)
            .HasConversion(c => JsonSerializer.Serialize(c, JsonSerializerOptions.Default), 
                c => JsonSerializer.Deserialize<Coordinate>(c, JsonSerializerOptions.Default));
    }
}