using System.ComponentModel.DataAnnotations;

namespace erp_ordem_servico_api.Dto.Atividade
{
    public class AtividadeRequestDto
    {
        [Required(ErrorMessage = "A descrição deve ser informada")]
        [MinLength(3, ErrorMessage = "A descrição deve ter no mínimo 3 caracteres.")]
        public string Descricao { get; set; }
    }
}