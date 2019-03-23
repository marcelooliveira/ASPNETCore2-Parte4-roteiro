using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CasaDoCodigo
{
    public interface IHttpHelper
    {
        IConfiguration Configuration { get; }
        int? GetPedidoId(string clienteId);
        void SetPedidoId(string clienteId, int pedidoId);
        void ResetPedidoId(string clienteId);
    }
}