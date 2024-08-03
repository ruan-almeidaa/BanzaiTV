using BanzaiTV.Database;
using BanzaiTV.Enums.MensalidadesEnums;
using BanzaiTV.Interfaces.IRepository;
using BanzaiTV.Models;
using Microsoft.EntityFrameworkCore;

namespace BanzaiTV.Repository
{
    public class MensalidadeRepository : IMensalidadeRepository
    {

        private readonly BancoContext _bancoContext;
        public MensalidadeRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public bool AtualizarStatus (MensalidadeModel mensalidade)
        {
            try
            {
                _bancoContext.ChangeTracker.Clear();
                _bancoContext.Entry(mensalidade).Property(m => m.Status).IsModified = true;
                _bancoContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
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

        public List<MensalidadeModel> BuscarMensalidadesDeCliente(int idCliente)
        {
            try
            {
                return _bancoContext.Mensalidades
                                                .Where(m => m.ClienteId  == idCliente)
                                                .OrderBy(m => m.DataVencimento)
                                                .ToList();
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
                return _bancoContext.Mensalidades
                                                .Include(m => m.Cliente)
                                                .OrderBy(m => m.DataVencimento)
                                                .ToList();
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
                return _bancoContext.Mensalidades
                                                .Where(m => m.ClienteId == idCliente)
                                                .OrderByDescending(m => m.DataVencimento)
                                                .FirstOrDefault();
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

        public bool Excluir(MensalidadeModel mensalidade)
        {
            try
            {
                _bancoContext.Mensalidades.Remove(mensalidade);
                _bancoContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ExcluirTodasMensalidadesDoCliente(ClienteModel cliente)
        {
            try
            {
                //Busca todas as mensalidades do cliente
                List <MensalidadeModel> mensalidadesParaExcluir = _bancoContext.Mensalidades
                                                                        .Where(m => m.ClienteId == cliente.Id)
                                                                        .ToList();

                // Remove as mensalidades do contexto
                _bancoContext.Mensalidades.RemoveRange(mensalidadesParaExcluir);

                // Salva as alterações no banco de dados
                _bancoContext.SaveChanges();
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
                return _bancoContext.Mensalidades.Any(m => m.PlanoId == idPlano && m.DataPagamento == null);
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
                if (mesReferencia == null || anoReferencia == null)
                {
                    return _bancoContext.Mensalidades
                                                    .Where(m => m.Status == StatusEnum.Atrasada)
                                                    .Count();

                }
                else
                {
                    return _bancoContext.Mensalidades
                                                    .Where(m => m.DataVencimento.Month == mesReferencia &&
                                                            m.DataVencimento.Year == anoReferencia && 
                                                            m.Status == StatusEnum.Atrasada)
                                                    .Count();

                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        public int QuantidadePagas(int? mesReferencia, int? anoReferencia)
        {
            if (mesReferencia == null || anoReferencia == null)
            {
                return _bancoContext.Mensalidades
                                                .Where(m => m.Status == StatusEnum.Paga && m.DataPagamento != null)
                                                .Count();

            }
            else
            {
                return _bancoContext.Mensalidades
                                                .Where(m => m.DataVencimento.Month == mesReferencia &&
                                                        m.DataVencimento.Year == anoReferencia &&
                                                        m.Status == StatusEnum.Paga &&
                                                        m.DataPagamento != null)
                                                .Count();
            }
        }

        public int QuantidadePendentes(int? mesReferencia, int? anoReferencia)
        {
            try
            {
                if(mesReferencia == null || anoReferencia == null)
                {
                    return _bancoContext.Mensalidades
                                                    .Where(m => m.Status == StatusEnum.Pendente)
                                                    .Count();

                }
                else
                {
                    return _bancoContext.Mensalidades
                                                    .Where(m => m.DataVencimento.Month == mesReferencia &&
                                                            m.DataVencimento.Year == anoReferencia &&
                                                            m.Status == StatusEnum.Pendente)
                                                    .Count();
                }


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
                if (mesReferencia == null || anoReferencia == null)
                {
                    return _bancoContext.Mensalidades
                                                    .Where(m => m.DataPagamento == null)
                                                    .Sum(m => m.Valor);

                }
                else
                {
                    return _bancoContext.Mensalidades
                                                    .Where(m => m.DataVencimento.Month == mesReferencia &&
                                                            m.DataVencimento.Year == anoReferencia &&
                                                            m.DataPagamento == null)
                                                    .Sum(m => m.Valor);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
