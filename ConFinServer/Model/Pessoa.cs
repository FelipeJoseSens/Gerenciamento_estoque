using System.ComponentModel.DataAnnotations;

namespace ConFinServer.Model
{
    public class Pessoa
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100
                     , MinimumLength = 2
                     , ErrorMessage = "Informe de 2 a 100 caracteres"
            )]
        public string Nome { get; set; }

        public int Idade { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório")]
        public int CidadeCodigo { get; set; }

        public Cidade? Cidade { get; set; }
    }
}
