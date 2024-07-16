using erp_ordem_servico_api.Dto.OrdemServico;
using erp_ordem_servico_api.Infrastructure.Services.OrdemServico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace erp_ordem_servico_api.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OrdemServicoController : ControllerBase
    {
        private readonly IOrdemServicoService _service;
        private readonly ILogger<OrdemServicoController> _logger;

        public OrdemServicoController(
            IOrdemServicoService service,
            ILogger<OrdemServicoController> logger
        )
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        //[Authorize (Roles = "BusinessGroup")]
        [Authorize(Policy = "BusinessGroup")]
        public async Task<ActionResult<List<OrdemServicoResponse>>> GetAll()
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
                _logger.LogError(ex, "Erro ao obter ordens de servi�o.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdemServicoResponse>> GetById(int id)
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
                _logger.LogError(ex, $"Erro ao obter ordens de servi�o {id}.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrdemServicoRequest request)
        {
            try
            {
                var os = await _service.Create(request);
                return Ok(os);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"N�o foi poss�vel cadastrar a OS.");
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
                _logger.LogError(ex, $"N�o foi poss�vel deletar a OS {id}.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrdemServicoResponse>> Update(int id, [FromBody] OrdemServicoRequest request)
        {
            try
            {
                var os = await _service.Update(id, request.Descricao);

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

        [HttpPost("deleteList")]
        public async Task<ActionResult> DeleteList([FromBody] OrdemServicoDeleteRequestDto request)
        {
            try
            {

                var os = await _service.DeleteList(request);
                return Ok(os);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao tentar realizar a opera��o ");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }
    }
}