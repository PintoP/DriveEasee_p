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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly DriveEaseContext _context;

        public CarroController(DriveEaseContext context)
        {
            _context = context;
        }

        // GET: api/Carro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> GetCarros()
        {
            return await _context.Carros.ToListAsync();
        }

        // GET: api/Carro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetCarro(int id)
        {
            var carro = await _context.Carros.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            return carro;
        }

        // PUT: api/Carro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarro(int id, Carro carro)
        {
            if (id != carro.IdCarro)
            {
                return BadRequest();
            }

            // Verificar se já existe outro carro com a mesma matrícula, excluindo o carro atual
            if (_context.Carros.Any(c => c.Matricula == carro.Matricula && c.IdCarro != id))
            {
                return Conflict("Já existe um carro com esta matrícula.");
            }

            _context.Entry(carro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(id))
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

        // POST: api/Carro
        [HttpPost]
        public async Task<ActionResult<Carro>> PostCarro(Carro carro)
        {
            // Verificar se já existe outro carro com a mesma matrícula
            if (_context.Carros.Any(c => c.Matricula == carro.Matricula))
            {
                return Conflict("Já existe um carro com esta matrícula.");
            }

            _context.Carros.Add(carro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarro", new { id = carro.IdCarro }, carro);
        }

        // DELETE: api/Carro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            // Verificar se há alugueres associados a este carro
            if (_context.Aluguers.Any(a => a.CarroIdCarro == id))
            {
                return Conflict("Não é possível excluir este carro, pois existem alugueres associados a ele.");
            }

            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.IdCarro == id);
        }
    }
}

