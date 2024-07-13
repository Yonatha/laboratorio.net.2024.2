using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace erp_ordem_servico_api.Domain.Entities
{
    [Table("ordem_servico")]
    public class OrdemServicoEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Numero { get; set; }
        public string Descricao { get; set; }
    }
}