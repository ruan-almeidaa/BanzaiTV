using BanzaiTV.Interfaces;
using BanzaiTV.Models;
using Microsoft.AspNetCore.Mvc;

namespace BanzaiTV.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly IAdministradorService _administradorService;
        public AdministradorController(IAdministradorService administradorService)
        {
            _administradorService = administradorService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(AdministradorModel administradorModel)
        {
            try
            {
                return View("Login");
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
