﻿using BanzaiTV.Interfaces;
using BanzaiTV.Models;

namespace BanzaiTV.ViewModel
{
    public class ClienteViewModel
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
        public string? Cpf { get; set; }
        public int? DiaVencimento { get; set; }
        public int? PlanoId { get; set; }
        public bool Ativo { get; set; }
        public PlanoModel? Plano { get; set; }
        public List<PlanoModel>? ListaDePlanos { get; set; }
        public List<MensalidadeModel>? Mensalidades { get; set; }
    }

}
