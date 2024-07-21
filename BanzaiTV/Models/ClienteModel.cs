namespace BanzaiTV.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
        public string? Cpf { get; set; }
        public required int DiaVencimento { get; set; }
        public required int PlanoId { get; set; }
        public required bool Ativo { get; set; }
        public required PlanoModel Plano { get; set; }

    }
}
