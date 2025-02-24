namespace AulasNight2.Models
{
    public class FornecedorModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string NIPC { get; set; }
        public required string Morada { get; set; }
        public required string Telefone { get; set; }
        public required string Email { get; set; }
    }
}
