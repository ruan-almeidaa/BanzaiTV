using BanzaiTV.Models;

namespace BanzaiTV.Interfaces
{
    public interface ISessao
    {
        void CriarSessao(AdministradorModel administrador);
        AdministradorModel BuscarSessao();
        void RemoverSessao();
    }
}
