using BanzaiTV.Models;

namespace BanzaiTV.Interfaces
{
    public interface IMensalidadeRepository
    {
        MensalidadeModel Cadastrar(MensalidadeModel mensalidade);
    }
}
