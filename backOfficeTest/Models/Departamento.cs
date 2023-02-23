using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Models
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        [Required]
        public int ResponsavelId { get; set; }
        [ForeignKey("ResponsavelId")]
        public Pessoa Responsavel { get; set; }
    }
}
