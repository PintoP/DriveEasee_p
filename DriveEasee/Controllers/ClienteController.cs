using DriveEasee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly UserManager<Cliente> _userManager;

        public ClienteController(UserManager<Cliente> userManager)
        {
            _userManager = userManager;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _userManager.Users.ToListAsync();
        }

        // GET: api/Cliente/email
        [HttpGet("{email}")]
        public async Task<ActionResult<Cliente>> GetCliente(string email)
        {
            Cliente cliente = await _userManager.FindByEmailAsync(email);

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

            var existingCliente = await _userManager.FindByIdAsync(id.ToString());

            existingCliente.Nome = cliente.Nome;
            existingCliente.Email = cliente.Email;

            var result = await _userManager.UpdateAsync(existingCliente);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors);
        }

        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            var result = await _userManager.CreateAsync(cliente, cliente.Password);

            if (result.Succeeded)
            {
                return CreatedAtAction(nameof(GetCliente), new { email = cliente.Email }, cliente);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _userManager.FindByIdAsync(id.ToString());

            if (cliente == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(cliente);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.Errors);
        }
    }
}
