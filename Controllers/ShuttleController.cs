using ExpeditionAPI.Contexts;
using ExpeditionAPI.DTOs.Shuttles;
using ExpeditionAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpeditionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShuttleController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ShuttleController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _dbContext.Shuttles.ToListAsync());
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateShuttleDTO shuttle)
        {
            //create shuttle
            try
            {
                var shuttleToAdd = new Shuttle
                {
                    Name = shuttle.Name,
                };

                await _dbContext.Shuttles.AddAsync(shuttleToAdd);
                await _dbContext.SaveChangesAsync();

                return Ok(shuttle);
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
            //delete shuttle
            try
            {
                var shuttle = await _dbContext.Shuttles.FindAsync(id);
                if (shuttle == null)
                {
                    return NotFound("Cannot find shuttle with id" + id.ToString());
                }

                _dbContext.Shuttles.Remove(shuttle);
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
