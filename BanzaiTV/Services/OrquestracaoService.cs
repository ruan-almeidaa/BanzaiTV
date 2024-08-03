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
    }
}
