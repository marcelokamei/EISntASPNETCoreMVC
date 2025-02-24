using AulasNight2.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace AulasNight2.Data
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options ) : base (options)
        {            
        }

        public DbSet<ProdutosModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<FornecedorModel> Fornecedor { get; set; }
    }
}
