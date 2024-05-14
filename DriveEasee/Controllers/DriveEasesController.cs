using DriveEasee.Models;
using DriveEasee.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriveEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriveEasesController : ControllerBase
    {
        private readonly DriveEaseContext _context;

        public DriveEasesController(DriveEaseContext context)
        {
            _context = context;
        }

        // GET: api/DriveEases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriveEases>>> GetDriveEases()
        {
            return await _context.DriveEases.ToListAsync();
        }

        // GET: api/DriveEases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DriveEases>> GetDriveEases(int id)
        {
            var driveEases = await _context.DriveEases.FindAsync(id);

            if (driveEases == null)
            {
                return NotFound();
            }

            return driveEases;
        }

        // PUT: api/DriveEases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriveEases(int id, DriveEases driveEases)
        {
            if (id != driveEases.IdDriveEase)
            {
                return BadRequest();
            }

            _context.Entry(driveEases).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriveEasesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DriveEases
        [HttpPost]
        public async Task<ActionResult<DriveEases>> PostDriveEases(DriveEases driveEases)
        {
            _context.DriveEases.Add(driveEases);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriveEases", new { id = driveEases.IdDriveEase }, driveEases);
        }

        // DELETE: api/DriveEases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriveEases(int id)
        {
            var driveEases = await _context.DriveEases.FindAsync(id);
            if (driveEases == null)
            {
                return NotFound();
            }

            _context.DriveEases.Remove(driveEases);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriveEasesExists(int id)
        {
            return _context.DriveEases.Any(e => e.IdDriveEase == id);
        }
    }
}
