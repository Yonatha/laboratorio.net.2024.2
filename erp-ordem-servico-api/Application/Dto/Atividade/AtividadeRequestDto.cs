using System.ComponentModel.DataAnnotations;

namespace LaboratorioDev.Dto.Atividade
{
    public class AtividadeRequestDto
    {
        [Required(ErrorMessage = "A descrição deve ser informada")]
        [MinLength(3, ErrorMessage = "A descrição deve ter no mínimo 3 caracteres.")]
        public string? Descricao { get; set; }
    }
}