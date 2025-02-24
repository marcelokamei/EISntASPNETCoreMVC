namespace AulasNight2.Models
{
    public class ProdutosModel
    {
        public int Id { get; set; }
        public required string Sku { get; set; }
        public required string Produto { get; set; }
        public required string Descricao { get; set; }
        public int Qtd { get; set; }
        public int Categoria { get; set; }
        public decimal PrecoUnit { get; set; }
        public int Fornecedor { get; set; }
    }
}
