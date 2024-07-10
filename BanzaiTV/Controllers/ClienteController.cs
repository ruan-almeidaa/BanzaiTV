using BanzaiTV.Interfaces;
using BanzaiTV.Models;
using BanzaiTV.Services;
using Microsoft.AspNetCore.Mvc;

namespace BanzaiTV.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
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
        public  IActionResult Cadastrar(ClienteModel cliente)
        {
            try
            {
                _clienteService.Cadastrar(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
