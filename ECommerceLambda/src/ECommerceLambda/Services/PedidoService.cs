using Amazon.SQS;
using Amazon.SQS.Model;
using ECommerceLambda.Domain.Models;
using System.Text.Json;

namespace ECommerceLambda.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IAmazonSQS sqsClient;

        public PedidoService(IAmazonSQS sqsClient)
        {
            this.sqsClient = sqsClient;
        }

        public async Task EnviarPedido(Pedido pedido)
        {
            var request = new SendMessageRequest
            {
                MessageBody = JsonSerializer.Serialize(pedido),
                QueueUrl = "https://sqs.us-east-1.amazonaws.com/137031771149/pedido-criado-sqs"
            };

            await this.sqsClient.SendMessageAsync(request);
        }
    }
}
