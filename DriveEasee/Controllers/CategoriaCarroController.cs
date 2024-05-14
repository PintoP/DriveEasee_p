using DriveEasee.Models;
using DriveEasee.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriveEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaCarroController : ControllerBase
    {
        private readonly DriveEaseContext _context;

        public CategoriaCarroController(DriveEaseContext context)
        {
            _context = context;
        }

        // GET: api/CategoriaCarro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaCarro>>> GetCategoriasCarro()
        {
            return await _context.CategoriaCarros.ToListAsync();
        }

        // GET: api/CategoriaCarro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaCarro>> GetCategoriaCarro(int id)
        {
            var categoriaCarro = await _context.CategoriaCarros.FindAsync(id);

            if (categoriaCarro == null)
            {
                return NotFound();
            }

            return categoriaCarro;
        }

        // PUT: api/CategoriaCarro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaCarro(int id, CategoriaCarro categoriaCarro)
        {
            if (id != categoriaCarro.IdCategoriaCarro)
            {
                return BadRequest();
            }

            _context.Entry(categoriaCarro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaCarroExists(id))
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

        // POST: api/CategoriaCarro
        [HttpPost]
        public async Task<ActionResult<CategoriaCarro>> PostCategoriaCarro(CategoriaCarro categoriaCarro)
        {
            _context.CategoriaCarros.Add(categoriaCarro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaCarro", new { id = categoriaCarro.IdCategoriaCarro }, categoriaCarro);
        }

        // DELETE: api/CategoriaCarro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaCarro(int id)
        {
            var categoriaCarro = await _context.CategoriaCarros.FindAsync(id);
            if (categoriaCarro == null)
            {
                return NotFound();
            }

            _context.CategoriaCarros.Remove(categoriaCarro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaCarroExists(int id)
        {
            return _context.CategoriaCarros.Any(e => e.IdCategoriaCarro == id);
        }
    }
}
