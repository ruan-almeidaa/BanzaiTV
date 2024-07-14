using BanzaiTV.Models;

namespace BanzaiTV.Interfaces
{
    public interface IPlanoRepository
    {
        PlanoModel Cadastrar(PlanoModel plano);
        List<PlanoModel> BuscarTodos();
    }
}
