using System.ComponentModel.DataAnnotations;

namespace chamadosTeste.Models
{
    public class Chamado
    {
        [Key]
        public int codigo { get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public System.DateTime dataInicio { get; set; }

        public System.DateTime dataFim { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(7, ErrorMessage = "Este campo deve conter exatamente 7 caracteres")]
        [MinLength(7, ErrorMessage = "Este campo deve conter exatamente 7 caracteres")]
        public string veiculo { get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(25, ErrorMessage = "Este campo deve conter no máximo 25 caracteres")]
        [MinLength(5, ErrorMessage = "Este campo deve conter no mínimo 7 caracteres")]
        public string operador { get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public System.Boolean finalizado { get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int quantidadeAcoes { get; set;}

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Ação Inválida")]
        public int acoesId { get; set;}

        public Acoes Acoes { get; set; }
    }
}