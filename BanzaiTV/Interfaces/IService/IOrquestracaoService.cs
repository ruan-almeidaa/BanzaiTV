using BanzaiTV.Models;

namespace BanzaiTV.Interfaces.IService
{
    public interface IOrquestracaoService
    {
        ClienteModel Cliente_Cadastrar(ClienteModel cliente);
        ClienteModel Cliente_Editar(ClienteModel cliente);
    }
}
