using AulasNight2.Models;

namespace AulasNight2.Repositorio
{
    public interface IRepositorioCategoria
    {
        List<CategoriaModel> ObterTodasCategoria();

        CategoriaModel Adicionar(CategoriaModel categoria);
        CategoriaModel Alterar(CategoriaModel categoria);
        CategoriaModel ListarPorId(int Id);
    }
}
