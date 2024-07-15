using erp_ordem_servico_api.Domain.Entities;
using LaboratorioDev.Dto.Atividade;

namespace erp_ordem_servico_api.Infrastructure.Adapter.Atividade
{
    public class AtividadeAdapter
    {
        public AtividadeResponse ToDto(AtividadeEntity entity)
        {
            return new AtividadeResponse(entity.Id, entity.Descricao);
        }

        public AtividadeEntity ToEntity(AtividadeRequest request)
        {
            return new AtividadeEntity
            {
                Descricao = request.Descricao
            };
        }
    }
}