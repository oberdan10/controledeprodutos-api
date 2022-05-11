using AutoMapper;
using ControleDeProdutos_API.Data;
using ControleDeProdutos_API.DTOs.Categoria;
using ControleDeProdutos_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeProdutos_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CategoriaController : Controller
    {
        private Data.AppContext _context;
        private IMapper _automapper;

        public CategoriaController(Data.AppContext context, IMapper mapper) {
            _context = context;
            _automapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCategoria([FromBody] CreateCategoriaDto categoriaDto)
        {
            Categoria categoria = _automapper.Map<Categoria>(categoriaDto);
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaCategoriaPorCodigo), new {codigo = categoria.codigo}, categoria);
        }

        [HttpGet]
        public IActionResult BuscarCategoria()
        {
            return Ok(_context.Categorias);
        }

        [HttpGet("{codigo}")]
        public IActionResult BuscaCategoriaPorCodigo(long codigo)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.codigo == codigo);
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (categoria != null) 
            {
                ReadCategoriaDto categoriaDto = _automapper.Map<ReadCategoriaDto>(categoria);
                return Ok(categoriaDto);
            }
            return NotFound();

        }

        [HttpPut("{codigo}")]
        public IActionResult AtualizaCategoria(long codigo, [FromBody] UpdateCategoriaDto categoriaAtualizado) 
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.codigo == codigo);
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (categoria == null) 
            { 
                return NotFound(); 
            }

            _automapper.Map(categoriaAtualizado, categoria);

            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{codigo}")]
        public IActionResult DeletarCategoria(long codigo)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.codigo == codigo);
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Remove(categoria);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
