using BanzaiTV.Database;
using BanzaiTV.Enums.MensalidadesEnums;
using BanzaiTV.Interfaces;
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
                                                .Where(m => m.ClienteId  == idCliente && m.DataPagamento == null)
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
    }
}
