using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trabalho.Data;
using trabalho.Models;

namespace trabalho.Controllers
{
    [Route("api/funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public FuncionarioController(AppDataContext ctx)
        {
            _ctx = ctx; // Inicializa o contexto
        }

        // POST: api/funcionario
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Funcionario funcionario)
        {
            _ctx.Funcionarios.Add(funcionario); // Adiciona o funcionário ao contexto
            _ctx.SaveChanges(); // Salva as alterações no banco de dados

            return Created("", funcionario);
        }

        [HttpPost]
        [Route("Listar")]
        public IActionResult ObterFuncionarios()
        {
            var funcionarios = _ctx.Funcionarios.ToList(); // Obtém todos os funcionários
            return Ok(funcionarios); // Retorna a lista de funcionários
        }
    }
}
