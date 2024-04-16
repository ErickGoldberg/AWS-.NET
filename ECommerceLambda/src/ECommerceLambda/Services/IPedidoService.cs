using ECommerceLambda.Domain.Models;

namespace ECommerceLambda.Services
{
    public interface IPedidoService
    {
        Task EnviarPedido(Pedido pedido);
    }
}
