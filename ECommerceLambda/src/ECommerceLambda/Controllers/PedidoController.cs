using ECommerceLambda.Domain.Models;
using ECommerceLambda.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceLambda.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly ILogger<PedidoController> logger;
        private readonly IPedidoService service;

        public PedidoController(ILogger<PedidoController> logger, IPedidoService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarPedido(Pedido pedido)
        {
            this.logger.LogInformation("Enviando o pedido para a fila.");

            await this.service.EnviarPedido(pedido);

            return Ok();
        }

    }
}
