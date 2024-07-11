using BanzaiTV.Models;
using Microsoft.EntityFrameworkCore;

namespace BanzaiTV.Database
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext>options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<PlanoModel> Planos { get; set; }
        public DbSet<AdministradorModel> Administrador { get; set; }
    }
}
