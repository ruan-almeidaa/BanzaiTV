using BanzaiTV.Models;

namespace BanzaiTV.Interfaces
{
    public interface IClienteService
    {
        ClienteModel Cadastrar(ClienteModel cliente);
        List<ClienteModel> BuscarTodos();
        ClienteModel BuscaPorId(int id);
        ClienteModel Editar(ClienteModel cliente);
        bool Excluir(int id);
        void AlterarPlano(ClienteModel cliente);
    }
}
