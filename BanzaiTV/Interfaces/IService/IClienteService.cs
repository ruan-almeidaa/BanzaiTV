using BanzaiTV.Models;

namespace BanzaiTV.Interfaces.IService
{
    public interface IClienteService
    {
        ClienteModel Cadastrar(ClienteModel cliente);
        List<ClienteModel> BuscarTodos();
        ClienteModel BuscaPorId(int id);
        ClienteModel Editar(ClienteModel cliente);
        bool Excluir(int id);
        ClienteModel AtualizarPlano(ClienteModel cliente);
        int QuantidadeDeClientes();
    }
}
