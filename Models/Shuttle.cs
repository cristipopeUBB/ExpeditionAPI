using System.ComponentModel.DataAnnotations;

namespace ExpeditionAPI.Models
{
    public class Shuttle
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
