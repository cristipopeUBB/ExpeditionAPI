using ExpeditionAPI.Enums;

namespace ExpeditionAPI.DTOs.Planets
{
    public class UpdatePlanetDTO
    {
        public PlanetStatus Status { get; set; }
        public string Description { get; set; } = default!;
    }
}
