﻿using BanzaiTV.ViewModel;

namespace BanzaiTV.Interfaces
{
    public interface IMensalidadeViewModelService
    {
        MensalidadeViewModel CarregaViewCadastrar();
        MensalidadeViewModel CarregaViewEditar(int id);
    }
}
