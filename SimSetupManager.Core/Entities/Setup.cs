using System;

namespace SimSetupManager.Core.Entities

{
    public class Setup
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid TrackId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Title { get; set; } = string.Empty;

        public EnvironmentCondition Conditions { get; set; } = new();
        public SetupPayload Settings { get; set; } = new();
    }

    public class EnvironmentCondition
    {
        public string Weather { get; set; } = "Clear";
        public string TimeOfDay { get; set; } = "Noon";
        public double TrackTemp { get; set; }
        public double AirTemp { get; set; }
    }

    public class SetupPayload
    {
        public Dictionary<string, object> Suspension { get; set; } = new();
        public Dictionary<string, object> Tyres { get; set; } = new();
        public Dictionary<string, object> Aero { get; set; } = new();
    }
}