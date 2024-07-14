using BanzaiTV.Models;

namespace BanzaiTV.Interfaces
{
    public interface IPlanoService
    {
        PlanoModel Cadastrar(PlanoModel plano);
        List<PlanoModel> BuscarTodos();
    }
}
