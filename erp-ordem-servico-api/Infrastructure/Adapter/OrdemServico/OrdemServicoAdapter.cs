using erp_ordem_servico_api.Domain.Entities;
using erp_ordem_servico_api.Dto.OrdemServico;

public class AtividadeAdapter
{
    public OrdemServicoResponseDto ToDto(OrdemServicoEntity ordemServico)
    {
        return new OrdemServicoResponseDto
        {
            Id = ordemServico.Numero,
            Descricao = ordemServico.Descricao
        };
    }

    public OrdemServicoEntity ToEntity(OrdemServicoRequestDto requestDto)
    {
        return new OrdemServicoEntity
        {
            Descricao = requestDto.Descricao
        };
    }
}
