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
    public class DevolucaoController : ControllerBase
    {
        private readonly DriveEaseContext _context;

        public DevolucaoController(DriveEaseContext context)
        {
            _context = context;
        }

        // GET: api/Devolucao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Devolucao>>> GetDevolucoes()
        {
            return await _context.Devolucaos.ToListAsync();
        }

        // GET: api/Devolucao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Devolucao>> GetDevolucao(int id)
        {
            var devolucao = await _context.Devolucaos.FindAsync(id);

            if (devolucao == null)
            {
                return NotFound();
            }

            return devolucao;
        }

        // PUT: api/Devolucao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevolucao(int id, Devolucao devolucao)
        {
            if (id != devolucao.IdDevolucao)
            {
                return BadRequest();
            }

            _context.Entry(devolucao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevolucaoExists(id))
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

        // POST: api/Devolucao
        [HttpPost]
        public async Task<ActionResult<Devolucao>> PostDevolucao(Devolucao devolucao)
        {
            // Verificar se já existe uma devolução para o aluguer
            if (_context.Devolucaos.Any(d => d.AluguerIdAluguer == devolucao.AluguerIdAluguer))
            {
                return Conflict("Já existe uma devolução para este aluguer.");
            }

            // Verificar se existe uma entrega associada ao aluguer
            if (!_context.Entregas.Any(e => e.AluguerIdAluguer == devolucao.AluguerIdAluguer))
            {
                return Conflict("Não é possível criar uma devolução sem uma entrega associada ao aluguer.");
            }

            _context.Devolucaos.Add(devolucao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevolucao", new { id = devolucao.IdDevolucao }, devolucao);
        }

        // DELETE: api/Devolucao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevolucao(int id)
        {
            var devolucao = await _context.Devolucaos.FindAsync(id);
            if (devolucao == null)
            {
                return NotFound();
            }

            _context.Devolucaos.Remove(devolucao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DevolucaoExists(int id)
        {
            return _context.Devolucaos.Any(e => e.IdDevolucao == id);
        }
    }
}
