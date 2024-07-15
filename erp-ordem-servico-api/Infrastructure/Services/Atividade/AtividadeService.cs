using AutoMapper;
using erp_ordem_servico_api.Domain.Entities;
using erp_ordem_servico_api.Infrastructure.Persistence.Repositories;
using LaboratorioDev.Dto.Atividade;

namespace erp_ordem_servico_api.Infrastructure.Services.Atividade
{
    public class AtividadeService : GenericService<AtividadeRequest, AtividadeResponse, AtividadeEntity>
    {
        public AtividadeService(IRepository<AtividadeEntity> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
