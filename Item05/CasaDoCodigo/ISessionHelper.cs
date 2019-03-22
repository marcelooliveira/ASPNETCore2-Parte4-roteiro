using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CasaDoCodigo
{
    public interface ISessionHelper
    {
        IConfiguration Configuration { get; }

        Task<string> GetAccessToken(string scope);
        int? GetPedidoId(string clienteId);
        void SetAccessToken(string accessToken);
        void SetPedidoId(string clienteId, int pedidoId);
    }
}