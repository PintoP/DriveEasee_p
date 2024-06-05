using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveEasee.Data;
using DriveEasee.Models;
using DriveEasee.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DriveEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DriveEaseContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ClienteController> _logger;
        public ClienteController(UserManager<IdentityUser> userManager, IConfiguration configuration, DriveEaseContext context, ILogger<ClienteController> logger)
        {
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
            _logger = logger;
        }
        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }

            // Verificar se já existe outro cliente com o mesmo email
            if (_context.Clientes.Any(c => c.Email == cliente.Email && c.IdCliente != id))
            {
                return Conflict("Já existe um cliente com este email.");
            }

            // Verificar se já existe outro cliente com o mesmo número de telefone
            if (_context.Clientes.Any(c => c.Ntelemovel == cliente.Ntelemovel && c.IdCliente != id))
            {
                return Conflict("Já existe um cliente com este número de telefone.");
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            if (_context.Clientes.Any(c => c.Email == cliente.Email))
            {
                return Conflict("Já existe um cliente com este email.");
            }

            if (_context.Clientes.Any(c => c.Ntelemovel == cliente.Ntelemovel))
            {
                return Conflict("Já existe um cliente com este número de telefone.");
            }

            var result = await _userManager.CreateAsync(
                new IdentityUser { UserName = cliente.Email, Email = cliente.Email },
                cliente.Password
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            cliente.Password = null;
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.IdCliente }, cliente);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            if (_context.Aluguers.Any(a => a.ClienteIdCliente == id))
            {
                return Conflict("Não é possível excluir este cliente, pois existem alugueres associados a ele.");
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }

        // POST: api/Cliente/BearerToken
        [HttpPost("BearerToken")]
        public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken([FromBody] AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Credenciais inválidas");
            }

            // Verifique se o cliente existe na tabela Clientes
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == request.Email);
            if (cliente == null)
            {
                return BadRequest("Credenciais inválidas: cliente não encontrado");
            }

            // Verifique se o usuário existe no Identity
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return BadRequest("Credenciais inválidas: usuário não encontrado");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
            {
                return BadRequest("Credenciais inválidas: senha incorreta");
            }

            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }
        private string GenerateJwtToken(IdentityUser user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        //introduz datas
        //confirma pagamento

    }
}
