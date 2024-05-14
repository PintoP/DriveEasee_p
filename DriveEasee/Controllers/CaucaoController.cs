using DriveEasee.Models;
using DriveEasee.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriveEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaucaoController : ControllerBase
    {
        private readonly DriveEaseContext _context;

        public CaucaoController(DriveEaseContext context)
        {
            _context = context;
        }

        // GET: api/Caucao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caucao>>> GetCaucaos()
        {
            return await _context.Caucaos.ToListAsync();
        }

        // GET: api/Caucao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caucao>> GetCaucao(int id)
        {
            var caucao = await _context.Caucaos.FindAsync(id);

            if (caucao == null)
            {
                return NotFound();
            }

            return caucao;
        }

        // PUT: api/Caucao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaucao(int id, Caucao caucao)
        {
            if (id != caucao.IdCaucao)
            {
                return BadRequest();
            }

            _context.Entry(caucao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaucaoExists(id))
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

        // POST: api/Caucao
        [HttpPost]
        public async Task<ActionResult<Caucao>> PostCaucao(Caucao caucao)
        {
            _context.Caucaos.Add(caucao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaucao", new { id = caucao.IdCaucao }, caucao);
        }

        // DELETE: api/Caucao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaucao(int id)
        {
            var caucao = await _context.Caucaos.FindAsync(id);
            if (caucao == null)
            {
                return NotFound();
            }

            _context.Caucaos.Remove(caucao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CaucaoExists(int id)
        {
            return _context.Caucaos.Any(e => e.IdCaucao == id);
        }
    }
}
