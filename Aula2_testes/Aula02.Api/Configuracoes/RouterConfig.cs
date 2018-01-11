using System.Web.Http;

namespace Aula02.Api.Configuracoes
{
    public class RouterConfig
    {

        public static void Configure(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();
        }
    }
}