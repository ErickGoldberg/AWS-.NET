using ECommerceLambda.Domain.Models;
using ProcessarPedidoPago.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessarPedidoPago.Services
{
    public class ProcessarPedidoPago : IProcessarPedidoPago
    {
        private readonly IStorageService storage;
        private readonly INotaFiscalRepository notaFiscalRepository;

        public ProcessarPedidoPago(IStorageService storage, INotaFiscalRepository notaFiscalRepository)
        {
            this.storage = storage;
            this.notaFiscalRepository = notaFiscalRepository;
        }

        public async Task Processar(Pedido pedido)
        {
            var notaFiscal = new NotaFiscal
            {
                DocumentoCliente = pedido.DocumentoCliente,
                IdNotaFiscal = Guid.NewGuid().ToString(),
                BaseDeCalculo = pedido.ValorTotal,
                AliquotaTributo = 20,
                Descricao = $"Nota Fiscal relativa ao pedido {pedido.PedidoId}"
            };


            await this.storage.SalvarNotaFiscal(notaFiscal);
            await this.notaFiscalRepository.SalvarNotaFiscal(notaFiscal);
        }
    }
}
