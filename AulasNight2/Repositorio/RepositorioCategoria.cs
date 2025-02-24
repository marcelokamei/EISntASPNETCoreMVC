using AulasNight2.Data;
using AulasNight2.Models;

namespace AulasNight2.Repositorio
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        private readonly BancoContexto _bancoContexto;
        public RepositorioCategoria(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }
        public CategoriaModel Adicionar(CategoriaModel categoria)
        {
            if (string.IsNullOrEmpty(categoria.Nome))
            {
                throw new ArgumentException("O nome da categoria não pode ser nula ou vazia.", nameof(categoria.Nome));
            }
            _bancoContexto.Categorias.Add(categoria);
            _bancoContexto.SaveChanges();
            return categoria;
        }

        public CategoriaModel Alterar(CategoriaModel categoria)
        {

            if (string.IsNullOrEmpty(categoria.Nome))
            {
                throw new ArgumentException("O nome da categoria não pode ser nula ou vazia.", nameof(categoria.Nome));
            }

            _bancoContexto.Categorias.Update(categoria);
            _bancoContexto.SaveChanges();
            return categoria;
        }

        public CategoriaModel ListarPorId(int Id)
        {
            return _bancoContexto.Categorias.FirstOrDefault(p => p.Id == Id);
        }

        public List<CategoriaModel> ObterTodasCategoria()
        {
            return _bancoContexto.Categorias.ToList();
        }
    }
}
