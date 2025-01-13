using Hotel.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Reservation>()
            .HasQueryFilter(r => r.DeletedAt == null);
        
        modelBuilder.Entity<Room>()
            .HasQueryFilter(r => r.DeletedAt == null);

        modelBuilder.Entity<Room>()
            .Property(r => r.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        modelBuilder.Entity<Room>()
            .Property(r => r.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        modelBuilder.Entity<Reservation>()
            .Property(r => r.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        modelBuilder.Entity<Reservation>()
            .Property(r => r.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        modelBuilder.Entity<Room>()
            .Property(r => r.UpdatedAt)
            .ValueGeneratedOnUpdate();

        modelBuilder.Entity<Reservation>()
            .Property(r => r.UpdatedAt)
            .ValueGeneratedOnUpdate();

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Room)
            .WithMany(r => r.Reservations)
            .HasForeignKey(r => r.RoomId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Room>()
            .HasMany(r => r.Reservations)
            .WithOne(r => r.Room);
    }
}