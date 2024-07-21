using AutoMapper;
using BanzaiTV.Interfaces;
using BanzaiTV.Models;
using BanzaiTV.ViewModel;

namespace BanzaiTV.ViewModelServices
{
    public class ClienteViewModelService: IClienteViewModelService
    {
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;
        private readonly IPlanoService _planoService;
        private readonly IMensalidadeService _mensalidadeService;

        public ClienteViewModelService(IMapper mapper, IClienteService clienteService, IPlanoService planoService, IMensalidadeService mensalidadeService)
        {
            _mapper = mapper;
            _clienteService = clienteService;
            _planoService = planoService;
            _mensalidadeService = mensalidadeService;
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

        public ClienteViewModel CarregaViewEditar(int id)
        {
            try
            {
                ClienteModel clienteModel = _clienteService.BuscaPorId(id);
                ClienteViewModel clienteViewModel = new();
                clienteViewModel = _mapper.Map<ClienteViewModel>(clienteModel);
                clienteViewModel.ListaDePlanos = _planoService.BuscarTodos();
                return clienteViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClienteViewModel CarregaViewVerMais(int idCliente)
        {
            try
            {
                ClienteModel clienteModel = _clienteService.BuscaPorId(idCliente);
                ClienteViewModel clienteViewModel = new();
                clienteViewModel = _mapper.Map<ClienteViewModel>(clienteModel);
                clienteViewModel.ListaDeMensalidades = _mensalidadeService.BuscarMensalidadesDeCliente(idCliente);
                return clienteViewModel;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
