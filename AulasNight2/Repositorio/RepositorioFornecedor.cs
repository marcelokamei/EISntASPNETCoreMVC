using AulasNight2.Data;
using AulasNight2.Models;

namespace AulasNight2.Repositorio
{
    public class RepositorioFornecedor : IRepositorioFornecedor
    {

        private readonly BancoContexto _bancoContexto;
        public RepositorioFornecedor(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }
        public FornecedorModel Adicionar(FornecedorModel fornecedor)
        {
            if (string.IsNullOrEmpty(fornecedor.Nome))
            {
                throw new ArgumentException("O nome do fornecedor não pode ser nula ou vazia.", nameof(fornecedor.Nome));
            }
            _bancoContexto.Fornecedor.Add(fornecedor);
            _bancoContexto.SaveChanges();
            return fornecedor;
        }

        public FornecedorModel Alterar(FornecedorModel fornecedor)
        {

            if (string.IsNullOrEmpty(fornecedor.Nome))
            {
                throw new ArgumentException("O nome do fornecedor não pode ser nula ou vazia.", nameof(fornecedor.Nome));
            }

            _bancoContexto.Fornecedor.Update(fornecedor);
            _bancoContexto.SaveChanges();
            return fornecedor;
        }

        public FornecedorModel ListarPorId(int Id)
        {
            return _bancoContexto.Fornecedor.FirstOrDefault(p => p.Id == Id);
        }

        public List<FornecedorModel> ObterTodosFornecedores()
        {
            return _bancoContexto.Fornecedor.ToList();
        }

    }
}
