using ExpeditionAPI.Contexts;
using ExpeditionAPI.DTOs.Planets;
using ExpeditionAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpeditionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public PlanetController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _dbContext.Planets.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var planet = await _dbContext.Planets.FindAsync(id);
            if (planet == null)
            {
                return NotFound("Cannot find planet with id" + id.ToString());
            }

            return Ok(planet);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePlanetDTO planet)
        {
            //create planet
            try
            {
                var planetToAdd = new Planet
                {
                    Name = planet.Name,
                    ImagePath = planet.ImagePath,
                    Description = planet.Description,
                    Status = planet.Status,
                    NrRobots = planet.NrRobots,
                };

                await _dbContext.Planets.AddAsync(planetToAdd);
                await _dbContext.SaveChangesAsync();

                return Ok(planet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdatePlanetDTO planetDto)
        {
            //update planet's description & status
            try
            {
                var existingPlanet = await _dbContext.Planets.FindAsync(id);
                if (existingPlanet == null)
                {
                    return NotFound("Cannot find planet with id" + id.ToString());
                }

                existingPlanet.Description = planetDto.Description;
                existingPlanet.Status = planetDto.Status;

                await _dbContext.SaveChangesAsync();

                return Ok(existingPlanet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            //delete planet
            try
            {
                var planet = await _dbContext.Planets.FindAsync(id);
                if (planet == null)
                {
                    return NotFound("Cannot find planet with id" + id.ToString());
                }

                _dbContext.Planets.Remove(planet);
                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
