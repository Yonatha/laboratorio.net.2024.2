using erp_ordem_servico_api.Presentation;

namespace erp_ordem_servico_api.Infrastructure.Services
{
    public interface IService<TRequestDto, TResponseDto>
    {
        Task<Result<List<TResponseDto>>> GetAll();
        Task<Result<TResponseDto>> GetById(int id);
        Task<Result<TResponseDto>> Create(TRequestDto request);
        Task<Result<TResponseDto>> Update(int id, TRequestDto request);
        Task<Result<bool>> Delete(int id);
    }
}
