using BanzaiTV.Interfaces;
using BanzaiTV.Models;
using Microsoft.AspNetCore.Mvc;

namespace BanzaiTV.Controllers
{
    public class PlanoController : Controller
    {
        
        private readonly IPlanoService _planoService;
        public PlanoController(IPlanoService planoService)
        {
            _planoService = planoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(PlanoModel plano)
        {
            try
            {
                _planoService.Cadastrar(plano);
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
