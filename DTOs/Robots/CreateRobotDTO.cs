namespace ExpeditionAPI.DTOs.Robots
{
    public class CreateRobotDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int ExpeditionId { get; set; }
    }
}
