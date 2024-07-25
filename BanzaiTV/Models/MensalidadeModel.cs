using BanzaiTV.Enums.MensalidadesEnums;

namespace BanzaiTV.Models
{
    public class MensalidadeModel
    {
        public int Id { get; set; }
        public required int ClienteId { get; set; }
        public required DateTimeOffset DataVencimento { get; set; }
        public required Double Valor { get; set; }
        public DateTime? DataPagamento { get; set; }
        public required ClienteModel Cliente { get; set; }
        public StatusEnum? Status { get; set; }
    }
}
