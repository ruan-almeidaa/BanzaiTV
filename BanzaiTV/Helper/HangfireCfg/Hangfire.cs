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

        public void AtualizarStatusMensalidadesAtrasadas()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BancoContext>();
                dbContext.Database.ExecuteSqlRaw("UPDATE \"Mensalidades\" SET \"Status\" = 3 WHERE CURRENT_TIMESTAMP > \"DataVencimento\" AND \"DataPagamento\" IS NULL;");
            }
        }

        public void AtualizarStatusRenovacaoClientes()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BancoContext>();

                var sql = @"
                            UPDATE ""Clientes"" c
                            SET ""Status"" = 2
                            FROM ( 
                                    SELECT ""ClienteId"", MAX(""DataVencimento"") AS ultima_mensalidade 
                                    FROM ""Mensalidades""
                                    GROUP BY ""ClienteId""
                                  ) m
                            WHERE c.""Id"" = m.""ClienteId""
                            AND EXTRACT(MONTH FROM m.ultima_mensalidade) = EXTRACT(MONTH FROM CURRENT_DATE)
                            AND EXTRACT(YEAR FROM m.ultima_mensalidade) = EXTRACT(YEAR FROM CURRENT_DATE);";

                dbContext.Database.ExecuteSqlRaw(sql);
            }
        }
    }
}
