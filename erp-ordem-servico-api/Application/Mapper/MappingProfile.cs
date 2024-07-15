using AutoMapper;
using erp_ordem_servico_api.Domain.Entities;
using LaboratorioDev.Dto.Atividade;
using erp_ordem_servico_api.Dto.OrdemServico;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<OrdemServicoDeleteRequestDto, OrdemServicoEntity>();
        CreateMap<OrdemServicoEntity, OrdemServicoDeleteResponseDto>();
        CreateMap<OrdemServicoEntity, OrdemServicoResponse>();
        CreateMap<OrdemServicoRequest, OrdemServicoEntity>();


        CreateMap<AtividadeRequest, AtividadeEntity>();
        CreateMap<AtividadeEntity, AtividadeResponse>();
    }
}
