using BanzaiTV.Helper.Sessao;
using BanzaiTV.Interfaces.IService;
using BanzaiTV.Models;
using BanzaiTV.Services;
using Microsoft.AspNetCore.Mvc;

namespace BanzaiTV.Controllers
{
    public class PlanoController : Controller
    {
        private readonly IPlanoService _planoService;
        private readonly IOrquestracaoService _orquestracaoService;
        private readonly ISessao _sessao;
        public PlanoController(IPlanoService planoService, IOrquestracaoService orquestracaoService,ISessao sessao)
        {
            _planoService = planoService;
            _orquestracaoService = orquestracaoService;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            try
            {
                if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
                List<PlanoModel> planos = _planoService.BuscarTodos();
                return View(planos);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult Cadastrar()
        {
            try
            {
                if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
                return View();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        [HttpPost]
        public IActionResult Cadastrar(PlanoModel plano)
        {
            try
            {
                if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
                _planoService.Cadastrar(plano);
                return RedirectToAction("Index", "Plano");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult Editar(int id)
        {
            try
            {
                if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
                bool planoEstaEmUso = _orquestracaoService.Plano_VerificarSePlanoEstaEmUso(id);
                if (planoEstaEmUso) return RedirectToAction("NaoPermiteEditar", "Plano");

                PlanoModel plano = _planoService.BuscaPorId(id);
                return View(plano);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Editar(PlanoModel plano)
        {
            try
            {
                if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
                _planoService.Editar(plano);
                return RedirectToAction("Index", "Plano");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult ConfirmaExcluir(int id)
        {
            try
            {
                if (_sessao.BuscarSessao() == null) return RedirectToAction("Home", "Index");
                PlanoModel plano = _planoService.BuscaPorId(id);
                bool planoEstaEmUso = _orquestracaoService.Plano_VerificarSePlanoEstaEmUso(plano.Id);
                if (planoEstaEmUso) return RedirectToAction("NaoPermiteEditar", "Plano");
                return View(plano);
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
                _planoService.Excluir(id);
                return RedirectToAction("Index", "Plano");

            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult NaoPermiteEditar()
        {
            try
            {
                if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
