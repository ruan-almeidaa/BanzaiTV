using BanzaiTV.Helper;
using BanzaiTV.Interfaces;
using BanzaiTV.Models;
using BanzaiTV.Services;
using BanzaiTV.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BanzaiTV.Controllers
{
    public class MensalidadeController : Controller
    {
        private readonly IMensalidadeService _mensalidadeService;
        private readonly ISessao _sessao;
        private readonly IMensalidadeViewModelService _mensalidadeViewModelService;

        public MensalidadeController(IMensalidadeService mensalidadeService, IMensalidadeViewModelService mensalidadeViewModelService, ISessao sessao)
        {
            _mensalidadeViewModelService = mensalidadeViewModelService;
            _mensalidadeService = mensalidadeService;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");

            List<MensalidadeViewModel> mensalidades = _mensalidadeViewModelService.CarregaViewIndex();
            return View(mensalidades);
        }

        public IActionResult Cadastrar()
        {
            if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
            MensalidadeViewModel mensalidadeViewModel = _mensalidadeViewModelService.CarregaViewCadastrar();
            return View(mensalidadeViewModel);
        }

        [HttpPost]
        public IActionResult Cadastrar(MensalidadeModel mensalidade)
        {
            if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
            _mensalidadeService.Cadastrar(mensalidade);
            return RedirectToAction("Index", "Mensalidade");
        }
        public IActionResult Editar(int id)
        {
            if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
            return View(_mensalidadeViewModelService.CarregaViewEditar(id));
        }

        [HttpPost]
        public IActionResult Editar(MensalidadeModel mensalidade)
        {
            if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
            _mensalidadeService.Editar(mensalidade);
            return RedirectToAction("Index", "Mensalidade");

        }

        public IActionResult ConfirmaExcluir(int id)
        {
            try
            {
                if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
                return View(_mensalidadeService.BuscaPorId(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult Excluir(int id)
        {
            try
            {
                if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");

                _mensalidadeService.Excluir(id);
                return RedirectToAction("Index", "Mensalidade");
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
