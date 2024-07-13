using erp_ordem_servico_api.Domain.Entities;
using erp_ordem_servico_api.Dto.OrdemServico;

public class OrdemServicoAdapter
{
    public AtividadeResponseDto ToDto(OrdemServico ordemServico)
    {
        return new AtividadeResponseDto
        {
            Numero = ordemServico.Numero,
            Descricao = ordemServico.Descricao
        };
    }

    public OrdemServico ToEntity(AtividadeRequestDto requestDto)
    {
        return new OrdemServico
        {
            Descricao = requestDto.Descricao
        };
    }
}
