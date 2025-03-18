using Microsoft.AspNetCore.Mvc;

namespace AulasNight2.Controllers
{
    public class AutenticacaoController : Controller
    {
        public IActionResult VerificarCredenciais( string username, string password)
        {
            // simulacao de verificacao(substituir por chamada ao banco de dados)
            if (username == "admin" && password == "admin")
            {
                return Json(new {success = true}); //retorna um json com a propriedade sucess = true
            }
            else
            {
                return Json(new { success = false }); //retorna um json com a propriedade sucess = false

            }
        }
    }
}
