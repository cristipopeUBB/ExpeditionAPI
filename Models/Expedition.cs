﻿using System.ComponentModel.DataAnnotations;

namespace ExpeditionAPI.Models
{
    public class Expedition
    {
        [Key]
        public int Id { get; set; }
        public int IdCaptain { get; set; }
        public int IdPlanet { get; set; }
        public int IdShuttle { get; set; }
        public DateTime? DepartureDate { get; set; }
    }
}