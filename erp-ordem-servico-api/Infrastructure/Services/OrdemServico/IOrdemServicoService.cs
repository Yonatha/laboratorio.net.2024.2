using erp_ordem_servico_api.Dto.OrdemServico;
using erp_ordem_servico_api.Presentation;

namespace erp_ordem_servico_api.Infrastructure.Services.OrdemServico
{
    public interface IOrdemServicoService
    {
        Task<Result<List<AtividadeResponseDto>>> GetAll();
        Task<Result<AtividadeResponseDto>> GetById(int id);
        Task<Result<AtividadeResponseDto>> Create(AtividadeRequestDto request);
        Task<Result<AtividadeResponseDto>> Delete(int id);
        Task<Result<AtividadeResponseDto>> Update(int id, string descricao);
        Task<Result<OrdemServicoDeleteResponseDto>> DeleteList(OrdemServicoDeleteRequestDto request);
    }
}