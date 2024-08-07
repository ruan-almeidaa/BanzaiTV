﻿using BanzaiTV.Enums.MensalidadesEnums;
using BanzaiTV.Models;

namespace BanzaiTV.Interfaces.IService
{
    public interface IMensalidadeService
    {
        MensalidadeModel Cadastrar(MensalidadeModel mensalidade);
        MensalidadeModel Editar(MensalidadeModel mensalidade);
        MensalidadeModel BuscaPorId(int id);
        List<MensalidadeModel> BuscarTodos();
        bool Excluir(int id);
        List<MensalidadeModel> BuscarMensalidadesDeCliente(int idCliente);
        void LancarMensalidadesDoCliente(ClienteModel cliente, bool ehRenovacao);
        StatusEnum VerificarStatus(MensalidadeModel mensalidade);
        bool AtualizarStatus(MensalidadeModel mensalidade);
        void RecriarMensalidadesDoCliente(ClienteModel cliente);
        void ExcluirMensalidadesDoCliente(ClienteModel cliente, StatusEnum? status);
        MensalidadeModel BuscaUltimaMensalidadeCliente(int idCliente);
        bool PlanoTemMensalidadesPendentes(int idPlano);
        int QuantidadeAtrasadas(int? mesReferencia, int? anoReferencia);
        int QuantidadePendentes(int? mesReferencia, int? anoReferencia);
        int QuantidadePagas(int? mesReferencia, int? anoReferencia);
        double ValorAhReceber(int? mesReferencia, int? anoReferencia);
    }
}
