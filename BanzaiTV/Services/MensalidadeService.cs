using BanzaiTV.Enums.MensalidadesEnums;
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
                mensalidade.Status = VerificarStatus(mensalidade);
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
				mensalidade.Status = VerificarStatus(mensalidade);
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

		public List<MensalidadeModel> BuscarMensalidadesDeCliente(int idCliente)
		{
			try
			{
				return _mensalidadeRepository.BuscarMensalidadesDeCliente(idCliente);
			}
            catch (Exception)
            {

                throw;
            }

        }

		public void LancarMensalidadesDoCliente(ClienteModel cliente)
		{

			try
			{
                int mensalidadesCriadas = 1;
                DateTime dataAtual = DateTime.Now;


				do
                {
					//Inicializa a primeira mensalidade, gerando ela para o próximo mês.E Conforme for criando as mensalidades, precisa ir incrementando os meses.
                    DateTime dataComUmMes = dataAtual.AddMonths(mensalidadesCriadas);
                    DateTime dataMensalidadeDiaCliente = new DateTime(dataComUmMes.Year, dataComUmMes.Month, cliente.DiaVencimento);

                    MensalidadeModel mensalidadeAhSerCriada = new()
                    {
                        ClienteId = cliente.Id,
                        DataVencimento = dataMensalidadeDiaCliente,
                        Valor = cliente.Plano.Valor,
                        Cliente = cliente
                    };
                    Cadastrar(mensalidadeAhSerCriada);
                    mensalidadesCriadas++;
                } while (cliente.Plano.MesesDuracao >= mensalidadesCriadas);
            }
			catch (Exception)
			{

				throw;
			}


        }
		public StatusEnum VerificarStatus(MensalidadeModel mensalidade)
		{
			try
			{
				if (mensalidade.DataPagamento == null && DateTimeOffset.UtcNow > mensalidade.DataVencimento) return StatusEnum.Atrasada;
				if (mensalidade.DataPagamento != null) return StatusEnum.Paga;
				return StatusEnum.Pendente;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public bool AtualizarStatus(MensalidadeModel mensalidade)
		{
			try
			{
				StatusEnum novoStatus = VerificarStatus(mensalidade);
				if(novoStatus == mensalidade.Status) return false;
				mensalidade.Status = novoStatus;
				return _mensalidadeRepository.AtualizarStatus(mensalidade);
            }
			catch (Exception)
			{

				throw;
			}

		}
    }
}

