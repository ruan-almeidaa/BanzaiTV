using BanzaiTV.ViewModel;

namespace BanzaiTV.Interfaces
{
    public interface IClienteViewModelService
    {
        ClienteViewModel CarregaViewCadastrar();
        ClienteViewModel CarregaViewEditar(int id);
        ClienteViewModel CarregaViewVerMais(int id);
    }
}
