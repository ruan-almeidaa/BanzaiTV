﻿using BanzaiTV.Helper.Sessao;
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

        public ClienteController(IClienteService clienteService, ISessao sessao, IClienteViewModelService clienteViewModelService)
        {
            _clienteService = clienteService;
            _sessao = sessao;
            _clienteViewModelService = clienteViewModelService;
        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessao() != null)
            {
               List <ClienteModel> clientes = _clienteService.BuscarTodos();
                return View(clientes);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Cadastrar()
        {
            if (_sessao.BuscarSessao() != null)
            {
                ClienteViewModel clientePlanosViewModel = _clienteViewModelService.CarregaViewCadastrar();
                return View(clientePlanosViewModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
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
        [HttpGet]
        public IActionResult Editar(int id)
        {
            
            try
            {
                ClienteViewModel cliente = _clienteViewModelService.CarregaViewEditar(id);
                if (_sessao.BuscarSessao() != null && cliente != null)
                {
                    return View(cliente);
                }
                else
                {
                    return RedirectToAction("Index", "Cliente");
                }
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
                if (_sessao.BuscarSessao() != null)
                {
                    _clienteService.Editar(cliente);
                    return RedirectToAction("Index","Cliente");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

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
                ClienteModel cliente = _clienteService.BuscaPorId(id);
                if (_sessao.BuscarSessao() != null && cliente != null)
                {
                    return View(cliente);
                }
                else
                {
                    return RedirectToAction("Index", "Cliente");
                }

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
                if((_sessao.BuscarSessao() != null)){
                    _clienteService.Excluir(id);
                    return RedirectToAction("Index", "Cliente");
                }else { 
                    return RedirectToAction("Index", "Home");
                }
                

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
                _clienteService.RenovarPlanoCliente(cliente);
                return RedirectToAction("Index", "Cliente");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
