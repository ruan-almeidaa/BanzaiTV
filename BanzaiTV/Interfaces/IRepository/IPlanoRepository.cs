﻿using BanzaiTV.Models;

namespace BanzaiTV.Interfaces.IRepository
{
    public interface IPlanoRepository
    {
        PlanoModel Cadastrar(PlanoModel plano);
        List<PlanoModel> BuscarTodos();
        PlanoModel Editar(PlanoModel plano);
        PlanoModel BuscaPorId(int id);
        bool Excluir(PlanoModel plano);
    }
}
