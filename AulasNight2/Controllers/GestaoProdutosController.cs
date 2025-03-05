using AulasNight2.Models;
using AulasNight2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
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
            ViewBag.Categorias = _categoriaRepositorio.ObterTodasCategoria();
            ViewBag.Fornecedores = _fornecedorRepositorio.ObterTodosFornecedores();
            return View();
        }

        public IActionResult Editar(int Id)
        {
            ProdutosModel produto = _produtoRepositorio.ListarPorId(Id);
            ViewBag.Categorias = _categoriaRepositorio.ObterTodasCategoria();
            ViewBag.Fornecedores = _fornecedorRepositorio.ObterTodosFornecedores();

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
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.Adicionar(novoProduto);
                    TempData["Mensagem"] = "Produto cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(novoProduto);
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = $"Ops. Não foi possível adicionar o produto. Tente Novamente. Erro: {ex.Message}";
                return View(novoProduto);
            }
        }

        [HttpPost]
        public IActionResult Alterar(ProdutosModel produtoAlterado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _produtoRepositorio.Alterar(produtoAlterado);
                    TempData["Mensagem"] = "Produto alterar com sucesso!";

                    return RedirectToAction("Index");
                }
                return View(produtoAlterado);
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = $"Ops. Não foi possível alterar o produto. Tente Novamente. Erro: {ex.Message}";
                return View(produtoAlterado);
            }
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirConfirmacao(int id)
        {
            try
            {
                ProdutosModel produto = _produtoRepositorio.ListarPorId(id);
                _produtoRepositorio.Apagar(produto);
                TempData["Mensagem"] = "Produto excluído com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = $"Ops. Não foi possível apagar o produto. Tente Novamente. Erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        //--- MÉTODOS POST CATEGORIAS
        [HttpPost]
        public IActionResult CriarCategoria(CategoriaModel novaCategoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoriaRepositorio.Adicionar(novaCategoria);
                    TempData["Mensagem"] = "Categoria cadastrada com sucesso!";
                    return RedirectToAction("Categorias");
                }
                return View(novaCategoria);
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = $"Ops. Não foi possível adicionar a categoria. Tente Novamente. Erro: {ex.Message}";
                return View(novaCategoria);
            }
        }
        [HttpPost]
        public IActionResult AlterarCategoria(CategoriaModel categoriaAlterada)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoriaRepositorio.Alterar(categoriaAlterada);
                    TempData["Mensagem"] = "Categoria alterada com sucesso!";
                    return RedirectToAction("Categorias");
                }
                return View(categoriaAlterada);
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = $"Ops. Não foi possível alterar a categoria. Tente Novamente. Erro: {ex.Message}";
                return View(categoriaAlterada);
            }
        }

        [HttpPost, ActionName("ExcluirCategoria")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirCategoriaConfirmacao(int id)
        {
            try
            {
                CategoriaModel categoria = _categoriaRepositorio.ListarPorId(id);
                _categoriaRepositorio.Apagar(categoria);
                TempData["Mensagem"] = "Categoria excluída com sucesso!";
                return RedirectToAction("Categorias");
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = $"Ops. Não foi possível apagar a categoria. Tente Novamente. Erro: {ex.Message}";
                return RedirectToAction("Categorias");
            }
        }


        //--- MÉTODOS POST FORNECEDORES
        [HttpPost]
        public IActionResult CriarFornecedores(FornecedorModel novoFornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fornecedorRepositorio.Adicionar(novoFornecedor);
                    TempData["Mensagem"] = "Fornecedor cadastrado com sucesso!";
                    return RedirectToAction("Fornecedores");
                }
                return View(novoFornecedor);
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = $"Ops. Não foi possível adicionar o fornecedor. Tente Novamente. Erro: {ex.Message}";
                return View(novoFornecedor);
            }
        }
        [HttpPost]
        public IActionResult AlterarFornecedor(FornecedorModel fornecedorAlterado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fornecedorRepositorio.Alterar(fornecedorAlterado);
                    TempData["Mensagem"] = "Fornecedor alterado com sucesso!";
                    return RedirectToAction("Fornecedores");
                }
                return View(fornecedorAlterado);
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = $"Ops. Não foi possível alterar o fornecedor. Tente Novamente. Erro: {ex.Message}";
                return View(fornecedorAlterado);
            }
        }
        [HttpPost, ActionName("ExcluirFornecedor")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirFornecedorConfirmacao(int id)
        {
            try
            {
                FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorId(id);
                _fornecedorRepositorio.Apagar(fornecedor);
                TempData["Mensagem"] = "Fornecedor excluído com sucesso!";
                return RedirectToAction("Fornecedores");
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = $"Ops. Não foi possível apagar o fornecedor. Tente Novamente. Erro: {ex.Message}";
                return RedirectToAction("Fornecedores");
            }
        }
    }
}

