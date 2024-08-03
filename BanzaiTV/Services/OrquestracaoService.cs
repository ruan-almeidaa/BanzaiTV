using BanzaiTV.Interfaces.IService;
using BanzaiTV.Models;

namespace BanzaiTV.Services
{
    public class OrquestracaoService : IOrquestracaoService
    {
        private readonly IClienteService _clienteService;
        private readonly IMensalidadeService _mensalidadeService;
        private readonly IPlanoService _planoService;

        public OrquestracaoService(IClienteService clienteService, IMensalidadeService mensalidadeService, IPlanoService planoService)
        {
            _clienteService = clienteService;
            _mensalidadeService = mensalidadeService;
            _planoService = planoService;
        }

        public ClienteModel Cliente_Cadastrar(ClienteModel cliente)
        {
            try
            {
                ClienteModel clienteCadastrado = _clienteService.Cadastrar(cliente);
                _mensalidadeService.LancarMensalidadesDoCliente(clienteCadastrado, false);
                return clienteCadastrado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClienteModel Cliente_Editar(ClienteModel cliente)
        {
            try
            {
                ClienteModel cadastroAtualCliente = _clienteService.BuscaPorId(cliente.Id);
                // Só precisa realizar o update, se tem alguma diferença entre o cliente que está no banco e o que está sendo recebido.
                if(cadastroAtualCliente != cliente) _clienteService.Editar(cliente);
                // Caso tenha alterado o plano do cliente, precisa recriar as mensalidades considerando o novo plano.
                if(cadastroAtualCliente.PlanoId != cliente.PlanoId) _mensalidadeService.RecriarMensalidadesDoCliente(cliente);
                return cliente;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cliente_Renovar(ClienteModel cliente)
        {
            try
            {
                _mensalidadeService.LancarMensalidadesDoCliente(_clienteService.AtualizarPlano(cliente), true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
