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
        private readonly AtividadeAdapter _adapter;
        private readonly ILogger<OrdemServicoService> _logger;

        public OrdemServicoService(
            ErpDbContext context,
            IMapper mapper,
            AtividadeAdapter adapter,
            ILogger<OrdemServicoService> logger)
        {
            _context = context;
            _mapper = mapper;
            _adapter = adapter;
            _logger = logger;
        }

        public async Task<Result<List<OrdemServicoResponse>>> GetAll()
        {
            try
            {
                var ordensServico = await _context.OrdemServico.ToListAsync();

                var ordensServicoDto = ordensServico
                    .Select(os => _mapper.Map<OrdemServicoResponse>(os))
                    .ToList();

                return Result<List<OrdemServicoResponse>>.Success(ordensServicoDto);
            }
            catch (Exception ex)
            {
                var errorMessage = "Erro ao tentar obter os registros";
                _logger.LogError(ex, errorMessage);
                return Result<List<OrdemServicoResponse>>.Failure(errorMessage);
            }
        }

        public async Task<Result<OrdemServicoResponse>> GetById(int id)
        {
            try
            {
                var os = await _context.OrdemServico.FindAsync(id);

                if (os == null)
                {
                    var errorMessage = $"OrdemServico with id {id} not found.";
                    _logger.LogWarning(errorMessage);
                    return Result<OrdemServicoResponse>.Failure(errorMessage);
                }

                var ordemServicoDto = _mapper.Map<OrdemServicoResponse>(os);
                return Result<OrdemServicoResponse>.Success(ordemServicoDto);
            }
            catch (Exception ex)
            {
                var errorMessage = $"An error occurred while retrieving OrdemServico with id {id}.";
                _logger.LogError(ex, errorMessage);
                return Result<OrdemServicoResponse>.Failure(errorMessage);
            }
        }

        public async Task<Result<OrdemServicoResponse>> Create(OrdemServicoRequest request)
        {
            try
            {
                var os = _adapter.ToEntity(request);
                await _context.OrdemServico.AddAsync(os);
                await _context.SaveChangesAsync();

                var response = _mapper.Map<OrdemServicoResponse>(os);
                return Result<OrdemServicoResponse>.Success(response);
            }
            catch (Exception ex)
            {

                var errorMessage = $"N�o foi poss�vel cadastrar a Ordem de Servi�o";
                _logger.LogError(ex, errorMessage);
                return Result<OrdemServicoResponse>.Failure(errorMessage);
            }
        }

        public async Task<Result<OrdemServicoResponse>> Delete(int id)
        {
            try
            {
                var os = await _context.OrdemServico.FindAsync(id);

                if (os == null)
                {
                    var errorMessage = $"OrdemServico with id {id} not found.";
                    _logger.LogWarning(errorMessage);
                    return Result<OrdemServicoResponse>.Failure(errorMessage);
                }

                _context.OrdemServico.Remove(os);
                await _context.SaveChangesAsync();

                var response = _mapper.Map<OrdemServicoResponse>(os);
                return Result<OrdemServicoResponse>.Success(response);
            }
            catch (Exception ex)
            {
                var errorMessage = $"An error occurred while deleting OrdemServico with id {id}.";
                _logger.LogError(ex, errorMessage);
                return Result<OrdemServicoResponse>.Failure(errorMessage);
            }
        }

        public async Task<Result<OrdemServicoResponse>> Update(int id, string descricao)
        {
            try
            {
                var os = await _context.OrdemServico.FirstOrDefaultAsync(o => o.Numero == id);

                if (os == null)
                {
                    var errorMessage = $"Ordem de servi�o com n�mero {id} n�o encontrada.";
                    _logger.LogWarning(errorMessage);
                    return Result<OrdemServicoResponse>.Failure(errorMessage);
                }

                os.Descricao = descricao;

                await _context.SaveChangesAsync();

                _logger.LogInformation($"Ordem de servi�o com n�mero {id} atualizada com sucesso.");

                var ordemServicoDto = _mapper.Map<OrdemServicoResponse>(os);
                return Result<OrdemServicoResponse>.Success(ordemServicoDto);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Erro ao tentar atualizar a ordem de servi�o com n�mero {id}.";
                _logger.LogError(ex, errorMessage);
                return Result<OrdemServicoResponse>.Failure(errorMessage);
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
                        var errorMessage = $"Ordem de servi�o {numero} n�o encontrada.";
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
                var errorMessage = "Erro ao tentar excluir a lista de ordens de servi�o.";
                _logger.LogError(ex, errorMessage);
                return Result<OrdemServicoDeleteResponseDto>.Failure(errorMessage);
            }
        }
    }
}