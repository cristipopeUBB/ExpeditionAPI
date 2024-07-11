using System.ComponentModel.DataAnnotations;

namespace ExpeditionAPI.Models
{
    public class Human
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
