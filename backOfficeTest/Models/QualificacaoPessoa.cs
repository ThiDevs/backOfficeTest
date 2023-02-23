using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Models
{
    public class QualificacaoPessoa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int pessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        [Required]
        public int qualificacaoId { get; set; }
        public Qualificacao Qualificacao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}

