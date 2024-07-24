namespace BanzaiTV.Models
{
    public class PlanoModel
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required double Valor { get; set; }
        public required int MesesDuracao { get; set; }
    }
}
