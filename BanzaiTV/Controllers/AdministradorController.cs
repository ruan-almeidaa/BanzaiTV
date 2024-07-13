using BanzaiTV.Interfaces;
using BanzaiTV.Models;
using Microsoft.AspNetCore.Mvc;

namespace BanzaiTV.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly IAdministradorService _administradorService;
        private readonly ISessao _sessao;
        public AdministradorController(IAdministradorService administradorService, ISessao sessao)
        {
            _administradorService = administradorService;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            if(_sessao.BuscarSessao() != null) return RedirectToAction("Index","Administrador");
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessao();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Login(AdministradorModel administradorModel)
        {
            try
            {
                _administradorService.Logar(administradorModel);
                _sessao.CriarSessao(administradorModel);
                return View("Login");
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
