using ECommerceLambda.Domain.Models;
using ECommerceLambda.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceLambda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteRepository repository;

        public ClienteController(ILogger<ClienteController> logger, IClienteRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CriarCliente(Cliente cliente)
        {
            await this.repository.Adicionar(cliente);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarCliente(Cliente cliente)
        {
            await this.repository.Atualizar(cliente);

            return Ok();
        }

        [HttpDelete("{documento}")]
        public async Task<IActionResult> DeletarCliente(string documento)
        {
            await this.repository.Deletar(documento);

            return Ok();
        }

        [HttpGet("{documento}")]
        public async Task<IActionResult> ObterClientePorDocumento(string documento)
        {
            var cliente = await this.repository.Buscar(documento);

            return Ok(cliente);
        }
    }
}