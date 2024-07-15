using erp_ordem_servico_api.Domain.Entities;
using erp_ordem_servico_api.Dto.OrdemServico;
using erp_ordem_servico_api.Infrastructure.Services;
using LaboratorioDev.Dto.Atividade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace erp_ordem_servico_api.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtividadeController : ControllerBase
    {
        private readonly ILogger<AtividadeController> _logger;
        private readonly IGenericService<AtividadeRequest, AtividadeResponse, AtividadeEntity> _service;

        public AtividadeController(IGenericService<AtividadeRequest, AtividadeResponse, AtividadeEntity> service, ILogger<AtividadeController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<AtividadeResponse>>> GetAll()
        {
            try
            {
                var response = await _service.GetAll();

                if (!response.IsSuccess)
                    return NoContent();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter registros.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AtividadeRequest request)
        {
            try
            {
                var os = await _service.Create(request);
                return Created(string.Empty, os);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"N�o foi poss�vel cadastrar.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AtividadeResponse>> GetById(int id)
        {
            try
            {
                var os = await _service.GetById(id);
                if (os == null)
                    return NotFound();

                return Ok(os);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao obter o registro {id}.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _service.Delete(id);
                if (!response.IsSuccess)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"N�o foi poss�vel deletar o registro {id}.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AtividadeResponse>> Update(int id, [FromBody] AtividadeRequest request)
        {
            try
            {
                var os = await _service.Update(id, request);

                if (os == null)
                    return NotFound();

                return Ok(os);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao tentar atualizar a OS {id}.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }
    }
}