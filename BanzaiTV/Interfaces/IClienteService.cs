using BanzaiTV.Models;

namespace BanzaiTV.Interfaces
{
    public interface IClienteService
    {
        ClienteModel Cadastrar(ClienteModel cliente);
    }
}
