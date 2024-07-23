using BanzaiTV.Interfaces;
using BanzaiTV.Models;

namespace BanzaiTV.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMensalidadeService _mensalidadeService;

        public ClienteService(IClienteRepository clienteRepository, IMensalidadeService mensalidadeService)
        {
            _clienteRepository = clienteRepository;
            _mensalidadeService = mensalidadeService;
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
                ClienteModel clienteCadastrado = _clienteRepository.Cadastrar(cliente);
                _mensalidadeService.LancarMensalidadesDoCliente(BuscaPorId(clienteCadastrado.Id));
                return clienteCadastrado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClienteModel BuscaPorId(int id)
        {
            try
            {
                return _clienteRepository.BuscaPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClienteModel Editar(ClienteModel cliente)
        {
            try
            {
                ClienteModel clienteNoBanco = BuscaPorId(cliente.Id);

                 return _clienteRepository.Editar(cliente);
            }
            catch
            {
                throw;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                _clienteRepository.Excluir(BuscaPorId(id));
                return true;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
