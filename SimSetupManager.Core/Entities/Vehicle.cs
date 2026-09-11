using System;

namespace SimSetupManager.Core.Entities
{
    public class Vehicle
    {
        public required Guid Id { get; set; }
        public required String Brand { get; set; }
        public required String Name { get; set; }
        public String? Year { get; set; }
        public String? Variante { get; set; }
    }
}