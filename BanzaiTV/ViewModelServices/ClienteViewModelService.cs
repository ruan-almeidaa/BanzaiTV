using BanzaiTV.Interfaces;
using BanzaiTV.ViewModel;

namespace BanzaiTV.ViewModelServices
{
    public class ClienteViewModelService: IClienteViewModelService
    {
        private readonly IClienteService _clienteService;
        private readonly IPlanoService _planoService;

        public ClienteViewModelService(IClienteService clienteService, IPlanoService planoService)
        {
            _clienteService = clienteService;
            _planoService = planoService;
        }
        public ClienteViewModel CarregaViewCadastrar()
        {
            try
            {
                ClienteViewModel clientePlanosViewModel = new();
                clientePlanosViewModel.ListaDePlanos = _planoService.BuscarTodos();
                return (clientePlanosViewModel);
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
