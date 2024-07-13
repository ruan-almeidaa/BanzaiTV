﻿using BanzaiTV.Interfaces;
using BanzaiTV.Models;

namespace BanzaiTV.Services
{
    public class AdministradorService : IAdministradorService
    {
        private readonly IAdministradorRepository _administradorRepository;

        public AdministradorService(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }

        public AdministradorModel Logar(AdministradorModel administrador)
        {
            throw new NotImplementedException();
        }
    }
}