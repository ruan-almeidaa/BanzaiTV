using BanzaiTV.Interfaces;
using BanzaiTV.Models;

namespace BanzaiTV.Services
{
    public class PlanoService : IPlanoService
    {
        private readonly IPlanoRepository _planoRepository;
        public PlanoService(IPlanoRepository planosRepository)
        {
            _planoRepository = planosRepository;
        }

        public List<PlanoModel> BuscarTodos()
        {
            try
            {
                return _planoRepository.BuscarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PlanoModel Cadastrar(PlanoModel plano)
        {
            _planoRepository.Cadastrar(plano);
            return plano;
        }
    }
}
