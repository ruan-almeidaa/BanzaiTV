using BanzaiTV.Database;
using Microsoft.EntityFrameworkCore;

namespace BanzaiTV.Helper.HangfireCfg
{
    public class Hangfire
    {
        private readonly IServiceProvider _serviceProvider;

        public Hangfire(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void UpdateMensalidade()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BancoContext>();
                dbContext.Database.ExecuteSqlRaw("UPDATE \"Mensalidades\" SET \"Atrasada\" = TRUE WHERE CURRENT_TIMESTAMP > \"DataVencimento\" AND \"DataPagamento\" IS NULL;");
            }
        }
    }
}
