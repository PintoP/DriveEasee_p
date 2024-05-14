using DriveEasee.Models;
using DriveEasee.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriveEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaController : ControllerBase
    {
        private readonly DriveEaseContext _context;

        public FaturaController(DriveEaseContext context)
        {
            _context = context;
        }

        // GET: api/Fatura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fatura>>> GetFaturas()
        {
            return await _context.Faturas.ToListAsync();
        }

        // GET: api/Fatura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fatura>> GetFatura(int id)
        {
            var fatura = await _context.Faturas.FindAsync(id);

            if (fatura == null)
            {
                return NotFound();
            }

            return fatura;
        }

        // PUT: api/Fatura/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFatura(int id, Fatura fatura)
        {
            if (id != fatura.IdFatura)
            {
                return BadRequest();
            }

            _context.Entry(fatura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaturaExists(id))
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

        // POST: api/Fatura
        [HttpPost]
        public async Task<ActionResult<Fatura>> PostFatura(Fatura fatura)
        {
            _context.Faturas.Add(fatura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFatura", new { id = fatura.IdFatura }, fatura);
        }

        // DELETE: api/Fatura/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFatura(int id)
        {
            var fatura = await _context.Faturas.FindAsync(id);
            if (fatura == null)
            {
                return NotFound();
            }

            _context.Faturas.Remove(fatura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FaturaExists(int id)
        {
            return _context.Faturas.Any(e => e.IdFatura == id);
        }
    }
}