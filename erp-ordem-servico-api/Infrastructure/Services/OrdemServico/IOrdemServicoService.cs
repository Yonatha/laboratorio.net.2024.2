using erp_ordem_servico_api.Dto.OrdemServico;
using erp_ordem_servico_api.Presentation;

namespace erp_ordem_servico_api.Infrastructure.Services.OrdemServico
{
    public interface IOrdemServicoService
    {
        Task<Result<List<OrdemServicoResponse>>> GetAll();
        Task<Result<OrdemServicoResponse>> GetById(int id);
        Task<Result<OrdemServicoResponse>> Create(OrdemServicoRequest request);
        Task<Result<OrdemServicoResponse>> Delete(int id);
        Task<Result<OrdemServicoResponse>> Update(int id, string descricao);
        Task<Result<OrdemServicoDeleteResponseDto>> DeleteList(OrdemServicoDeleteRequestDto request);
    }
}