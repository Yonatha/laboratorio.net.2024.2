using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace erp_ordem_servico_api.Domain.Entities
{
    [Table("atividades")]
    public class Atividade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}