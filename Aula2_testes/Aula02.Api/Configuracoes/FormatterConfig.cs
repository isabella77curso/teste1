using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Globalization;
using System.Web.Http;

namespace Aula02.Api.Configuracoes
{
    public class FormatterConfig
    {

        public static void Configure(HttpConfiguration configuration)
        {
            configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);

            ConfigJson(configuration.Formatters.JsonFormatter.SerializerSettings);
        }

        private static void ConfigJson(JsonSerializerSettings settings)
        {
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            settings.DateFormatString = "dd/MM/yyyy";
            settings.Culture = CultureInfo.CurrentCulture;
        }
    }
}