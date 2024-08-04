using BanzaiTV.Helper.Sessao;
using BanzaiTV.Interfaces.IService;
using BanzaiTV.Interfaces.IViewModelService;
using BanzaiTV.Models;
using BanzaiTV.Services;
using BanzaiTV.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BanzaiTV.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly ISessao _sessao;
        private readonly IClienteViewModelService _clienteViewModelService;
        private readonly IOrquestracaoService _orquestracaoService;

        public ClienteController(IClienteService clienteService, ISessao sessao, IClienteViewModelService clienteViewModelService, IOrquestracaoService orquestracaoService)
        {
            _clienteService = clienteService;
            _sessao = sessao;
            _clienteViewModelService = clienteViewModelService;
            _orquestracaoService = orquestracaoService;
        }

        public IActionResult Index()
        {
            try
            {
                if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
                List<ClienteModel> clientes = _clienteService.BuscarTodos();
                return View(clientes);
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
                ClienteViewModel clientePlanosViewModel = _clienteViewModelService.CarregaViewCadastrar();
                return View(clientePlanosViewModel);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public  IActionResult Cadastrar(ClienteModel cliente)
        {
            try
            {
                if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
                _orquestracaoService.Cliente_Cadastrar(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            
            try
            {
                if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
                ClienteViewModel cliente = _clienteViewModelService.CarregaViewEditar(id);
                return View(cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Editar(ClienteModel cliente)
        {
            try
            {

                if(_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
                _orquestracaoService.Cliente_Editar(cliente);
                return RedirectToAction("Index","Cliente");

            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public IActionResult ConfirmaExcluir(int id)
        {
            try
            {
                if (_sessao.BuscarSessao() == null) return RedirectToAction("Index", "Home");
                ClienteModel cliente = _clienteService.BuscaPorId(id);
                return View(cliente);

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
                _clienteService.Excluir(id);
                return RedirectToAction("Index", "Cliente");
                

            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public IActionResult VerMais(int id)
        {
            try
            {
                if (_sessao.BuscarSessao == null) return View("Index", "Home");
                return View(_clienteViewModelService.CarregaViewVerMais(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public IActionResult Renovar(int id)
        {
            try
            {
                if (_sessao.BuscarSessao == null) return View("Index", "Home");
                return View(_clienteViewModelService.CarregaViewRenovar(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Renovar(ClienteModel cliente)
        {
            try
            {
                if (_sessao.BuscarSessao == null) return View("Index", "Home");
                _orquestracaoService.Cliente_Renovar(cliente);
                return RedirectToAction("Index", "Cliente");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
