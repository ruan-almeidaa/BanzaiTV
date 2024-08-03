using BanzaiTV.Models;

namespace BanzaiTV.Interfaces.IService
{
    public interface IPlanoService
    {
        PlanoModel Cadastrar(PlanoModel plano);
        List<PlanoModel> BuscarTodos();
        PlanoModel Editar(PlanoModel plano);
        PlanoModel BuscaPorId(int id);
        bool Excluir(int id);
        bool VerificarSePlanoEstaEmUso(int id);
    }
}
