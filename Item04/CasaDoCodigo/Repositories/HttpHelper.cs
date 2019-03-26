using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CasaDoCodigo
{
    public class HttpHelper : IHttpHelper
    {
        private readonly IHttpContextAccessor contextAccessor;
        public IConfiguration Configuration { get; }

        public HttpHelper(IHttpContextAccessor contextAccessor, IConfiguration configuration)
        {
            this.contextAccessor = contextAccessor;
            Configuration = configuration;
        }

        public int? GetPedidoId(string clienteId)
        {
            return contextAccessor.HttpContext.Session.GetInt32($"pedidoId_{clienteId}");
        }

        public void SetPedidoId(string clienteId, int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32($"pedidoId_{clienteId}", pedidoId);
        }

        public void ResetPedidoId(string clienteId)
        {
            contextAccessor.HttpContext.Session.Remove($"pedidoId_{clienteId}");
        }
    }
}
