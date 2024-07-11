using System.ComponentModel.DataAnnotations;

namespace ExpeditionAPI.Models
{
    public class Robot
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int ExpeditionId { get; set; }
    }
}
