using Microsoft.AspNetCore.Http;
using Halo.IO.Json;

namespace Halo.Plugins
{
    public interface IRpcPlugin
    {
        void PreProcess(HttpContext context, string method, JArray _params);
        JObject OnProcess(HttpContext context, string method, JArray _params);
        void PostProcess(HttpContext context, string method, JArray _params, JObject result);
    }
}
