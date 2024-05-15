using DriveEasee.Models;
using DriveEasee.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            // Verificar se já existe outro código postal igual
            if (_context.Cpostals.Any(c => ((c.Inicio).ToString() + (c.Inicio).ToString()) == ((cpostal.Inicio).ToString()+ (cpostal.Inicio).ToString())))
            {
                return Conflict("Já existe um código postal com este valor.");
            }

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

            // Verificar se o código postal está associado a um técnico ou cliente
            if (_context.Tecnicos.Any(t => t.CpostalIdCpostal == id) || _context.Clientes.Any(c => c.CpostalIdCpostal == id))
            {
                return Conflict("Não é possível excluir este código postal, pois está associado a um técnico ou cliente.");
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
