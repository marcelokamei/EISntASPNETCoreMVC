using Microsoft.AspNetCore.Mvc;

namespace AulasNight2.Controllers
{
    public class GestaoProdutosController : Controller
    {

        //--- AÇÕES RELACIONADAS AOS PRODUTOS
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }



        //--- AÇÕES RELACIONADAS ÀS CATEGORIAS
        public IActionResult Categorias()
        {
            return View();
        }

        public IActionResult CriarCategoria()
        {
            return View();
        }

        public IActionResult EditarCategoria()
        {
            return View();
        }


        //--- AÇÕES RELACIONADAS AOS FORNECEDORES
        public IActionResult Fornecedores()
        {
            return View();
        }

        public IActionResult CriarFornecedores()
        {
            return View();
        }

        public IActionResult EditarFornecedor()
        {
            return View();
        }

    }
}
