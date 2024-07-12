using LaboratorioDev.Entity.Dto;
using LaboratorioDev.Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class OrdemServicoController : ControllerBase
    {
        private readonly IOrdemServicoService _service;

        public OrdemServicoController(IOrdemServicoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrdemServicoResponseDto>>> GetAll()
        {
            var ordensServico = await _service.GetAll();
            
            return Ok(ordensServico);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdemServicoResponseDto>> GetById(int id)
        {   
            var os = await _service.GetById(id);

            if (os == null)
                return NotFound();

            return Ok(os);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrdemServicoRequestDto request)
        {
            var os = await _service.Create(request);
            return Ok(os);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            // TODO implementar try catch
            var ordemServico = await _service.Delete(id);
            if (ordemServico == false)
                return NotFound();

            return NoContent();
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<OrdemServicoResponseDto>> Update( int id, [FromBody] OrdemServicoRequestDto request )
        {
            var os = await _service.Update(id, request.Descricao);

            if (os == null)
                return NotFound();
            
            return Ok(os);
        }

        [HttpPost("deleteList")]
        public async Task<ActionResult> DeleteList([FromBody] OrdemServicoDeleteRequestDto request)
        {
            var os = await _service.DeleteList(request);
            return Ok(os);  
        }
    }
}