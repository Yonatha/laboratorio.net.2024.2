using LaboratorioDev.Entity.Dto;
using LaboratorioDev.Entity;
using LaboratorioDev.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LaboratorioDev.Services
{
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly ErpDbContext  _context;
        private readonly IMapper _mapper;
        private readonly OrdemServicoAdapter _adapter;
        
        public OrdemServicoService(ErpDbContext context, IMapper mapper, OrdemServicoAdapter adapter)
        {
            _context = context;
            _mapper = mapper;
            _adapter = adapter;
        }

        public async Task<List<OrdemServicoResponseDto>> GetAll()
        {
            var ordensServico = await _context.OrdemServico.ToListAsync();
            return ordensServico.Select(os => _mapper.Map<OrdemServicoResponseDto>(os)).ToList();
        }

        public async Task<OrdemServicoResponseDto> GetById(int id)
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
            var response = new OrdemServicoDeleteResponseDto();

            foreach (int numero in request.NumeroLista)
            {
                var os = await _context.OrdemServico.FindAsync(numero);
                if (! await hasFail(os, numero, response)){
                    performSucessoAction(os, numero, response);
                }
            }
            return response;  
        }


        public async Task<bool> hasFail(OrdemServico os, int numero, OrdemServicoDeleteResponseDto response)
        {
            if (os == null) {
                response.falha.Add(numero);
                return true;
            }

            return false;
        }

        public async Task<List<int>> performSucessoAction(OrdemServico os, int numero, OrdemServicoDeleteResponseDto response)
        {
            _context.OrdemServico.Remove(os);
            await _context.SaveChangesAsync();

            if (response == null)
                response = new OrdemServicoDeleteResponseDto();

            if (response.sucesso == null)
                response.sucesso = new List<int>();

            response.sucesso.Add(numero);

            return response.sucesso;
        }
    }
}