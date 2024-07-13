using erp_ordem_servico_api.Dto.Atividade;
using erp_ordem_servico_api.Presentation;

namespace erp_ordem_servico_api.Infrastructure.Services
{
    public class ClienteService : IService<AtividadeRequestDto, AtividadeResponseDto>
    {
        public async Task<Result<List<AtividadeResponseDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Result<AtividadeResponseDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<AtividadeResponseDto>> Create(AtividadeRequestDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<AtividadeResponseDto>> Update(int id, AtividadeRequestDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }

}
