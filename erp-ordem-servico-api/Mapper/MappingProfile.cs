using AutoMapper;
using LaboratorioDev.Entity;
using LaboratorioDev.Entity.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<OrdemServico, OrdemServicoResponseDto>();
        CreateMap<OrdemServicoRequestDto, OrdemServico>();
    }
}
