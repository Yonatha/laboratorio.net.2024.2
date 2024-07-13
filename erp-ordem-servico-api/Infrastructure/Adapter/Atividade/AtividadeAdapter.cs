using erp_ordem_servico_api.Domain.Entities;
using erp_ordem_servico_api.Dto.OrdemServico;

namespace erp_ordem_servico_api.Infrastructure.Adapter.Atividade
{
    public class AtividadeAdapter
    {
        public OrdemServicoResponseDto ToDto(AtividadeEntity entity)
        {
            return new OrdemServicoResponseDto
            {
                Id = entity.Id,
                Descricao = entity.Descricao
            };
        }

        public AtividadeEntity ToEntity(OrdemServicoRequestDto requestDto)
        {
            return new AtividadeEntity
            {
                Descricao = requestDto.Descricao
            };
        }
    }
}