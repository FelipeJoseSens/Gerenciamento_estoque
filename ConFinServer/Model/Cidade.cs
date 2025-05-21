using System.ComponentModel.DataAnnotations;

namespace ConFinServer.Model
{
    public class Cidade
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100
                     , MinimumLength = 2
                     , ErrorMessage = "Informe de 2 a 100 caracteres"
            )]
        public string Nome { get; set; }

        [StringLength(2
                     , MinimumLength = 2
                    , ErrorMessage = "Obrigatório informar 2 caracteres")]
        [Required(ErrorMessage = "Estado é obrigatório")]
        public string EstadoSigla { get; set; }

        public Estado? Estado { get; set; }
    }
}
