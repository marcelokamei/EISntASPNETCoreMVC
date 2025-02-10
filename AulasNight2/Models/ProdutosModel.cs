namespace AulasNight2.Models
{
    public class ProdutosModel
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Produto { get; set; }
        public string Descricao { get; set; }
        public int Qtd { get; set; }
        public int Categoria { get; set; }
        public decimal PrecoUnit { get; set; }
        public int Fornecedor { get; set; }
    }
}
