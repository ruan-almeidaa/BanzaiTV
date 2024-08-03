using Microsoft.EntityFrameworkCore;

namespace BanzaiTV.Database
{
    public static class InitDb
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<BancoContext>();
            context.Database.Migrate();

        }
    }
}
