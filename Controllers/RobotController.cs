using ExpeditionAPI.Contexts;
using ExpeditionAPI.DTOs.Robots;
using ExpeditionAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpeditionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public RobotController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _dbContext.Robots.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Robot>>> GetRobotByExpeditionIdAsync([FromRoute] int id)
        {
            var robots = await _dbContext.Robots.Where(r => r.ExpeditionId == id).ToListAsync();

            return Ok(robots);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRobotDTO robot)
        {
            //create robot
            try
            {
                var robotToAdd = new Robot
                {
                    Name = robot.Name,
                    ExpeditionId = robot.ExpeditionId,
                };

                await _dbContext.Robots.AddAsync(robotToAdd);
                await _dbContext.SaveChangesAsync();

                return Ok(robot);
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
            //delete robot
            try
            {
                var robot = await _dbContext.Robots.FindAsync(id);
                if (robot == null)
                {
                    return NotFound("Cannot find robot with id" + id.ToString());
                }

                _dbContext.Robots.Remove(robot);
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
