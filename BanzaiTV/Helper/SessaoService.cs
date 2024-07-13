using BanzaiTV.Models;
using Newtonsoft.Json;
using System.Globalization;
using System.Text.Json.Serialization;

namespace BanzaiTV.Helper
{
    public class SessaoService : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;
        public SessaoService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public AdministradorModel BuscarSessao()
        {
            string sessaoAdministrador = _httpContext.HttpContext.Session.GetString("adminBanzaiTV");

            if (string.IsNullOrEmpty(sessaoAdministrador))
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<AdministradorModel>(sessaoAdministrador);

            }
        }

        public void CriarSessao(AdministradorModel administrador)
        {
            string valorSessao = JsonConvert.SerializeObject(administrador);
            _httpContext.HttpContext.Session.SetString("adminBanzaiTV", valorSessao);
        }

        public void RemoverSessao()
        {
            _httpContext.HttpContext.Session.Remove("adminBanzaiTV");
        }
    }
}
