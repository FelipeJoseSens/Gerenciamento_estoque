using System.ComponentModel.DataAnnotations;

namespace ConFinServer.Model
{
    public class Conta
    {
        [Key]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatório")]
        [StringLength(100
                     , MinimumLength = 2
                     , ErrorMessage = "Informe de 2 a 100 caracteres"
            )]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Data é obrigatório")]
        public DateTime Data {  get; set; }

        [Required(ErrorMessage = "Valor é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Tipo Conta é obrigatório")]
        public TipoConta Tipo { get; set; }

        [Required(ErrorMessage = "Situação é obrigatório")]
        public SituacaoConta Situacao { get; set; }

        [Required(ErrorMessage = "Pessoa é obrigatório")]
        public int PessoaCodigo { get; set; }

        public Pessoa? Pessoa { get; set; }
    }
}
