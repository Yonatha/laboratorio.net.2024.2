using LaboratorioDev.Entity.Dto;
using LaboratorioDev.Entity;
using LaboratorioDev.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace LaboratorioDev.Services
{
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly ErpDbContext  _context;
        private readonly IMapper _mapper;
        private readonly OrdemServicoAdapter _adapter;
        private OrdemServicoDeleteResponseDto _response;
        
        public OrdemServicoService(ErpDbContext context, IMapper mapper, OrdemServicoAdapter adapter)
        {
            _context = context;
            _mapper = mapper;
            _adapter = adapter;

            _response = new OrdemServicoDeleteResponseDto();
        }

        public async Task<List<OrdemServicoResponseDto>> GetAll()
        {
            var ordensServico = await _context.OrdemServico.ToListAsync();
            return ordensServico.Select(os => _mapper.Map<OrdemServicoResponseDto>(os)).ToList();
        }

        public async Task<OrdemServico> GetById(int id)
        {   
            var os = await _context.OrdemServico.FindAsync(id);
            return _adapter.ToDto(os);
        }

        public async Task<OrdemServicoResponseDto> Create(OrdemServicoRequestDto request)
        {

            var os = _adapter.ToEntity(request);
            await _context.OrdemServico.AddAsync(os);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrdemServicoResponseDto>(os);
        }

        public async Task<bool> Delete(int id)
        {
            var ordemServico = await _context.OrdemServico.FindAsync(id);

            if (ordemServico != null)
            {
                _context.OrdemServico.Remove(ordemServico);
                await _context.SaveChangesAsync();
                return true;
            };

            return false;  
        }

        public async Task<OrdemServicoResponseDto> Update(int id, string descricao)
        {
            var os = await GetById(id);
            if (os != null)
            {
                os.Descricao = descricao;
                await _context.SaveChangesAsync();    
            }

            return _mapper.Map<OrdemServicoResponseDto>(os);
        }

        public async Task<OrdemServicoDeleteResponseDto> DeleteList(OrdemServicoDeleteRequestDto request)
        {   
            foreach (int numeroOs in request.NumeroLista)
            {
                if (!performFalhaAction(OrdemServico ordemServico, numeroOs)){
                    performSucessoAction(ordemServico, numeroOs);
                }
            }
            return _response;  
        }


        public async Task<bool> hasFail(OrdemServico ordemServico, numeroOs)
        {
            var ordemServico = await _context.OrdemServico.FindAsync(numeroOs);
            if (ordemServico == null) {
                _response.falha.Add(numeroOs);
                return true
            }

            return false;
        }

        public async Task performSucessoAction(OrdemServico ordemServico, numeroOs)
        {
            _context.OrdemServico.Remove(ordemServico);
            await _context.SaveChangesAsync();
            return _response.sucesso.Add(numeroOs);
        }
    }
}