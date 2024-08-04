using BanzaiTV.Helper.Sessao;
using BanzaiTV.Interfaces.IService;
using BanzaiTV.Interfaces.IViewModelService;
using BanzaiTV.Models;
using BanzaiTV.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BanzaiTV.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly IAdministradorService _administradorService;
        private readonly IVisaoGeralViewModelService _visaoGeralViewModelService;
        private readonly ISessao _sessao;
        public AdministradorController(IAdministradorService administradorService, IVisaoGeralViewModelService visaoGeralViewModelService, ISessao sessao)
        {
            _administradorService = administradorService;
            _visaoGeralViewModelService = visaoGeralViewModelService;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");

            VisaoGeralViewModel visaoGeralViewModel = _visaoGeralViewModelService.CarregaViewIndex();
            return View(visaoGeralViewModel);

            
        }
        public IActionResult Login()
        {
            if (_sessao.BuscarSessao() == null) return View();
            return RedirectToAction("index", "Administrador");
                
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
