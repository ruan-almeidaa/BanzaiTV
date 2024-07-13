using BanzaiTV.Database;
using BanzaiTV.Interfaces;
using BanzaiTV.Models;

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
            return _bancoContext.Clientes.ToList();
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
                return _bancoContext.Clientes.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClienteModel Editar(ClienteModel p_cliente)
        {
            try
            {
                ClienteModel clienteNoBanco = BuscaPorId(p_cliente.Id);

                if (clienteNoBanco != null) {
                    clienteNoBanco.Nome = p_cliente.Nome;
                    clienteNoBanco.Email = p_cliente.Email;
                    clienteNoBanco.Celular = p_cliente.Celular;
                    clienteNoBanco.Cpf = p_cliente.Cpf;
                    clienteNoBanco.DiaVencimento = p_cliente.DiaVencimento;
                    clienteNoBanco.PlanoId = p_cliente.PlanoId;
                    clienteNoBanco.Ativo = p_cliente.Ativo;

                    _bancoContext.Clientes.Update(clienteNoBanco);
                    _bancoContext.SaveChanges();
                    return clienteNoBanco;


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
