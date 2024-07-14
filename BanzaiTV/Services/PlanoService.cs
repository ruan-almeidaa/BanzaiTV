using BanzaiTV.Interfaces;
using BanzaiTV.Models;
using System.Numerics;

namespace BanzaiTV.Services
{
    public class PlanoService : IPlanoService
    {
        private readonly IPlanoRepository _planoRepository;
        public PlanoService(IPlanoRepository planosRepository)
        {
            _planoRepository = planosRepository;
        }

        public PlanoModel BuscaPorId(int id)
        {
            try
            {
                return _planoRepository.BuscaPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
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

        public PlanoModel Editar(PlanoModel plano)
        {
            try
            {
                PlanoModel planoNoBanco = BuscaPorId(plano.Id);
                if (planoNoBanco != null) {
                    _planoRepository.Editar(plano);
                    return plano;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
