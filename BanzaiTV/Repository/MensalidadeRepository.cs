using BanzaiTV.Database;
using BanzaiTV.Interfaces;
using BanzaiTV.Models;

namespace BanzaiTV.Repository
{
    public class MensalidadeRepository : IMensalidadeRepository
    {

        private readonly BancoContext _bancoContext;
        public MensalidadeRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public MensalidadeModel Cadastrar(MensalidadeModel mensalidade)
        {
            try
            {
                _bancoContext.Mensalidades.Add(mensalidade);
                _bancoContext.SaveChanges();
                return mensalidade;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
