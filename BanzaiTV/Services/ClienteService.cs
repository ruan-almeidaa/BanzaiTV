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
        public ClienteModel Cadastrar(ClienteModel cliente)
        {
            try
            {
                _clienteRepository.Cadastrar(cliente);
                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
