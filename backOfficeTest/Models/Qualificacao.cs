using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Models
{
    public class Qualificacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required]
        public TipoQualificacao Tipo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }

    public enum TipoQualificacao
    {
        Cliente,
        Fornecedor,
        Colaborador
    }

}
