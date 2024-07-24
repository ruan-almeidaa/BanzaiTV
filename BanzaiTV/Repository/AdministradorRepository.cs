using BanzaiTV.Database;
using BanzaiTV.Interfaces;
using BanzaiTV.Models;

namespace BanzaiTV.Repository
{
    public class AdministradorRepository : IAdministradorRepository
    {
        private readonly BancoContext _bancoContext;
        public AdministradorRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public AdministradorModel Logar(AdministradorModel p_administradorModel)
        {
            return _bancoContext.Administrador.FirstOrDefault
                (a => a.Email == p_administradorModel.Email && a.Senha == p_administradorModel.Senha);
            
        }
    }
}
