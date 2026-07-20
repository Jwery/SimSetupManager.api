using Microsoft.EntityFrameworkCore;
using SimSetupManager.Core.Entities;
using System.Text.Json;

namespace SimSetupManager.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Setup> Setups { get; set; }
        // Ajoute les DbSet pour Games, Tracks, Vehicles...

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