using AutoMapper;
using ControleDeProdutos_API.Data;
using ControleDeProdutos_API.Data.DTOs.Item;
using ControleDeProdutos_API.Data.DTOs.Nota;
using ControleDeProdutos_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ControleDeProdutos_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ItemController : Controller
    {
        private Data.AppContext _context;
        private IMapper _automapper;

        public ItemController(Data.AppContext context, IMapper mapper) {
            _context = context;
            _automapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaItem([FromBody] CreateNotaDto itemDto)
        {
            Item item = _automapper.Map<Item>(itemDto);
            _context.Itens.Add(item);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaItemPorCodigo), new {codigo = item.codigo}, item );
        }

        [HttpGet]
        public IActionResult BuscarItem()
        {
            return Ok(_context.Itens.Include(categoria => categoria.Categoria).ToList());
        }

        [HttpGet("{codigo}")]
        public IActionResult BuscaItemPorCodigo(long codigo)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Item item = _context.Itens.FirstOrDefault(item => item.codigo == codigo);
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (item != null) 
            {
                ReadItemDto itemDto = _automapper.Map<ReadItemDto>(item);
                return Ok(itemDto);
            }
            return NotFound();

        }

        [HttpPut("{codigo}")]
        public IActionResult AtualizaItem(long codigo, [FromBody] UpdateItemDto itemAtualizado) 
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Item item = _context.Itens.FirstOrDefault(item => item.codigo == codigo);
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (item == null) 
            { 
                return NotFound(); 
            }

            _automapper.Map(itemAtualizado,item);

            //item.descricao = itemAtualizado.descricao;
            //item.lote = itemAtualizado.lote;
            //item.observacao = itemAtualizado.observacao;

            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{codigo}")]
        public IActionResult DeletarItem(long codigo)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Item item = _context.Itens.FirstOrDefault(item => item.codigo == codigo);
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (item == null)
            {
                return NotFound();
            }

            _context.Remove(item);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
