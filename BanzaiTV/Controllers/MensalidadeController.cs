using Microsoft.AspNetCore.Mvc;

namespace BanzaiTV.Controllers
{
    public class MensalidadeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
