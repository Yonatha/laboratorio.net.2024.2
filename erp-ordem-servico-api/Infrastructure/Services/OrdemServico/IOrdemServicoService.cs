using erp_ordem_servico_api.Dto.OrdemServico;
using erp_ordem_servico_api.Presentation;

namespace erp_ordem_servico_api.Infrastructure.Services.OrdemServico
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