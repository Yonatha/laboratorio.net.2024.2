using AutoMapper;
using erp_ordem_servico_api.Domain.Entities;
using erp_ordem_servico_api.Dto.OrdemServico;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<OrdemServico, AtividadeResponseDto>();
        CreateMap<AtividadeRequestDto, OrdemServico>();
    }
}
