using Amazon.DynamoDBv2.DataModel;
using ECommerceLambda.Domain.Models;

namespace ECommerceLambda.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDynamoDBContext contexto;

        public ClienteRepository(IDynamoDBContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task Adicionar(Cliente cliente)
        {
            await this.contexto.SaveAsync<Cliente>(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            await this.contexto.SaveAsync<Cliente>(cliente);
        }

        public async Task<Cliente?> Buscar(string documento)
        {
            return await this.contexto.LoadAsync<Cliente?>(documento);
        }

        public async Task Deletar(string documento)
        {
            await this.contexto.DeleteAsync<Cliente>(documento);
        }
    }
}
