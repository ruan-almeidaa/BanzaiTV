using BanzaiTV.Models;

namespace BanzaiTV.Helper
{
    public interface ISessao
    {
        void CriarSessao(AdministradorModel administrador);
        AdministradorModel BuscarSessao();
        void RemoverSessao();
    }
}
