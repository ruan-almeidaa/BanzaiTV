using BanzaiTV.Models;

namespace BanzaiTV.Helper.Sessao
{
    public interface ISessao
    {
        void CriarSessao(AdministradorModel administrador);
        AdministradorModel BuscarSessao();
        void RemoverSessao();
    }
}
