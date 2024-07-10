﻿namespace BanzaiTV.Models
{
    public class MensalidadeModel
    {
        public int Id { get; set; }
        public required int IdCliente { get; set; }
        public required DateTime DataVencimento { get; set; }
        public required Double Valor { get; set; }
        public DateTime? DataPagamento { get; set; }

    }
}
