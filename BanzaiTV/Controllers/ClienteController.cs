﻿using BanzaiTV.Helper;
using BanzaiTV.Interfaces;
using BanzaiTV.Models;
using BanzaiTV.Services;
using Microsoft.AspNetCore.Mvc;

namespace BanzaiTV.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly ISessao _sessao;
        public ClienteController(IClienteService clienteService, ISessao sessao)
        {
            _clienteService = clienteService;
            _sessao = sessao;
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
                return View();
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

        public IActionResult Editar(int id)
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
    }
}
