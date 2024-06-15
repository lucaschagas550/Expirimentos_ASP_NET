using Microsoft.AspNetCore.Mvc;
using TestTabelaResponivaBoostrap.Utils;

namespace TestTabelaResponivaBoostrap.Controllers.Base
{
    public class MainController : Controller
    {

        protected void SessionCreateKeyValue<T>(string key, T conteudo)
        {
            if (conteudo is not null)
                HttpContext.Session.SetString(key, JsonExtensions.SerializeObjectToJson(conteudo));
        }

        protected T? GetSessionValue<T>(string key) 
        {
            var sessionValue = HttpContext.Session.GetString(key);
            if (sessionValue is null)
                return default;

            var value = JsonExtensions.DeserializeJsonToObject<T>(sessionValue);
            if (value is null)
                return default;

            return value;
        }

        protected void ObterPerfilAutorizacao(string key) =>
            HttpContext.Session.Remove(key);
    }
}
