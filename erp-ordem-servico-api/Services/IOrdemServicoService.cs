using LaboratorioDev.Entity.Dto;
using LaboratorioDev.Shared;

namespace LaboratorioDev.Services
{
    public interface IOrdemServicoService
    {
        Task<Result<List<OrdemServicoResponseDto>>> GetAll();
        Task<Result<OrdemServicoResponseDto>> GetById(int id);
        Task<Result<OrdemServicoResponseDto>> Create(OrdemServicoRequestDto request);
        Task<Result<OrdemServicoResponseDto>> Delete(int id);
        Task<Result<OrdemServicoResponseDto>> Update(int id, string descricao);
        Task<Result<OrdemServicoDeleteResponseDto>> DeleteList(OrdemServicoDeleteRequestDto request);
    }
}