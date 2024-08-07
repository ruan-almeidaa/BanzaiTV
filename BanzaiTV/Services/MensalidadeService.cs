﻿using BanzaiTV.Enums.MensalidadesEnums;
using BanzaiTV.Interfaces.IRepository;
using BanzaiTV.Interfaces.IService;
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

		public void LancarMensalidadesDoCliente(ClienteModel cliente, bool ehRenovacao)
		{

			try
			{
                DateTime dataAtual = DateTime.Now;
                int mensalidadesCriadas = 1;

                if (ehRenovacao)
				{
                    MensalidadeModel ultimaMensalidadeCliente = BuscaUltimaMensalidadeCliente(cliente.Id);
					dataAtual = ultimaMensalidadeCliente.DataVencimento;
                }
				
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
                        Cliente = cliente,
						PlanoId = cliente.PlanoId,
						Plano = cliente.Plano
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

        public void RecriarMensalidadesDoCliente(ClienteModel cliente)
        {
			try
			{
				ExcluirMensalidadesDoCliente(cliente, null);
                LancarMensalidadesDoCliente(cliente, false);

            }
			catch (Exception)
			{

				throw;
			}
        }

		public void ExcluirMensalidadesDoCliente(ClienteModel cliente, StatusEnum? status)
        {
			try
			{
				if(status == null) _mensalidadeRepository.ExcluirTodasMensalidadesDoCliente(cliente);
				//Por enquanto esse método apaga todas as mensalidades, mas será evoluído para filtrar por status.

			}
			catch (Exception)
			{

				throw;
			}
        }

        public MensalidadeModel BuscaUltimaMensalidadeCliente(int idCliente)
        {
			try
			{
				return _mensalidadeRepository.BuscaUltimaMensalidadeCliente(idCliente);
			}
			catch (Exception)
			{

				throw;
			}
        }

        public bool PlanoTemMensalidadesPendentes(int idPlano)
        {
			try
			{
				return _mensalidadeRepository.PlanoTemMensalidadesPendentes(idPlano);
			}
			catch (Exception)
			{

				throw;
			}
        }

        public int QuantidadeAtrasadas(int? mesReferencia, int? anoReferencia)
        {
			try
			{
				return _mensalidadeRepository.QuantidadeAtrasadas(mesReferencia,anoReferencia);
			}
			catch (Exception)
			{

				throw;
			}
        }

        public int QuantidadePendentes(int? mesReferencia, int? anoReferencia)
        {
			try
			{
				if(mesReferencia.HasValue && anoReferencia.HasValue) return _mensalidadeRepository.QuantidadePendentes(mesReferencia, anoReferencia);
                return _mensalidadeRepository.QuantidadePendentes(null, null);

            }
			catch (Exception)
			{

				throw;
			}
        }

        public int QuantidadePagas(int? mesReferencia, int? anoReferencia)
        {
			try
			{
                if (mesReferencia.HasValue && anoReferencia.HasValue) return _mensalidadeRepository.QuantidadePagas(mesReferencia, anoReferencia);
                return _mensalidadeRepository.QuantidadePagas(null, null);

            }
			catch (Exception)
			{

				throw;
			}
        }

        public double ValorAhReceber(int? mesReferencia, int? anoReferencia)
        {
			try
			{
				double valorAhReceber = 0;
                if (mesReferencia.HasValue && anoReferencia.HasValue)
				{
                    valorAhReceber = _mensalidadeRepository.ValorAhReceber(mesReferencia, anoReferencia);
				}
				else
				{
					valorAhReceber = _mensalidadeRepository.ValorAhReceber(null, null);
				}

                return Math.Truncate(valorAhReceber * 100) / 100;


            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}

