using BanzaiTV.Interfaces;
using BanzaiTV.Models;

namespace BanzaiTV.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<ClienteModel> BuscarTodos()
        {
            try
            {
                return _clienteRepository.BuscarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClienteModel Cadastrar(ClienteModel cliente)
        {
            try
            {
                return _clienteRepository.Cadastrar(cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
