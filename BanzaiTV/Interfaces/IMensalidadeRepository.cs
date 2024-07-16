﻿using BanzaiTV.Models;

namespace BanzaiTV.Interfaces
{
    public interface IMensalidadeRepository
    {
        MensalidadeModel Cadastrar(MensalidadeModel mensalidade);
        MensalidadeModel Editar(MensalidadeModel mensalidade);
        MensalidadeModel BuscaPorId(int id);
    }
}
