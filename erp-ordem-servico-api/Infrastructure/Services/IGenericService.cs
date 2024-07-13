using AutoMapper;
using erp_ordem_servico_api.Infrastructure.Persistence.Repositories;
using erp_ordem_servico_api.Presentation;

namespace erp_ordem_servico_api.Infrastructure.Services
{
    public interface IGenericService<TRequestDto, TResponseDto, TEntity>
    {
        Task<Result<List<TResponseDto>>> GetAll();
        Task<Result<TResponseDto>> GetById(int id);
        Task<Result<TResponseDto>> Create(TRequestDto request);
        Task<Result<TResponseDto>> Update(int id, TRequestDto request);
        Task<Result<bool>> Delete(int id);
    }

    public class GenericService<TRequestDto, TResponseDto, TEntity> : IGenericService<TRequestDto, TResponseDto, TEntity>
        where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<List<TResponseDto>>> GetAll()
        {
            var entities = await _repository.GetAll();
            var dtos = _mapper.Map<List<TResponseDto>>(entities);
            return Result<List<TResponseDto>>.Success(dtos);
        }

        public async Task<Result<TResponseDto>> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
                return Result<TResponseDto>.NotFound();

            var dto = _mapper.Map<TEntity, TResponseDto>(entity);
            return Result<TResponseDto>.Success(dto);
        }

        public async Task<Result<TResponseDto>> Create(TRequestDto request)
        {
            var entity = _mapper.Map<TRequestDto, TEntity>(request);
            entity = await _repository.Create(entity);
            var dto = _mapper.Map<TEntity, TResponseDto>(entity);
            return Result<TResponseDto>.Success(dto);
        }

        public async Task<Result<TResponseDto>> Update(int id, TRequestDto request)
        {
            var entity = _mapper.Map<TRequestDto, TEntity>(request);
            entity = await _repository.Update(id, entity);
            var dto = _mapper.Map<TEntity, TResponseDto>(entity);
            return Result<TResponseDto>.Success(dto);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
                return Result<bool>.NotFound();

            await _repository.Delete(id);
            return Result<bool>.Success(true);
        }
    }
}