using BanzaiTV.Interfaces;
using BanzaiTV.Models;

namespace BanzaiTV.Services
{
	public class MensalidadeService : IMensalidadeService
	{
		private readonly IMensalidadeRepository _mensalidadeRepository;
		public MensalidadeService(IMensalidadeRepository mensalidadeRepository)
		{
			_mensalidadeRepository = mensalidadeRepository;
		}

        public MensalidadeModel BuscaPorId(int id)
        {
			try
			{
				return _mensalidadeRepository.BuscaPorId(id);
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
				return _mensalidadeRepository.BuscarTodos();
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
				return _mensalidadeRepository.Cadastrar(mensalidade);

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
				MensalidadeModel mensalidadeNoBanco = BuscaPorId(mensalidade.Id);
				if (mensalidadeNoBanco == null) return null;
				return _mensalidadeRepository.Editar(mensalidade);

			}
			catch (Exception)
			{

				throw;
			}
        }

        public bool Excluir(int id)
        {
			try
			{
				return _mensalidadeRepository.Excluir(BuscaPorId(id));
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}

