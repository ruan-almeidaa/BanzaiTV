using BanzaiTV.Database;
using BanzaiTV.Interfaces;
using BanzaiTV.Models;

namespace BanzaiTV.Repository
{
    public class ClienteRepository : IClienteRepository

    {
        private readonly BancoContext _bancoContext;

        public ClienteRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ClienteModel Cadastrar(ClienteModel cliente)
        {
            try
            {
                _bancoContext.Clientes.Add(cliente);
                _bancoContext.SaveChanges();
                return cliente;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
