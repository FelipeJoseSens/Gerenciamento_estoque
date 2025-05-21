using System.ComponentModel.DataAnnotations;

namespace ConFinServer.Model
{
    public class Estado
    {
        [Key]
        [StringLength(2
                     ,MinimumLength = 2
                    ,ErrorMessage = "Obrigatório informar 2 caracteres")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100
                     , MinimumLength = 2
                     , ErrorMessage = "Informe de 2 a 100 caracteres"
            )]
        public string Nome { get; set; }

    }
}
