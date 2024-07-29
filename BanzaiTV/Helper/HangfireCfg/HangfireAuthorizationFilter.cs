using Hangfire.Dashboard;

namespace BanzaiTV.Helper.HangfireCfg
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            string sessaoAdministrador = httpContext.Session.GetString("adminBanzaiTV");
            return !string.IsNullOrEmpty(sessaoAdministrador) ? true : false;
        }
    }

}
