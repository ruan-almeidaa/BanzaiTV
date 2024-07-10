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
        public PlanoModel Cadastrar(PlanoModel plano)
        {
            _planoRepository.Cadastrar(plano);
            return plano;
        }
    }
}
