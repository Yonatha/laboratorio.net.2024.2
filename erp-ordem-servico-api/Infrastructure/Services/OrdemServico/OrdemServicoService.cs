using Microsoft.EntityFrameworkCore;
using AutoMapper;
using erp_ordem_servico_api.Dto.OrdemServico;
using erp_ordem_servico_api.Infrastructure.Persistence;
using erp_ordem_servico_api.Presentation;

namespace erp_ordem_servico_api.Infrastructure.Services.OrdemServico
{
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly ErpDbContext _context;
        private readonly IMapper _mapper;
        private readonly OrdemServicoAdapter _adapter;
        private readonly ILogger<OrdemServicoService> _logger;

        public OrdemServicoService(
            ErpDbContext context,
            IMapper mapper,
            OrdemServicoAdapter adapter,
            ILogger<OrdemServicoService> logger)
        {
            _context = context;
            _mapper = mapper;
            _adapter = adapter;
            _logger = logger;
        }

        public async Task<Result<List<AtividadeResponseDto>>> GetAll()
        {
            try
            {
                var ordensServico = await _context.OrdemServico.ToListAsync();

                var ordensServicoDto = ordensServico
                    .Select(os => _mapper.Map<AtividadeResponseDto>(os))
                    .ToList();

                return Result<List<AtividadeResponseDto>>.Success(ordensServicoDto);
            }
            catch (Exception ex)
            {
                var errorMessage = "Erro ao tentar obter os registros";
                _logger.LogError(ex, errorMessage);
                return Result<List<AtividadeResponseDto>>.Failure(errorMessage);
            }
        }

        public async Task<Result<AtividadeResponseDto>> GetById(int id)
        {
            try
            {
                var os = await _context.OrdemServico.FindAsync(id);

                if (os == null)
                {
                    var errorMessage = $"OrdemServico with id {id} not found.";
                    _logger.LogWarning(errorMessage);
                    return Result<AtividadeResponseDto>.Failure(errorMessage);
                }

                var ordemServicoDto = _mapper.Map<AtividadeResponseDto>(os);
                return Result<AtividadeResponseDto>.Success(ordemServicoDto);
            }
            catch (Exception ex)
            {
                var errorMessage = $"An error occurred while retrieving OrdemServico with id {id}.";
                _logger.LogError(ex, errorMessage);
                return Result<AtividadeResponseDto>.Failure(errorMessage);
            }
        }

        public async Task<Result<AtividadeResponseDto>> Create(AtividadeRequestDto request)
        {
            try
            {
                var os = _adapter.ToEntity(request);
                await _context.OrdemServico.AddAsync(os);
                await _context.SaveChangesAsync();

                var response = _mapper.Map<AtividadeResponseDto>(os);
                return Result<AtividadeResponseDto>.Success(response);
            }
            catch (Exception ex)
            {

                var errorMessage = $"Não foi possível cadastrar a Ordem de Serviço";
                _logger.LogError(ex, errorMessage);
                return Result<AtividadeResponseDto>.Failure(errorMessage);
            }
        }

        public async Task<Result<AtividadeResponseDto>> Delete(int id)
        {
            try
            {
                var os = await _context.OrdemServico.FindAsync(id);

                if (os == null)
                {
                    var errorMessage = $"OrdemServico with id {id} not found.";
                    _logger.LogWarning(errorMessage);
                    return Result<AtividadeResponseDto>.Failure(errorMessage);
                }

                _context.OrdemServico.Remove(os);
                await _context.SaveChangesAsync();

                var response = _mapper.Map<AtividadeResponseDto>(os);
                return Result<AtividadeResponseDto>.Success(response);
            }
            catch (Exception ex)
            {
                var errorMessage = $"An error occurred while deleting OrdemServico with id {id}.";
                _logger.LogError(ex, errorMessage);
                return Result<AtividadeResponseDto>.Failure(errorMessage);
            }
        }

        public async Task<Result<AtividadeResponseDto>> Update(int id, string descricao)
        {
            try
            {
                var os = await _context.OrdemServico.FirstOrDefaultAsync(o => o.Numero == id);

                if (os == null)
                {
                    var errorMessage = $"Ordem de serviço com número {id} não encontrada.";
                    _logger.LogWarning(errorMessage);
                    return Result<AtividadeResponseDto>.Failure(errorMessage);
                }

                os.Descricao = descricao;

                await _context.SaveChangesAsync();

                _logger.LogInformation($"Ordem de serviço com número {id} atualizada com sucesso.");

                var ordemServicoDto = _mapper.Map<AtividadeResponseDto>(os);
                return Result<AtividadeResponseDto>.Success(ordemServicoDto);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Erro ao tentar atualizar a ordem de serviço com número {id}.";
                _logger.LogError(ex, errorMessage);
                return Result<AtividadeResponseDto>.Failure(errorMessage);
            }
        }

        public async Task<Result<OrdemServicoDeleteResponseDto>> DeleteList(OrdemServicoDeleteRequestDto request)
        {
            try
            {
                var response = new OrdemServicoDeleteResponseDto();

                foreach (int numero in request.NumeroLista)
                {
                    var os = await _context.OrdemServico.FindAsync(numero);

                    if (os == null)
                    {
                        var errorMessage = $"Ordem de serviço {numero} não encontrada.";
                        _logger.LogWarning(errorMessage);
                        response.AddFailure(numero, errorMessage);
                        continue;
                    }

                    _context.OrdemServico.Remove(os);
                    await _context.SaveChangesAsync();

                    response.AddSuccess(numero);
                }

                return Result<OrdemServicoDeleteResponseDto>.Success(response);
            }
            catch (Exception ex)
            {
                var errorMessage = "Erro ao tentar excluir a lista de ordens de serviço.";
                _logger.LogError(ex, errorMessage);
                return Result<OrdemServicoDeleteResponseDto>.Failure(errorMessage);
            }
        }
    }
}