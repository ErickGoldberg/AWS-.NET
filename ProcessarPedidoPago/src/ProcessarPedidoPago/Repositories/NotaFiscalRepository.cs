using Amazon.DynamoDBv2.DataModel;
using ECommerceLambda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessarPedidoPago.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly IDynamoDBContext contexto;

        public NotaFiscalRepository(IDynamoDBContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task SalvarNotaFisca(NotaFiscal notaFiscal)
        {
            await this.contexto.SaveAsync(notaFiscal);
        }
    }
}
