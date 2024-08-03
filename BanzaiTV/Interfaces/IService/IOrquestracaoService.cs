using BanzaiTV.Models;

namespace BanzaiTV.Interfaces.IService
{
    public interface IOrquestracaoService
    {
        ClienteModel Cliente_Cadastrar(ClienteModel cliente);
        ClienteModel Cliente_Editar(ClienteModel cliente);
        void Cliente_Renovar (ClienteModel cliente);
        bool Plano_VerificarSePlanoEstaEmUso(int id);
    }
}
