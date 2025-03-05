using AulasNight2.Models;
using AulasNight2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AulasNight2.Controllers
{
    public class GestaoProdutosController : Controller
    {
        //--- INJEÇÃO DE DEPENDÊNCIA
        private readonly IRepositorioProdutos _produtoRepositorio;
        private readonly IRepositorioFornecedor _fornecedorRepositorio;
        private readonly IRepositorioCategoria _categoriaRepositorio;

        public GestaoProdutosController(IRepositorioProdutos produtoRepositorio, IRepositorioFornecedor fornecedorRepositorio, IRepositorioCategoria categoriaRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _fornecedorRepositorio = fornecedorRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
        }

        //--- AÇÕES RELACIONADAS AOS PRODUTOS
        public IActionResult Index()
        {
            List<ProdutosModel> produtos = _produtoRepositorio.ObterTodosProdutos();
            return View(produtos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int Id)
        {
            ProdutosModel produto = _produtoRepositorio.ListarPorId(Id);
            return View(produto);
        }

        public IActionResult Excluir(int id)
        {
            ProdutosModel produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        //--- AÇÕES RELACIONADAS ÀS CATEGORIAS
        public IActionResult Categorias()
        {
            List<CategoriaModel> categorias = _categoriaRepositorio.ObterTodasCategoria();
            return View(categorias);
        }

        public IActionResult CriarCategoria()
        {
            return View();
        }

        public IActionResult EditarCategoria(int Id)
        {
            CategoriaModel categoria = _categoriaRepositorio.ListarPorId(Id);
            return View(categoria);
        }
        public IActionResult ExcluirCategoria(int id)
        {
            CategoriaModel categoria = _categoriaRepositorio.ListarPorId(id);
            return View(categoria);
        }

        //--- AÇÕES RELACIONADAS AOS FORNECEDORES
        public IActionResult Fornecedores()
        {
            List<FornecedorModel> fornecedores = _fornecedorRepositorio.ObterTodosFornecedores();
            return View(fornecedores);
        }

        public IActionResult CriarFornecedores()
        {
            return View();
        }

        public IActionResult EditarFornecedor(int Id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorId(Id);
            return View(fornecedor);
        }

        public IActionResult ExcluirFornecedor(int id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }

        //--- MÉTODOS POST PRODUTOS
        [HttpPost]
        public IActionResult Criar(ProdutosModel novoProduto)
        {
            if (ModelState.IsValid)
            {
                _produtoRepositorio.Adicionar(novoProduto);
                return RedirectToAction("Index");
            }
            return View(novoProduto);

        }

        [HttpPost]
        public IActionResult Alterar(ProdutosModel produtoAlterado)
        {
            if (ModelState.IsValid)
            {
                _produtoRepositorio.Alterar(produtoAlterado);
                return RedirectToAction("Index");
            }
            return View(produtoAlterado);
        }
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirConfirmacao(int id)
        {
            ProdutosModel produto = _produtoRepositorio.ListarPorId(id);
            _produtoRepositorio.Apagar(produto);
            return RedirectToAction("Index");
        }

        //--- MÉTODOS POST CATEGORIAS
        [HttpPost]
        public IActionResult CriarCategoria(CategoriaModel novaCategoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepositorio.Adicionar(novaCategoria);
                return RedirectToAction("Categorias");
            }
            return View(novaCategoria);
        }
        [HttpPost]
        public IActionResult AlterarCategoria(CategoriaModel categoriaAlterada)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepositorio.Alterar(categoriaAlterada);
                return RedirectToAction("Categorias");
            }
            return View(categoriaAlterada);
        }

        [HttpPost, ActionName("ExcluirCategoria")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirCategoriaConfirmacao(int id)
        {
            CategoriaModel categoria = _categoriaRepositorio.ListarPorId(id);
            _categoriaRepositorio.Apagar(categoria);
            return RedirectToAction("Categorias");
        }


        //--- MÉTODOS POST FORNECEDORES
        [HttpPost]
        public IActionResult CriarFornecedores(FornecedorModel novoFornecedor)
        {
            if (ModelState.IsValid)
            {
                _fornecedorRepositorio.Adicionar(novoFornecedor);
                return RedirectToAction("Fornecedores");
            }
            return View(novoFornecedor);
        }
        [HttpPost]
        public IActionResult AlterarFornecedor(FornecedorModel fornecedorAlterado)
        {
            if (ModelState.IsValid)
            {
                _fornecedorRepositorio.Alterar(fornecedorAlterado);
                return RedirectToAction("Fornecedores");
            }
            return View(fornecedorAlterado);
        }
        [HttpPost, ActionName("ExcluirFornecedor")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirFornecedorConfirmacao(int id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorId(id);
            _fornecedorRepositorio.Apagar(fornecedor);
            return RedirectToAction("Fornecedores");
        }
    }
}
