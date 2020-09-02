using System;

namespace ExampleProject.Database.Models
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Registration { get; set; }
        public int EngineSize { get; set; }
    }
}