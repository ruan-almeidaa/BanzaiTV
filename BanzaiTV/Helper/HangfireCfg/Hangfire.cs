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
                dbContext.Database.ExecuteSqlRaw("UPDATE [Mensalidades] SET [Status] = 3 WHERE GETDATE() > [DataVencimento] AND [DataPagamento] IS NULL;");

            }
        }

        public void AtualizarStatusRenovacaoClientes()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BancoContext>();

                dbContext.Database.ExecuteSqlRaw(@"
                                                    UPDATE c
                                                    SET c.[Status] = 2
                                                    FROM [Clientes] c
                                                    INNER JOIN (
                                                        SELECT [ClienteId], MAX([DataVencimento]) AS ultima_mensalidade
                                                        FROM [Mensalidades]
                                                        GROUP BY [ClienteId]
                                                    ) m ON c.[Id] = m.[ClienteId]
                                                    WHERE MONTH(m.ultima_mensalidade) = MONTH(GETDATE())
                                                    AND YEAR(m.ultima_mensalidade) = YEAR(GETDATE());
                                                ");

            }
        }
    }
}
