using BanzaiTV.Database;
using BanzaiTV.Interfaces;
using BanzaiTV.Models;

namespace BanzaiTV.Repository
{
    public class PlanoRepository : IPlanoRepository
    {
        private readonly BancoContext _bancoContext;

        public PlanoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<PlanoModel> BuscarTodos()
        {
            try
            {
                return _bancoContext.Planos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PlanoModel Cadastrar(PlanoModel plano)
        {
			try
			{
                _bancoContext.Planos.Add(plano);
                _bancoContext.SaveChanges();
                return plano;

            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
