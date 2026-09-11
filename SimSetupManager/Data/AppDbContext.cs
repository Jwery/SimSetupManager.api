using Microsoft.EntityFrameworkCore;
using SimSetupManager.Core.Entities;
using System.Text.Json;
using System;

namespace SimSetupManager.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Setup> Setups { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Configuration exclusive de Setup
            modelBuilder.Entity<Setup>(entity =>
            {
                entity.Property(s => s.CreatedAt)
                      .HasDefaultValueSql("GETUTCDATE()");

                entity.OwnsOne(s => s.Conditions, c =>
                {
                    c.Property(p => p.Weather).HasColumnName("Condition_Weather");
                    c.Property(p => p.TimeOfDay).HasColumnName("Condition_TimeOfDay");
                    c.Property(p => p.TrackTemp).HasColumnName("Condition_TrackTemp");
                    c.Property(p => p.AirTemp).HasColumnName("Condition_AirTemp");
                });

                entity.Property(s => s.Settings)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                        v => JsonSerializer.Deserialize<SetupPayload>(v, (JsonSerializerOptions)null!)!
                    )
                    .HasColumnType("nvarchar(max)");
            });

            // 2. Data Seeding strict (en dehors de Setup)
            modelBuilder.Entity<Game>().HasData(
                new Game { Id = Guid.Parse("10000000-0000-0000-0000-000000000001"), Name = "Assetto Corsa" },
                new Game { Id = Guid.Parse("10000000-0000-0000-0000-000000000002"), Name = "rFactor 2" },
                new Game { Id = Guid.Parse("10000000-0000-0000-0000-000000000003"), Name = "Assetto Corsa Competizione" },
                new Game { Id = Guid.Parse("10000000-0000-0000-0000-000000000004"), Name = "iRacing" },
                new Game { Id = Guid.Parse("10000000-0000-0000-0000-000000000005"), Name = "Project CARS 2" },
                new Game { Id = Guid.Parse("10000000-0000-0000-0000-000000000006"), Name = "F1 2026" },
                new Game { Id = Guid.Parse("10000000-0000-0000-0000-000000000007"), Name = "Automobilista 2" },
                new Game { Id = Guid.Parse("10000000-0000-0000-0000-000000000008"), Name = "RaceRoom Racing Experience" },
                new Game { Id = Guid.Parse("10000000-0000-0000-0000-000000000009"), Name = "Dirt Rally 2.0" },
                new Game { Id = Guid.Parse("10000000-0000-0000-0000-000000000010"), Name = "Gran Turismo 7" },
                new Game { Id = Guid.Parse("10000000-0000-0000-0000-000000000011"), Name = "Forza Motorsport 7" },
                new Game { Id = Guid.Parse("10000000-0000-0000-0000-000000000012"), Name = "Project CARS 3" },
                new Game { Id = Guid.Parse("10000000-0000-0000-0000-000000000013"), Name = "F1 2025" },
                new Game { Id = Guid.Parse("10000000-0000-0000-0000-000000000014"), Name = "Forza Horizon 6" }
            );

            modelBuilder.Entity<Track>().HasData(
                new Track { Id = Guid.Parse("20000000-0000-0000-0000-000000000001"), Name = "Nürburgring Nordschleife" },
                new Track { Id = Guid.Parse("20000000-0000-0000-0000-000000000002"), Name = "Mount Panorama" },
                new Track { Id = Guid.Parse("20000000-0000-0000-0000-000000000003"), Name = "Circuit de Spa-Francorchamps" },
                new Track { Id = Guid.Parse("20000000-0000-0000-0000-000000000004"), Name = "Silverstone Circuit" },
                new Track { Id = Guid.Parse("20000000-0000-0000-0000-000000000005"), Name = "Monza Circuit" },
                new Track { Id = Guid.Parse("20000000-0000-0000-0000-000000000006"), Name = "Suzuka Circuit" },
                new Track { Id = Guid.Parse("20000000-0000-0000-0000-000000000007"), Name = "Laguna Seca" },
                new Track { Id = Guid.Parse("20000000-0000-0000-0000-000000000008"), Name = "Brands Hatch" }
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000001"), Brand = "Ferrari", Name = "488 GT3" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000002"), Brand = "Porsche", Name = "911 GT3 R" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000003"), Brand = "Lamborghini", Name = "Huracán GT3" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000004"), Brand = "Audi", Name = "R8 LMS" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000005"), Brand = "Mercedes-AMG", Name = "GT3" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000006"), Brand = "BMW", Name = "M6 GT3" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000007"), Brand = "McLaren", Name = "720S GT3" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000008"), Brand = "Aston Martin", Name = "Vantage GT3" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000009"), Brand = "Nissan", Name = "GT-R Nismo GT3" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000010"), Brand = "Chevrolet", Name = "Corvette C8.R" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000011"), Brand = "Ford", Name = "GT GT3" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000012"), Brand = "Toyota", Name = "GR Supra GT4" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000013"), Brand = "Alpine", Name = "A110 GT4" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000014"), Brand = "Honda", Name = "NSX GT3" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000015"), Brand = "Jaguar", Name = "F-Type GT4" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000016"), Brand = "KTM", Name = "X-Bow GT4" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000017"), Brand = "Lotus", Name = "Evora GT4" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000018"), Brand = "Maserati", Name = "MC20 GT4" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000019"), Brand = "Subaru", Name = "BRZ GT4" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000020"), Brand = "Toyota", Name = "GR86 GT4" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000021"), Brand = "Volkswagen", Name = "Golf GTI TCR" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000022"), Brand = "Hyundai", Name = "i30 N TCR" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000023"), Brand = "Cupra", Name = "Leon Competición" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000024"), Brand = "Audi", Name = "RS 3 LMS" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000025"), Brand = "Honda", Name = "Civic Type R TCR" },
                new Vehicle { Id = Guid.Parse("30000000-0000-0000-0000-000000000026"), Brand = "Lexus", Name = "RC F GT3" }
            );
        }
    }
}