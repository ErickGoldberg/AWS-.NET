using Xunit;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.SQSEvents;
using ECommerceLambda.Domain.Models;
using System.Text.Json;

namespace ProcessarPedidoPago.Tests;

public class FunctionTest
{
    [Fact]
    public async Task TestSQSEventLambdaFunction()
    {
        var pedido = new Pedido
        {
            Cliente = new Cliente
            {
                Nome = "Erick",
                Documento = "12165657879",
                Email = "erick@email.com",
                Endereco = new Endereco
                {
                    Cidade = "Recife",
                    Estado = "PE",
                    Logradouro = "Rua dos bom dias",
                    Numero = 123,
                    Complemento = "apt 123"
                },
            },
            PedidoId = Guid.NewGuid(),
            StatusPedido = StatusPedidoEnum.AGUARDANDO_PAGAMENTO,
            ItensPedido = new List<ItemPedido>
                {
                    new ItemPedido
                    {
                        ProdutoId = 1,
                        Quantidade = 2,
                        ValorUnitario = 50
                    }
                }
        };

        var input = new SQSEvent
        {
            Records = new List<SQSEvent.SQSMessage>
                 {
                     new SQSEvent.SQSMessage
                     {
                         Body = JsonSerializer.Serialize(pedido),
                         Attributes = new Dictionary<string, string>()
                         {
                             { "ApproximateReceiveCount", "1" }
                         }
                     }
                 }
        };

        var logger = new TestLambdaLogger();
        var context = new TestLambdaContext
        {
            Logger = logger
        };

        var function = new Function();
        await function.FunctionHandler(input, context);
    }
}