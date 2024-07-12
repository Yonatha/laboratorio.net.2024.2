using LaboratorioDev.Entity;
using LaboratorioDev.Entity.Dto;

public class OrdemServicoAdapter
{
    public OrdemServicoResponseDto ToDto(OrdemServico ordemServico)
    {
        return new OrdemServicoResponseDto
        {
            Numero = ordemServico.Numero,
            Descricao = ordemServico.Descricao
        };
    }

    public OrdemServico ToEntity(OrdemServicoRequestDto requestDto)
    {
        return new OrdemServico
        {
            Descricao = requestDto.Descricao
        };
    }
}
