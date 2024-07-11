using ExpeditionAPI.Contexts;
using ExpeditionAPI.DTOs.Expeditions;
using ExpeditionAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpeditionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpeditionController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ExpeditionController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _dbContext.Expeditions.ToListAsync());
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateExpeditionDTO expedition)
        {
            //create expedition
            try
            {
                var expeditionToAdd = new Expedition
                {
                    IdCaptain = expedition.IdCaptain,
                    IdPlanet = expedition.IdPlanet,
                    IdShuttle = expedition.IdShuttle,
                    DepartureDate = expedition.DepartureDate,
                };

                await _dbContext.Expeditions.AddAsync(expeditionToAdd);
                await _dbContext.SaveChangesAsync();

                return Ok(expedition);
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
            //delete expedition
            try
            {
                var expedition = await _dbContext.Expeditions.FindAsync(id);
                if (expedition == null)
                {
                    return NotFound("Cannot find expedition with id" + id.ToString());
                }

                _dbContext.Expeditions.Remove(expedition);
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
