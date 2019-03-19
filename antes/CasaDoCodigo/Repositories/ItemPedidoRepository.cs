using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {
        Task<ItemPedido> GetItemPedidoAsync(int itemPedidoId);
        Task RemoveItemPedidoAsync(int itemPedidoId);
    }

    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<ItemPedido> GetItemPedidoAsync(int itemPedidoId)
        {
            return
            await dbSet
                .Where(ip => ip.Id == itemPedidoId)
                .SingleOrDefaultAsync();
        }

        public async Task RemoveItemPedidoAsync(int itemPedidoId)
        {
            dbSet.Remove(await GetItemPedidoAsync(itemPedidoId));
        }
    }
}
