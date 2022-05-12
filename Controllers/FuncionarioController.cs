using AutoMapper;
using ControleDeProdutos_API.Data.DTOs.Funcionario;
using Microsoft.AspNetCore.Mvc;
using ControleDeProdutos_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeProdutos_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : Controller
    {
        private Data.AppContext _context;
        private IMapper _automapper;

        public FuncionarioController(Data.AppContext context, IMapper mapper)
        {
            _context = context;
            _automapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFuncionario([FromBody] CreateFuncionarioDto funcionarioDto)
        {
            Funcionario funcionario = _automapper.Map<Funcionario>(funcionarioDto);
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaFuncionarioPorCodigo), new { codigo = funcionario.codigo }, funcionario);
        }

        [HttpGet]
        public IActionResult BuscarFuncionario()
        {
            return Ok(_context.Funcionarios.Include(empresa => empresa.Empresa).ToList());
        }

        [HttpGet("{codigo}")]
        public IActionResult BuscaFuncionarioPorCodigo(long codigo)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Funcionario funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.codigo == codigo);
#pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (funcionario != null)
            {
                ReadFuncionarioDto funcionarioDto = _automapper.Map<ReadFuncionarioDto>(funcionario);
                return Ok(funcionarioDto);
            }
            return NotFound();

        }

        [HttpPut("{codigo}")]
        public IActionResult AtualizaFuncionario(long codigo, [FromBody] UpdateFuncionarioDto funcionarioAtualizado)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Funcionario funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.codigo == codigo);
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (funcionario == null)
            {
                return NotFound();
            }

            _automapper.Map(funcionarioAtualizado, funcionario);

            //item.descricao = itemAtualizado.descricao;
            //item.lote = itemAtualizado.lote;
            //item.observacao = itemAtualizado.observacao;

            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{codigo}")]
        public IActionResult DeletarFuncionario(long codigo)
        {
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            Funcionario funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.codigo == codigo);
#pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Remove(funcionario);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
