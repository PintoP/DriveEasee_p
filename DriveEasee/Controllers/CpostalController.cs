using DriveEasee.Models;
using DriveEasee.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriveEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpostalController : ControllerBase
    {
        private readonly DriveEaseContext _context;

        public CpostalController(DriveEaseContext context)
        {
            _context = context;
        }

        // GET: api/Cpostal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cpostal>>> GetCpostals()
        {
            return await _context.Cpostals.ToListAsync();
        }

        // GET: api/Cpostal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cpostal>> GetCpostal(int id)
        {
            var cpostal = await _context.Cpostals.FindAsync(id);

            if (cpostal == null)
            {
                return NotFound();
            }

            return cpostal;
        }

        // PUT: api/Cpostal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCpostal(int id, Cpostal cpostal)
        {
            if (id != cpostal.IdCpostal)
            {
                return BadRequest();
            }

            _context.Entry(cpostal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CpostalExists(id))
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

        // POST: api/Cpostal
        [HttpPost]
        public async Task<ActionResult<Cpostal>> PostCpostal(Cpostal cpostal)
        {
            _context.Cpostals.Add(cpostal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCpostal", new { id = cpostal.IdCpostal }, cpostal);
        }

        // DELETE: api/Cpostal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCpostal(int id)
        {
            var cpostal = await _context.Cpostals.FindAsync(id);
            if (cpostal == null)
            {
                return NotFound();
            }

            _context.Cpostals.Remove(cpostal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CpostalExists(int id)
        {
            return _context.Cpostals.Any(e => e.IdCpostal == id);
        }
    }
}
