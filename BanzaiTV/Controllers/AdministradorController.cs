using BanzaiTV.Helper.Sessao;
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
            if (_sessao.BuscarSessao() != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        public IActionResult Login()
        {
            if (_sessao.BuscarSessao() != null)
            {
                return RedirectToAction("index", "Administrador");
            }
            else
            {
                return View();
            }
                
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
                if(_administradorService.Logar(administradorModel) != null)
                {
                    _sessao.CriarSessao(administradorModel);
                    return RedirectToAction("Index", "Administrador");
                }
                else
                {
                    return View("Login");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
