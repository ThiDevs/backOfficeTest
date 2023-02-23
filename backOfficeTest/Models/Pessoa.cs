using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public TipoPessoa Tipo { get; set; }

        [Required]
        [MaxLength(14)]
        public string Documento { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string Apelido { get; set; }

        [Required]
        public Endereco Endereco { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public ICollection<QualificacaoPessoa> QualificacoesPessoa { get; set; }
    }
    public enum TipoPessoa
    {
        Fisica,
        Juridica
    }

}
