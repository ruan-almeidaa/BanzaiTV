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

        public MensalidadeModel BuscaPorId(int id)
        {
            try
            {
                return _bancoContext.Mensalidades.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MensalidadeModel> BuscarTodos()
        {
            try
            {
                return _bancoContext.Mensalidades.ToList();
            }
            catch (Exception)
            {

                throw;
            }
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
        public MensalidadeModel Editar(MensalidadeModel mensalidade)
        {
            try
            {
                _bancoContext.ChangeTracker.Clear();
                _bancoContext.Mensalidades.Update(mensalidade);
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
