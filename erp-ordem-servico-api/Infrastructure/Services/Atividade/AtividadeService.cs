using AutoMapper;
using erp_ordem_servico_api.Domain.Entities;
using erp_ordem_servico_api.Dto.Atividade;
using erp_ordem_servico_api.Infrastructure.Persistence.Repositories;

namespace erp_ordem_servico_api.Infrastructure.Services.Atividade
{
    public class AtividadeService : GenericService<AtividadeRequestDto, AtividadeResponseDto, AtvidiadeEntity>
    {
        public AtividadeService(IRepository<AtvidiadeEntity> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
