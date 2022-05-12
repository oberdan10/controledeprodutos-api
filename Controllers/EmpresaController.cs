using AutoMapper;
using ControleDeProdutos_API.Data.DTOs.Empresa;
using ControleDeProdutos_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeProdutos_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : Controller
    {
        private Data.AppContext _context;
        private IMapper _automapper;

        public EmpresaController(Data.AppContext context, IMapper mapper)
        {
            _context = context;
            _automapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaEmpresa([FromBody] CreateEmpresaDto empresaDto)
        {
            Empresa empresa = _automapper.Map<Empresa>(empresaDto);
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaEmpresaPorCodigo), new { codigo = empresa.codigo }, empresa);
        }

        [HttpGet]
        public IActionResult BuscarEmpresa()
        {
            return Ok(_context.Empresas);
        }

        [HttpGet("{codigo}")]
        public IActionResult BuscaEmpresaPorCodigo(long codigo)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Empresa empresa = _context.Empresas.FirstOrDefault(empresa => empresa.codigo == codigo);
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (empresa != null)
            {
                ReadEmpresaDto empresaDto = _automapper.Map<ReadEmpresaDto>(empresa);
                return Ok(empresaDto);
            }
            return NotFound();

        }

        [HttpPut("{codigo}")]
        public IActionResult AtualizaEmpresa(long codigo, [FromBody] UpdateEmpresaDto empresaAtualizado)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Empresa empresa = _context.Empresas.FirstOrDefault(empresa => empresa.codigo == codigo);
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (empresa == null)
            {
                return NotFound();
            }

            _automapper.Map(empresaAtualizado, empresa);

            //item.descricao = itemAtualizado.descricao;
            //item.lote = itemAtualizado.lote;
            //item.observacao = itemAtualizado.observacao;

            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{codigo}")]
        public IActionResult DeletarEmpresa(long codigo)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Empresa empresa = _context.Empresas.FirstOrDefault(empresa => empresa.codigo == codigo);
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (empresa == null)
            {
                return NotFound();
            }

            _context.Remove(empresa);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
