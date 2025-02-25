using AulasNight2.Models;

namespace AulasNight2.Repositorio
{
    public interface IRepositorioFornecedor
    {
        List<FornecedorModel> ObterTodosFornecedores();

        FornecedorModel Adicionar(FornecedorModel fornecedor);
        FornecedorModel Alterar(FornecedorModel fornecedor);
        FornecedorModel ListarPorId(int Id);
        FornecedorModel Apagar(FornecedorModel fornecedor);
    }
}
