using BanzaiTV.Helper.CriptografiaCfg;
using BanzaiTV.Interfaces.IRepository;
using BanzaiTV.Interfaces.IService;
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
            administrador.Senha = Criptografia.GerarHash(administrador.Senha);

            return _administradorRepository.Logar(administrador);
        }
    }
}
