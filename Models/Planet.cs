using ExpeditionAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExpeditionAPI.Models
{
    public class Planet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string ImagePath { get; set; } = default!;
        public string Description { get; set; } = default!;
        public PlanetStatus Status { get; set; }
        public int NrRobots { get; set; }
    }
}
