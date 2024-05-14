using DriveEasee.Models;
using DriveEasee.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriveEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPagamentoController : ControllerBase
    {
        private readonly DriveEaseContext _context;

        public TipoPagamentoController(DriveEaseContext context)
        {
            _context = context;
        }

        // GET: api/TipoPagamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPagamento>>> GetTiposPagamento()
        {
            return await _context.TipoPagamentos.ToListAsync();
        }

        // GET: api/TipoPagamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPagamento>> GetTipoPagamento(int id)
        {
            var tipoPagamento = await _context.TipoPagamentos.FindAsync(id);

            if (tipoPagamento == null)
            {
                return NotFound();
            }

            return tipoPagamento;
        }

        // PUT: api/TipoPagamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoPagamento(int id, TipoPagamento tipoPagamento)
        {
            if (id != tipoPagamento.IdTipoPagamento)
            {
                return BadRequest();
            }

            _context.Entry(tipoPagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoPagamentoExists(id))
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

        // POST: api/TipoPagamento
        [HttpPost]
        public async Task<ActionResult<TipoPagamento>> PostTipoPagamento(TipoPagamento tipoPagamento)
        {
            _context.TipoPagamentos.Add(tipoPagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoPagamento", new { id = tipoPagamento.IdTipoPagamento }, tipoPagamento);
        }

        // DELETE: api/TipoPagamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoPagamento(int id)
        {
            var tipoPagamento = await _context.TipoPagamentos.FindAsync(id);
            if (tipoPagamento == null)
            {
                return NotFound();
            }

            _context.TipoPagamentos.Remove(tipoPagamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoPagamentoExists(int id)
        {
            return _context.TipoPagamentos.Any(e => e.IdTipoPagamento == id);
        }
    }
}
