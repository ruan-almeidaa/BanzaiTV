namespace BanzaiTV.Models
{
    public class AdministradorModel
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}
