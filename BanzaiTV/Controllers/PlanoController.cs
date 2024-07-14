﻿using BanzaiTV.Helper;
using BanzaiTV.Interfaces;
using BanzaiTV.Models;
using Microsoft.AspNetCore.Mvc;

namespace BanzaiTV.Controllers
{
    public class PlanoController : Controller
    {
        private readonly IPlanoService _planoService;
        private readonly ISessao _sessao;
        public PlanoController(IPlanoService planoService, ISessao sessao)
        {
            _planoService = planoService;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            try
            {
                if (_sessao != null) {
                    List<PlanoModel> planos = _planoService.BuscarTodos();
                    return View(planos);
                }
                else {
                    return RedirectToAction("Index", "Home");
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(PlanoModel plano)
        {
            try
            {
                _planoService.Cadastrar(plano);
                return View();
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
                if(_sessao != null)
                {
                    PlanoModel plano = _planoService.BuscaPorId(id);
                    return View(plano);
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
        [HttpPost]
        public IActionResult Editar(PlanoModel plano)
        {
            try
            {
                if (_sessao != null)
                {
                    _planoService.Editar(plano);
                    return RedirectToAction("Index", "Plano");
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
