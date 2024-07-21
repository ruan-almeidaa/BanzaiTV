using BanzaiTV.Models;

namespace BanzaiTV.ViewModel
{
    public class MensalidadeViewModel
    {
            public int? ClienteId { get; set; }
            public DateTimeOffset? DataVencimento { get; set; }
            public Double? Valor { get; set; }
            public DateTime? DataPagamento { get; set; }
            public List<ClienteModel>? ListaDeClientes { get; set; }

    }
}

