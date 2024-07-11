using ExpeditionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpeditionAPI.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Expedition> Expeditions { get; set; }
        public DbSet<Human> Humans { get; set; }
        public DbSet<Robot> Robots { get; set; }
        public DbSet<Shuttle> Shuttles { get; set; }
        public DbSet<Planet> Planets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expedition>().ToTable("Expeditions");
            modelBuilder.Entity<Human>().ToTable("Humans");
            modelBuilder.Entity<Robot>().ToTable("Robots");
            modelBuilder.Entity<Shuttle>().ToTable("Shuttles");
            modelBuilder.Entity<Planet>().ToTable("Planets");
        }
    }
}
