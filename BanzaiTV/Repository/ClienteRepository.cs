using BanzaiTV.Database;
using BanzaiTV.Interfaces;
using BanzaiTV.Models;
using Microsoft.EntityFrameworkCore;

namespace BanzaiTV.Repository
{
    public class ClienteRepository : IClienteRepository

    {
        private readonly BancoContext _bancoContext;

        public ClienteRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ClienteModel> BuscarTodos()
        {
            return _bancoContext.Clientes
                                        .Include(c => c.Plano)
                                        .ToList();
        }

        public ClienteModel Cadastrar(ClienteModel cliente)
        {
            try
            {
                _bancoContext.Clientes.Add(cliente);
                _bancoContext.SaveChanges();
                return cliente;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ClienteModel BuscaPorId(int id)
        {
            try
            {
                return _bancoContext.Clientes
                                            .Include(c => c.Plano)
                                            .FirstOrDefault(c => c.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClienteModel Editar(ClienteModel cliente)
        {
            try
            {
                _bancoContext.ChangeTracker.Clear();
                _bancoContext.Clientes.Update(cliente);
                _bancoContext.SaveChanges();
                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Excluir(ClienteModel cliente)
        {
            try
            {
                _bancoContext.Clientes.Remove(cliente);
                _bancoContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
