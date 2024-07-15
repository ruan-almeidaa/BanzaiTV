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
	}
}

