using System.ComponentModel.DataAnnotations;

namespace AulasNight2.Models
{
    public class ProdutosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira o SKU do produto")]
        [StringLength(20, ErrorMessage = "O SKU deve ter no máximo 20 caracteres")]
        public required string Sku { get; set; }

        [Required(ErrorMessage = "Insira o nome do produto")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do produto deve ter entre 3 e 100 caracteres")]
        public required string Produto { get; set; }

        [Required(ErrorMessage = "Insira a descrição do produto")]
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
        public required string Descricao { get; set; }

        [Required(ErrorMessage = "Insira a quantidade do produto")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade deve ser maior ou igual a zero.")]
        public int Qtd { get; set; }

        [Required(ErrorMessage = "Insira a categoria do produto")]
        public int Categoria { get; set; }

        [Required(ErrorMessage = "Insira o preço do produto")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior ou igual a zero.")]
        [DataType(DataType.Currency)]
        public decimal PrecoUnit { get; set; }

        [Required(ErrorMessage = "Insira o fornecedor do produto")]
        public int Fornecedor { get; set; }
    }
}

/*
 * DATA ANOTATIONS - validação
 * [Required] - Campo obrigatório
 * [StringLength(100, MinimumLength = 5)] - Tamanho máximo e mínimo
 * [Range(1, 100)] - Intervalo de valores
 * [EmailAddress] - E-mail válido
 * [Url] - URL válida
 * [Phone] - Telefone válido
 * [CreditCard] - Cartão de crédito válido
 * [RegularExpression("")] - Expressão regular
 * [Compare("Senha")] - Comparação de campos
 * 
 * DATA ANOTATIONS - formatação e exibição
 * [DataType(DataType.Date)] - Tipo de dado
 * [Display(Name = "Nome do Produto")] - Nome do campo
 * [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] - Formato de exibição
 * [DisplayFormat(DataFormatString = "{0:C}")] - Formato de exibição
 * [DisplayFormat(DataFormatString = "{0:P}")] - Formato de exibição
 * [DisplayFormat(DataFormatString = "{0:N}")] - Formato de exibição
 * [hiddenInput] - Campo oculto
 * 
 * DATA ANNONTATIONS - validações personalizadas
 * [CustomValidation(typeof(ProdutoValidation), "ValidarDescricao")] - Validação personalizada
 * [Remote("ValidarProduto", "Produto")] - Validação remota
 * [BindNever] - Não vincular
 * [BindRequired] - Vincular obrigatoriamente
 * [ScaffoldColumn(false)] - Não exibir na view
 */
