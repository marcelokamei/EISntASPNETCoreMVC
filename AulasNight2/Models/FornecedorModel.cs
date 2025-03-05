using System.ComponentModel.DataAnnotations;

namespace AulasNight2.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o nome do fornecedor")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do fornecedor deve ter entre 3 e 100 caracteres")]
        public required string Nome { get; set; }
        [Required(ErrorMessage = "Insira o NIPC do fornecedor")]
        public required string NIPC { get; set; }
        [Required(ErrorMessage = "Insira a morada do fornecedor")]
        [StringLength(500, ErrorMessage = "A morada deve ter no máximo 500 caracteres")]
        public required string Morada { get; set; }
        [Phone(ErrorMessage = "Número de telefone inválido.")]
        public required string Telefone { get; set; }
        [Required(ErrorMessage = "Insira o e-mail do fornecedor")]
        public required string Email { get; set; }
    }
}
