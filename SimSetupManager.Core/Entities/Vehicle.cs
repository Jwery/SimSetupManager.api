using System;

namespace SimSetupManager.Core.Entities
{
    public class Vehicle
    {
        public Guid Id { get; set; }

        public Guid Brand { get; set; }
        public Guid Model { get; set; }
        public Guid Year { get; set; }
        public Guid Variante { get; set; }
    }
}