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
                _mensalidadeService.LancarMensalidadesDoCliente(clienteCadastrado, false);
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
                if (clienteNoBanco != cliente) _clienteRepository.Editar(cliente);
                if (cliente.PlanoId != clienteNoBanco.PlanoId) _mensalidadeService.RecriarMensalidadesDoCliente(cliente);
                return cliente;
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

        public void RenovarPlanoCliente(ClienteModel cliente)
        {
            try
            {
                _mensalidadeService.LancarMensalidadesDoCliente(_clienteRepository.AtulizaPlanoCliente(cliente), true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
