using AutoMapper;
using ControleDeProdutos_API.Data.DTOs.Nota;
using ControleDeProdutos_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeProdutos_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotaController : Controller
    {
        private Data.AppContext _context;
        private IMapper _automapper;

        public NotaController(Data.AppContext context, IMapper mapper)
        {
            _context = context;
            _automapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaNota([FromBody] CreateNotaDto notaDto)
        {
            Nota nota = _automapper.Map<Nota>(notaDto);
            _context.Notas.Add(nota);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaNotaPorCodigo), new { codigo = nota.codigo }, nota);
        }

        [HttpGet]
        public IActionResult BuscarNota()
        {
            return Ok(_context.Notas.Include(empresa => empresa.Empresa).ToList());
        }

        [HttpGet("{codigo}")]
        public IActionResult BuscaNotaPorCodigo(long codigo)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Nota nota = _context.Notas.FirstOrDefault(nota => nota.codigo == codigo);
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (nota != null)
            {
                ReadNotaDto notaDto = _automapper.Map<ReadNotaDto>(nota);
                return Ok(notaDto);
            }
            return NotFound();

        }

        [HttpPut("{codigo}")]
        public IActionResult AtualizaNota(long codigo, [FromBody] UpdateNotaDto notaAtualizado)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Nota nota = _context.Notas.FirstOrDefault(nota => nota.codigo == codigo);
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (nota == null)
            {
                return NotFound();
            }

            _automapper.Map(notaAtualizado, nota);

            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{codigo}")]
        public IActionResult DeletarNota(long codigo)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Nota nota = _context.Notas.FirstOrDefault(nota => nota.codigo == codigo);
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (nota == null)
            {
                return NotFound();
            }

            _context.Remove(nota);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
