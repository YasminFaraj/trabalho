using Microsoft.AspNetCore.Mvc;
using trabalho.Data;
using trabalho.Models;

namespace trabalho.Controllers
{
    [Route("api/folha")]
    [ApiController]
    public class FolhaDePagamentoController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public FolhaDePagamentoController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        // POST: api/folha/cadastrar
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] FolhaDePagamento folhaDePagamento)
        {
            if (folhaDePagamento == null)
            {
                return BadRequest("Folha de pagamento não pode ser nula.");
            }

            // Verifica se o funcionário existe
            var funcionario = _ctx.Funcionarios.Find(folhaDePagamento.FuncionarioId);
            if (funcionario == null)
            {
                return NotFound("Funcionário não encontrado.");
            }

            // Associa o funcionário à folha de pagamento
            folhaDePagamento.Funcionario = funcionario;

            // Adiciona a folha de pagamento ao contexto e salva
            _ctx.FolhasDePagamento.Add(folhaDePagamento);
            _ctx.SaveChanges();

            return Created("", folhaDePagamento); // Retorna a folha de pagamento criada
        }

        // GET: api/folha/listar
        [HttpGet("listar")]
        public IActionResult ObterFolhasDePagamento()
        {
            var folhas = _ctx.FolhasDePagamento.ToList(); // Obtém todas as folhas de pagamento
            return Ok(folhas); // Retorna a lista de folhas de pagamento
        }
    }
}
