using LaboratorioDev.Entity.Dto;
using LaboratorioDev.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LaboratorioDev.Services
{
    public interface IOrdemServicoService
    {
        Task<List<OrdemServicoResponseDto>> GetAll();
        Task<OrdemServico> GetById(int id);
        Task<OrdemServicoResponseDto> Create(OrdemServicoRequestDto request);
        Task<bool> Delete(int id);
        Task<OrdemServicoResponseDto> Update(int id, string descricao);
        Task<OrdemServicoDeleteResponseDto> DeleteList(OrdemServicoDeleteRequestDto request);
    }
}