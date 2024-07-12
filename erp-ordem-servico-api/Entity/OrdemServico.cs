using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratorioDev.Entity
{
    [Table("ordem_servico")]
    public class OrdemServico
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Numero { get; set; }
        public string Descricao { get; set; }
    }
}