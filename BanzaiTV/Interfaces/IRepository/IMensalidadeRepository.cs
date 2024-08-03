using BanzaiTV.Enums.MensalidadesEnums;
using BanzaiTV.Models;

namespace BanzaiTV.Interfaces.IRepository
{
    public interface IMensalidadeRepository
    {
        MensalidadeModel Cadastrar(MensalidadeModel mensalidade);
        MensalidadeModel Editar(MensalidadeModel mensalidade);
        MensalidadeModel BuscaPorId(int id);
        List<MensalidadeModel> BuscarTodos();
        bool Excluir(MensalidadeModel mensalidade);
        List<MensalidadeModel> BuscarMensalidadesDeCliente(int idCliente);
        bool AtualizarStatus(MensalidadeModel mensalidade);
        void ExcluirTodasMensalidadesDoCliente(ClienteModel cliente);
        MensalidadeModel BuscaUltimaMensalidadeCliente(int idCliente);
        bool PlanoTemMensalidadesPendentes(int idPlano);
        int QuantidadeAtrasadas(int? mesReferencia, int? anoReferencia);
        int QuantidadePendentes(int? mesReferencia, int? anoReferencia);
        int QuantidadePagas(int? mesReferencia, int? anoReferencia);
        double ValorAhReceber(int? mesReferencia, int? anoReferencia);
    }
}
