using DriveEasee.Models;
using DriveEasee.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Permissions;

namespace DriveEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AluguerController : ControllerBase
    {
            private readonly DriveEaseContext _context;

            public AluguerController(DriveEaseContext context)
            {
                _context = context;
            }

            // GET: api/Aluguer
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Aluguer>>> GetAlugueres()
            {
                return await _context.Aluguers.ToListAsync();
            }

            // GET: api/Aluguer/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Aluguer>> GetAluguer(int id)
            {
                var aluguer = await _context.Aluguers.FindAsync(id);

                if (aluguer == null)
                {
                    return NotFound();
                }

                return aluguer;
            }

            // PUT: api/Aluguer/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutAluguer(int id, Aluguer aluguer)
            {
                if (id != aluguer.IdAluguer)
                {
                    return BadRequest();
                }

                _context.Entry(aluguer).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AluguerExists(id))
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

            // POST: api/Aluguer
            [HttpPost]
        public async Task<ActionResult<Aluguer>> PostAluguer(Aluguer aluguer)
        {
            // Verifica se já existe um aluguer para o mesmo carro em tempos sobrepostos
            if (await AluguerExistsWithOverlap(aluguer))
            {
                return BadRequest("Já existe um aluguer para este carro em tempos sobrepostos.");
            }

            _context.Aluguers.Add(aluguer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAluguer", new { id = aluguer.IdAluguer }, aluguer);
        }

        // Método para verificar se já existe um aluguer para o mesmo carro em tempos sobrepostos
        private async Task<bool> AluguerExistsWithOverlap(Aluguer aluguer)
        {
            return await _context.Aluguers.AnyAsync(a =>
                a.CarroIdCarro == aluguer.CarroIdCarro &&
                !(a.DataInicio <= aluguer.DataInicio || a.DataInicio >= aluguer.DataInicio)
            );
        }   

        // DELETE: api/Aluguer/5
        [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAluguer(int id)
            {
                var aluguer = await _context.Aluguers.FindAsync(id);
                if (aluguer == null)
                {
                    return NotFound();
                }

                _context.Aluguers.Remove(aluguer);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool AluguerExists(int id)
            {
                return _context.Aluguers.Any(e => e.IdAluguer == id);
            }

        //Envia confirmação da eserve (email)
        
    }
}

