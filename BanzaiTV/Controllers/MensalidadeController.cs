using BanzaiTV.Helper;
using BanzaiTV.Interfaces;
using BanzaiTV.Models;
using Microsoft.AspNetCore.Mvc;

namespace BanzaiTV.Controllers
{
    public class MensalidadeController : Controller
    {
        private readonly IMensalidadeService _mensalidadeService;
        private readonly ISessao _sessao;

        public MensalidadeController(IMensalidadeService mensalidadeService, ISessao sessao)
        {
            _mensalidadeService = mensalidadeService;
            _sessao = sessao;
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
        public IActionResult Cadastrar(MensalidadeModel mensalidade)
        {
            if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
            _mensalidadeService.Cadastrar(mensalidade);
            return RedirectToAction("Index", "Mensalidade");
        }

    }
}
