using BanzaiTV.ViewModel;

namespace BanzaiTV.Interfaces.IViewModelService
{
    public interface IClienteViewModelService
    {
        ClienteViewModel CarregaViewCadastrar();
        ClienteViewModel CarregaViewEditar(int id);
        ClienteViewModel CarregaViewVerMais(int id);
        ClienteViewModel CarregaViewRenovar(int idCliente);
    }
}
