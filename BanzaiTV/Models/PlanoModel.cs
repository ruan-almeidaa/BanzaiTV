namespace BanzaiTV.Models
{
    public class PlanoModel
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required double valor { get; set; }
        public required int mesesDuracao { get; set; }
    }
}
