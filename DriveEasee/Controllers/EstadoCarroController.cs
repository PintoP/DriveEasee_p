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
    public class EstadoCarroController : ControllerBase
    {
        private readonly DriveEaseContext _context;

        public EstadoCarroController(DriveEaseContext context)
        {
            _context = context;
        }

        // GET: api/EstadoCarro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoCarro>>> GetEstadosCarro()
        {
            return await _context.EstadoCarros.ToListAsync();
        }

        // GET: api/EstadoCarro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoCarro>> GetEstadoCarro(int id)
        {
            var estadoCarro = await _context.EstadoCarros.FindAsync(id);

            if (estadoCarro == null)
            {
                return NotFound();
            }

            return estadoCarro;
        }

        // PUT: api/EstadoCarro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoCarro(int id, EstadoCarro estadoCarro)
        {
            if (id != estadoCarro.IdEstadoCarro)
            {
                return BadRequest();
            }

            _context.Entry(estadoCarro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoCarroExists(id))
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

        // POST: api/EstadoCarro
        [HttpPost]
        public async Task<ActionResult<EstadoCarro>> PostEstadoCarro(EstadoCarro estadoCarro)
        {
            // Verificar se já existe um estado de carro com o mesmo nome
            if (_context.EstadoCarros.Any(e => e.Nome == estadoCarro.Nome))
            {
                return Conflict("Já existe um estado de carro com este nome.");
            }

            _context.EstadoCarros.Add(estadoCarro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoCarro", new { id = estadoCarro.IdEstadoCarro }, estadoCarro);
        }

        // DELETE: api/EstadoCarro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoCarro(int id)
        {
            var estadoCarro = await _context.EstadoCarros.FindAsync(id);
            if (estadoCarro == null)
            {
                return NotFound();
            }

            // Verificar se o estado de carro está associado a algum carro
            if (_context.Carros.Any(c => c.EstadoCarroIdEstadoCarro == id))
            {
                return Conflict("Não é possível excluir este estado de carro, pois está associado a algum carro.");
            }

            _context.EstadoCarros.Remove(estadoCarro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoCarroExists(int id)
        {
            return _context.EstadoCarros.Any(e => e.IdEstadoCarro == id);
        }
    }
}
