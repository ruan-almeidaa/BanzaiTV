using BanzaiTV.Interfaces;
using BanzaiTV.ViewModel;
using BanzaiTV.Models;
using AutoMapper;

namespace BanzaiTV.ViewModelServices
{
    public class MensalidadeViewModelService : IMensalidadeViewModelService
    {
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;
        private readonly IMensalidadeService _mensalidadeService;
        public  MensalidadeViewModelService(IMapper mapper, IClienteService clienteService, IMensalidadeService mensalidadeService)
        {
            _mapper = mapper;
            _clienteService = clienteService;
            _mensalidadeService = mensalidadeService;
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
        public MensalidadeViewModel CarregaViewEditar(int id)
        {
            try
            {
                MensalidadeModel mensalidadeModel = _mensalidadeService.BuscaPorId(id);
                MensalidadeViewModel mensalidadeViewModel = new();
                mensalidadeViewModel = _mapper.Map<MensalidadeViewModel>(mensalidadeModel);
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
