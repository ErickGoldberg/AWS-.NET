using Amazon.DynamoDBv2.DataModel;
using ECommerceLambda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprovarPedidoLambda.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IDynamoDBContext context;

        public PedidoRepository(IDynamoDBContext context)
        {
            this.context = context;
        }

        public async Task SalvarPedido(Pedido pedido)
        {
            await this.context.SaveAsync(pedido);
        }
    }
}
