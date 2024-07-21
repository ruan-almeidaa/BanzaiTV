using BanzaiTV.Interfaces;
using BanzaiTV.ViewModel;
using BanzaiTV.Models;

namespace BanzaiTV.ViewModelServices
{
    public class MensalidadeViewModelService : IMensalidadeViewModelService
    {
        private readonly IClienteService _clienteService;
        public  MensalidadeViewModelService(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public MensalidadeViewModel CarregaViewCadastrar()
        {
			try
			{
                MensalidadeViewModel mensalidadeViewModel = new();
                mensalidadeViewModel.ListaDeClientes = _clienteService.BuscarTodos();
                return mensalidadeViewModel;

            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
