using ExpeditionAPI.Enums;

namespace ExpeditionAPI.DTOs.Planets
{
    public class CreatePlanetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string ImagePath { get; set; } = default!;
        public string Description { get; set; } = default!;
        public PlanetStatus Status { get; set; }
        public int NrRobots { get; set; }
    }
}
