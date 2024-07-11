using ExpeditionAPI.Contexts;
using ExpeditionAPI.DTOs.Captains;
using ExpeditionAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpeditionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public HumanController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _dbContext.Humans.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            var human = await _dbContext.Humans.FindAsync(id);
            if (human == null)
            {
                return Ok(new { name = string.Empty});
            }

            return Ok(new { name = human.Name });
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCaptainDTO human)
        {
            //create human
            try
            {
                var humanToAdd = new Human
                {
                    Name = human.Name,
                };

                await _dbContext.Humans.AddAsync(humanToAdd);
                await _dbContext.SaveChangesAsync();

                return Ok(human);
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
            //delete human
            try
            {
                var human = await _dbContext.Humans.FindAsync(id);
                if (human == null)
                {
                    return NotFound("Cannot find human with id" + id.ToString());
                }

                _dbContext.Humans.Remove(human);
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
