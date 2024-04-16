using AprovarPedidoLambda.Repositories;
using ECommerceLambda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprovarPedidoLambda.Services
{
    public class AprovarPedidoService : IAprovarPedidoService
    {
        private readonly IPedidoRepository pedidoRepository;
        private readonly IMessageService messageService;

        public AprovarPedidoService(IPedidoRepository pedidoRepository, IMessageService messageService)
        {
            this.pedidoRepository = pedidoRepository;
            this.messageService = messageService;

            // messageService
        }

        public async Task AprovarPedido(Pedido pedido)
        {
            if(pedido == null)
            {
                throw new Exception("Pedido é de preenchimento obrigatório");
            }

            if(pedido.Cliente == null)
            {
                throw new Exception("Cliente é de preenchimento obrigatório");
            }

            if(pedido.Cliente.Endereco == null)
            {
                throw new Exception("Endereço é de preenchimento obrigatório");
            }

            // tentativa de pagamento no Gateway

            pedido.StatusPedido = StatusPedidoEnum.AGUARDANDO_ENVIO;

            await this.pedidoRepository.SalvarPedido(pedido);
            await this.messageService.SendMessage(pedido);
        }
    }
}
