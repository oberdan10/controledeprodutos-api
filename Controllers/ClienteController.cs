using AutoMapper;
using ControleDeProdutos_API.Data.DTOs.Cliente;
using ControleDeProdutos_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeProdutos_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private Data.AppContext _context;
        private IMapper _automapper;

        public ClienteController(Data.AppContext context, IMapper mapper)
        {
            _context = context;
            _automapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCliente([FromBody] CreateClienteDto clienteDto)
        {
            Cliente cliente = _automapper.Map<Cliente>(clienteDto);
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaClientePorCodigo), new { codigo = cliente.codigo }, cliente);
        }

        [HttpGet]
        public IActionResult BuscarCliente()
        {
            return Ok(_context.Clientes.Include(empresa => empresa.Empresa).ToList());
        }

        [HttpGet("{codigo}")]
        public IActionResult BuscaClientePorCodigo(long codigo)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.codigo == codigo);
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (cliente != null)
            {
                ReadClienteDto clienteDto = _automapper.Map<ReadClienteDto>(cliente);
                return Ok(clienteDto);
            }
            return NotFound();

        }

        [HttpPut("{codigo}")]
        public IActionResult Atualizacliente(long codigo, [FromBody] UpdateClienteDto clienteAtualizado)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.codigo == codigo);
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (cliente == null)
            {
                return NotFound();
            }

            _automapper.Map(clienteAtualizado, cliente);

            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{codigo}")]
        public IActionResult DeletarCliente(long codigo)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.codigo == codigo);
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Remove(cliente);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
