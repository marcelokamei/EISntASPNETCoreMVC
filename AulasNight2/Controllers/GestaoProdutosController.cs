using AulasNight2.Models;
using AulasNight2.Repositorio;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult ApagarConfirmacao()
        {
            return View();
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

        //--- MÉTODOS POST PRODUTOS
        [HttpPost]
        public IActionResult Criar(ProdutosModel novoProduto)
        {
            _produtoRepositorio.Adicionar(novoProduto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(ProdutosModel produtoAlterado)
        {
            _produtoRepositorio.Alterar(produtoAlterado);
            return RedirectToAction("Index");
        }

        //--- MÉTODOS POST CATEGORIAS
        [HttpPost]
        public IActionResult CriarCategoria(CategoriaModel novaCategoria)
        {
            _categoriaRepositorio.Adicionar(novaCategoria);
            return RedirectToAction("Categorias");
        }
        [HttpPost]
        public IActionResult AlterarCategoria(CategoriaModel categoriaAlterada)
        {
            _categoriaRepositorio.Alterar(categoriaAlterada);
            return RedirectToAction("Categorias");
        }


        //--- MÉTODOS POST FORNECEDORES
        [HttpPost]
        public IActionResult CriarFornecedores(FornecedorModel novoFornecedor)
        {
            _fornecedorRepositorio.Adicionar(novoFornecedor);
            return RedirectToAction("Fornecedores");
        }
        [HttpPost]
        public IActionResult AlterarFornecedor(FornecedorModel fornecedorAlterado)
        {
            _fornecedorRepositorio.Alterar(fornecedorAlterado);
            return RedirectToAction("Fornecedores");
        }
    }
}
