using BanzaiTV.Models;

namespace BanzaiTV.Interfaces.IService
{
    public interface IOrquestracaoService
    {
        ClienteModel Cliente_Cadastrar(ClienteModel cliente);
    }
}
