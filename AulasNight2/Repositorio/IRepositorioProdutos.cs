using AulasNight2.Models;

namespace AulasNight2.Repositorio
{
    public interface IRepositorioProdutos
    {

        List<ProdutosModel> ObterTodosProdutos();

        ProdutosModel Adicionar(ProdutosModel produto);
        ProdutosModel Alterar(ProdutosModel produto);
        ProdutosModel ListarPorId(int Id);
        ProdutosModel Apagar(ProdutosModel produto);

    }
}
