using BanzaiTV.ViewModel;
using BanzaiTV.Models;
using AutoMapper;
using BanzaiTV.Interfaces.IService;
using BanzaiTV.Interfaces.IViewModelService;

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

        public List<MensalidadeViewModel> CarregaViewIndex()
        {
            try
            {
                List<MensalidadeModel> listaMensalidadesModel = _mensalidadeService.BuscarTodos();
                List<MensalidadeViewModel> listaMensalidadesViewModel = new();

                //Percorre toda a lista de MensalidadeModel convertendo para uma nova lista de MensalidadeViewModel
                foreach (MensalidadeModel mensalidadeModel in listaMensalidadesModel)
                {
                    MensalidadeViewModel mensalidadeViewModel = new();
                    mensalidadeViewModel = _mapper.Map<MensalidadeViewModel>(mensalidadeModel);
                    listaMensalidadesViewModel.Add(mensalidadeViewModel);

                }

                return listaMensalidadesViewModel;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
