using erp_ordem_servico_api.Domain.Entities;
using erp_ordem_servico_api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace erp_ordem_servico_api.tests.PresentationTest
{

    [CollectionDefinition("ErpDbContext")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
        
    }

    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            // Configure o estado inicial, por exemplo, configure um banco de dados em memória
            var options = new DbContextOptionsBuilder<ErpDbContext>()
                .UseInMemoryDatabase(databaseName: "erp_os")
            .Options;

            Context = new ErpDbContext(options);

            // Adicione dados iniciais se necessário
            Context.Atividade.Add(new AtividadeEntity { Descricao = "Atividade 1" });
            Context.SaveChanges();
        }

        public ErpDbContext Context { get; }

        public void Dispose()
        {
            // Limpe o estado após os testes, se necessário
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }

}
