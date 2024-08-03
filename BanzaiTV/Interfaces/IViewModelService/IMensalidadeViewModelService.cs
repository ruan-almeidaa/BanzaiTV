using BanzaiTV.ViewModel;

namespace BanzaiTV.Interfaces.IViewModelService
{
    public interface IMensalidadeViewModelService
    {
        MensalidadeViewModel CarregaViewCadastrar();
        MensalidadeViewModel CarregaViewEditar(int id);
        List<MensalidadeViewModel> CarregaViewIndex();
    }
}
