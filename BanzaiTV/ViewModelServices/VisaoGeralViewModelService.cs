using BanzaiTV.Interfaces.IService;
using BanzaiTV.Interfaces.IViewModelService;
using BanzaiTV.ViewModel;

namespace BanzaiTV.ViewModelServices
{
    public class VisaoGeralViewModelService : IVisaoGeralViewModelService
    {
        private readonly IClienteService _clienteService;
        private readonly IMensalidadeService _mensalidadeService;

        public VisaoGeralViewModelService(IClienteService clienteService, IMensalidadeService mensalidadeService)
        {
            _clienteService = clienteService;
            _mensalidadeService = mensalidadeService;
        }

        public VisaoGeralViewModel CarregaViewIndex()
        {
			try
			{
                VisaoGeralViewModel visaoGeralViewModel = new()
                {
                    QuantidadeClientes = _clienteService.QuantidadeDeClientes(),
                    QuantidadeMensalidadesAtrasadasMesAtual = _mensalidadeService.QuantidadeAtrasadas(DateTime.Now.Month, DateTime.Now.Year),
                    QuantidadeMensalidadesPendentesMesAtual = _mensalidadeService.QuantidadePendentes(DateTime.Now.Month,DateTime.Now.Year),
                    QuantidadeMensalidadesPagasMesAtual = _mensalidadeService.QuantidadePagas(DateTime.Now.Month, DateTime.Now.Year),
                    ValorReceberMesAtual = _mensalidadeService.ValorAhReceber(DateTime.Now.Month, DateTime.Now.Year),
                    QuantidadeMensalidadesAtrasadas= _mensalidadeService.QuantidadeAtrasadas(null, null),
                    QuantidadeMensalidadesPendentes = _mensalidadeService.QuantidadePendentes(null, null),
                    QuantidadeMensalidadesPagas = _mensalidadeService.QuantidadePagas(null, null),
                    ValorReceber = _mensalidadeService.ValorAhReceber(null, null)

                };

                return visaoGeralViewModel;

			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
