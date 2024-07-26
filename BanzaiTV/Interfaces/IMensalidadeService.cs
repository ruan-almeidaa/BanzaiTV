using BanzaiTV.Enums.MensalidadesEnums;
using BanzaiTV.Models;

namespace BanzaiTV.Interfaces
{
    public interface IMensalidadeService
    {
        MensalidadeModel Cadastrar(MensalidadeModel mensalidade);
        MensalidadeModel Editar(MensalidadeModel mensalidade);
        MensalidadeModel BuscaPorId(int id);
        List<MensalidadeModel> BuscarTodos();
        bool Excluir(int id);
        List<MensalidadeModel> BuscarMensalidadesDeCliente(int idCliente);
        void LancarMensalidadesDoCliente(ClienteModel cliente);
        StatusEnum VerificarStatus(MensalidadeModel mensalidade);
        bool AtualizarStatus(MensalidadeModel mensalidade);
        void RecriarMensalidadesDoCliente(ClienteModel cliente);
        void ExcluirMensalidadesDoCliente(ClienteModel cliente, StatusEnum? status);
    }
}
