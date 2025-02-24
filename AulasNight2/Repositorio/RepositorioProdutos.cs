using AulasNight2.Data;
using AulasNight2.Models;

namespace AulasNight2.Repositorio
{
    public class RepositorioProdutos : IRepositorioProdutos
    {
        private readonly BancoContexto _bancoContexto;

        public RepositorioProdutos(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public ProdutosModel Adicionar(ProdutosModel produto)
        {

            if (string.IsNullOrEmpty(produto.Produto))
            {
                throw new ArgumentException("O nome do produto não pode ser nula ou vazia.", nameof(produto.Produto));
            }

            _bancoContexto.Produtos.Add(produto);
            _bancoContexto.SaveChanges();
            return produto;
        }

        public ProdutosModel Alterar(ProdutosModel produto)
        {
            if (produto == null || produto.Id == 0) throw new ArgumentException("Produto inválido");

            ProdutosModel produtoDB = _bancoContexto.Produtos.Find(produto.Id);

            if (produtoDB == null) throw new KeyNotFoundException("Produto não encontrado");

            _bancoContexto.Entry(produtoDB).CurrentValues.SetValues(produto);
            _bancoContexto.SaveChanges();
            return produto;
        }

        public ProdutosModel ListarPorId(int Id)
        {
            return _bancoContexto.Produtos.FirstOrDefault(p => p.Id == Id);
        }

        public List<ProdutosModel> ObterTodosProdutos()
        {
            return _bancoContexto.Produtos.ToList();
        }
    }
}
