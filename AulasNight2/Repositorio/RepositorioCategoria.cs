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

            if (categoria == null || categoria.Id == 0) throw new ArgumentException("Categoria inválida");

            CategoriaModel categoriaDB = _bancoContexto.Categorias.Find(categoria.Id);

            if (categoriaDB == null) throw new KeyNotFoundException("Categoria não encontrada");

            _bancoContexto.Entry(categoriaDB).CurrentValues.SetValues(categoria);
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

        public CategoriaModel Apagar(CategoriaModel categoria)
        {
            if (categoria == null || categoria.Id == 0) throw new ArgumentException("Produto inválido");

            CategoriaModel categoriaDB = _bancoContexto.Categorias.Find(categoria.Id);

            if (categoriaDB == null) throw new KeyNotFoundException("Produto não encontrado");

            _bancoContexto.Categorias.Remove(categoria);
            _bancoContexto.SaveChanges();
            return categoria;

        }
    }
}
