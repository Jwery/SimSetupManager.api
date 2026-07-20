using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using SimSetupManager.Core.Entities;

namespace SimSetupManager.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Setup> Setups { get; set; }
        // Ajoute les DbSet pour Games, Tracks, Vehicles...

        public DbSet<Game> Games { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Setup>(entity =>
            {
                // 1. Définition de l'Owned Entity (aplatissement des conditions météo)
                entity.OwnsOne(s => s.Conditions, c =>
                {
                    c.Property(p => p.Weather).HasColumnName("Condition_Weather");
                    c.Property(p => p.TimeOfDay).HasColumnName("Condition_TimeOfDay");
                    c.Property(p => p.TrackTemp).HasColumnName("Condition_TrackTemp");
                    c.Property(p => p.AirTemp).HasColumnName("Condition_AirTemp");
                });

                // Initialisation des  données de références 

                modelBuilder.Entity<Game>().HasData(
                    new Game { Id = Guid.NewGuid(), Name = "Assetto Corsa" },
                    new Game { Id = Guid.NewGuid(), Name = "rFactor 2" },
                    new Game { Id = Guid.NewGuid(), Name = "Assetto Corsa Competizione" },
                    new Game { Id = Guid.NewGuid(), Name = "iRacing" },
                    new Game { Id = Guid.NewGuid(), Name = "Project CARS 2" },
                    new Game { Id = Guid.NewGuid(), Name = "F1 2026" },
                    new Game { Id = Guid.NewGuid(), Name = "Automobilista 2" },
                    new Game { Id = Guid.NewGuid(), Name = "RaceRoom Racing Experience" },
                    new Game { Id = Guid.NewGuid(), Name = "Dirt Rally 2.0" },
                    new Game { Id = Guid.NewGuid(), Name = "Gran Turismo 7" },
                    new Game { Id = Guid.NewGuid(), Name = "Forza Motorsport 7" },
                    new Game { Id = Guid.NewGuid(), Name = "Project CARS 3" },
                    new Game { Id = Guid.NewGuid(), Name = "F1 2025" },
                    new Game { Id = Guid.NewGuid(), Name = "Forza Horizon 6" }
                );

                // Initialisation des données de référence pour les pistes

                modelBuilder.Entity<Track>().HasData(
                    new Track { Id = Guid.NewGuid(), Name = "Nürburgring Nordschleife" },
                    new Track { Id = Guid.NewGuid(), Name = "Mount Panorama" },
                    new Track { Id = Guid.NewGuid(), Name = "Circuit de Spa-Francorchamps" },
                    new Track { Id = Guid.NewGuid(), Name = "Silverstone Circuit" },
                    new Track { Id = Guid.NewGuid(), Name = "Monza Circuit" },
                    new Track { Id = Guid.NewGuid(), Name = "Suzuka Circuit" },
                    new Track { Id = Guid.NewGuid(), Name = "Laguna Seca" },
                    new Track { Id = Guid.NewGuid(), Name = "Brands Hatch" }
                    );

                modelBuilder.Entity<Vehicle>().HasData(
                    new Vehicle { Id = Guid.NewGuid(), Name = "Ferrari 488 GT3" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Porsche 911 GT3 R" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Lamborghini Huracán GT3" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Audi R8 LMS" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Mercedes-AMG GT3" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "BMW M6 GT3" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "McLaren 720S GT3" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Aston Martin Vantage GT3" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Nissan GT-R Nismo GT3" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Chevrolet Corvette C8.R" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Ford GT GT3" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Toyota GR Supra GT4" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Alpine A110 GT4" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Honda NSX GT3" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Jaguar F-Type GT4" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "KTM X-Bow GT4" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Lotus Evora GT4" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Maserati MC20 GT4" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Subaru BRZ GT4" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Toyota GR86 GT4" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Volkswagen Golf GTI TCR" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Hyundai i30 N TCR" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Cupra Leon Competición" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Audi RS 3 LMS" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Honda Civic Type R TCR" },
                    new Vehicle { Id = Guid.NewGuid(), Name = "Lexus RC F GT3" }
                    );
          

                // 2. Le fameux mapping du Payload en JSON dans une colonne SQL
                entity.Property(s => s.Settings)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                        v => JsonSerializer.Deserialize<SetupPayload>(v, (JsonSerializerOptions)null!)!
                    )
                    .HasColumnType("nvarchar(max)"); // Assure que la colonne est assez grande
            });
        }
    }

}