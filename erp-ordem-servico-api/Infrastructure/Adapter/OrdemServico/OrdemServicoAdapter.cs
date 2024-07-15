using erp_ordem_servico_api.Domain.Entities;
using erp_ordem_servico_api.Dto.OrdemServico;

public class AtividadeAdapter
{
    public OrdemServicoResponse ToDto(OrdemServicoEntity ordemServico)
    {
        return new(ordemServico.Numero, ordemServico.Descricao);
    }

    public OrdemServicoEntity ToEntity(OrdemServicoRequest requestDto)
    {
        return new OrdemServicoEntity
        {
            Descricao = requestDto.Descricao
        };
    }
}
