using BanzaiTV.Models;

namespace BanzaiTV.Interfaces
{
    public interface IClienteRepository
    {
        ClienteModel Cadastrar(ClienteModel cliente);
        List<ClienteModel> BuscarTodos();
    }
}
