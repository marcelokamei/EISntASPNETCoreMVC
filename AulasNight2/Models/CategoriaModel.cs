using System.ComponentModel.DataAnnotations;

namespace AulasNight2.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira o nome da categoria")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da categoria deve ter entre 3 e 100 caracteres")]
        public required string Nome { get; set; }
    }
}
