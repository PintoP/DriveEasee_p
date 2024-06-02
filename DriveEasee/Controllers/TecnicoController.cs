using DriveEasee.Models;
using DriveEasee.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DriveEasee.Services;

namespace DriveEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicoController : ControllerBase
    {
        private readonly DriveEaseContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtService _jwtService;

        public TecnicoController(DriveEaseContext context, UserManager<IdentityUser> userManager, JwtService jwtService)
        {
            _context = context;
            _userManager = userManager;
            _jwtService = jwtService;
        }

        // GET: api/Tecnico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tecnico>>> GetTecnicos()
        {
            return await _context.Tecnicos.ToListAsync();
        }

        // GET: api/Tecnico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tecnico>> GetTecnico(int id)
        {
            var tecnico = await _context.Tecnicos.FindAsync(id);

            if (tecnico == null)
            {
                return NotFound();
            }

            return tecnico;
        }

        // PUT: api/Tecnico/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTecnico(int id, Tecnico tecnico)
        {
            if (id != tecnico.IdTecnico)
            {
                return BadRequest();
            }

            if (_context.Tecnicos.Any(t => t.Email == tecnico.Email && t.IdTecnico != id))
            {
                return Conflict("Já existe um técnico com este e-mail.");
            }

            if (_context.Tecnicos.Any(t => t.Ntelemovel == tecnico.Ntelemovel && t.IdTecnico != id))
            {
                return Conflict("Já existe um técnico com este número de telefone.");
            }

            _context.Entry(tecnico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TecnicoExists(id))
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

        // POST: api/Tecnico
        [HttpPost]
        public async Task<ActionResult<Tecnico>> PostTecnico(Tecnico tecnico)
        {
            if (_context.Tecnicos.Any(t => t.Email == tecnico.Email))
            {
                return Conflict("Já existe um técnico com este e-mail.");
            }

            if (_context.Tecnicos.Any(t => t.Ntelemovel == tecnico.Ntelemovel))
            {
                return Conflict("Já existe um técnico com este número de telefone.");
            }

            _context.Tecnicos.Add(tecnico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTecnico", new { id = tecnico.IdTecnico }, tecnico);
        }

        // DELETE: api/Tecnico/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTecnico(int id)
        {
            var tecnico = await _context.Tecnicos.FindAsync(id);
            if (tecnico == null)
            {
                return NotFound();
            }

            _context.Tecnicos.Remove(tecnico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TecnicoExists(int id)
        {
            return _context.Tecnicos.Any(e => e.IdTecnico == id);
        }

        // POST: api/Tecnico/BearerToken
        [HttpPost("BearerToken")]
        public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken(AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Credenciais inválidas");
            }

            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return BadRequest("Credenciais inválidas");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Credenciais inválidas");
            }

            var token = _jwtService.CreateToken(user);

            return Ok(token);
        }

        //recebe caução
        //verifica estado do carro
    }
}
