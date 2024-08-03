using BanzaiTV.Models;

namespace BanzaiTV.Interfaces.IRepository
{
    public interface IAdministradorRepository
    {
        AdministradorModel Logar(AdministradorModel administrador);
    }
}
