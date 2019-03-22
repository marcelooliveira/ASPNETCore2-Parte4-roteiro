using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> GetPedidoAsync(string clienteId);
        Task AddItemAsync(string codigo, string clienteId);
        Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemPedido itemPedido, string clienteId);
        Task<Pedido> UpdateCadastroAsync(Cadastro cadastro, string clienteId);
    }

    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly ICadastroRepository cadastroRepository;

        public PedidoRepository(ApplicationContext contexto,
            IHttpContextAccessor contextAccessor,
            ICadastroRepository cadastroRepository) : base(contexto)
        {
            this.contextAccessor = contextAccessor;
            this.cadastroRepository = cadastroRepository;
        }

        public async Task AddItemAsync(string codigo, string clienteId)
        {
            var produto = await
                            contexto.Set<Produto>()
                            .Where(p => p.Codigo == codigo)
                            .SingleOrDefaultAsync();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = await GetPedidoAsync(clienteId);

            var itemPedido = await
                                contexto.Set<ItemPedido>()
                                .Where(i => i.Produto.Codigo == codigo
                                        && i.Pedido.Id == pedido.Id)
                                .SingleOrDefaultAsync();

            if (itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                await
                    contexto.Set<ItemPedido>()
                    .AddAsync(itemPedido);

                await contexto.SaveChangesAsync();
            }
        }

        public async Task<Pedido> GetPedidoAsync(string clienteId)
        {
            var pedidoId = GetPedidoId(clienteId);
            var pedido = 
                await dbSet
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                        .ThenInclude(prod => prod.Categoria)
                .Include(p => p.Cadastro)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefaultAsync();

            if (pedido == null)
            {
                pedido = new Pedido(clienteId, new Cadastro());
                await dbSet.AddAsync(pedido);
                await contexto.SaveChangesAsync();
                SetPedidoId(clienteId, pedido.Id);
            }

            return pedido;
        }

        private int? GetPedidoId(string clienteId)
        {
            return contextAccessor.HttpContext.Session.GetInt32($"pedidoId_{clienteId}");
        }

        private void SetPedidoId(string clienteId, int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32($"pedidoId_{clienteId}", pedidoId);
        }

        private void ResetPedidoId(string clienteId)
        {
            contextAccessor.HttpContext.Session.Remove($"pedidoId_{clienteId}");
        }

        public async Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemPedido itemPedido, string clienteId)
        {
            var itemPedidoDB = await GetItemPedidoAsync(itemPedido.Id);

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                if (itemPedido.Quantidade == 0)
                {
                    await RemoveItemPedidoAsync(itemPedido.Id);
                }

                await contexto.SaveChangesAsync();

                var pedido = await GetPedidoAsync(clienteId);
                var carrinhoViewModel = new CarrinhoViewModel(pedido.Itens);

                return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);
            }

            throw new ArgumentException("ItemPedido não encontrado");
        }

        public async Task<Pedido> UpdateCadastroAsync(Cadastro cadastro, string clienteId)
        {
            var pedido = await GetPedidoAsync(clienteId);
            await cadastroRepository.UpdateAsync(pedido.Cadastro.Id, cadastro);
            ResetPedidoId(clienteId);
            return pedido;
        }

        private async Task<ItemPedido> GetItemPedidoAsync(int itemPedidoId)
        {
            return
            await contexto.Set<ItemPedido>()
                .Where(ip => ip.Id == itemPedidoId)
                .SingleOrDefaultAsync();
        }

        private async Task RemoveItemPedidoAsync(int itemPedidoId)
        {
            contexto.Set<ItemPedido>()
                .Remove(await GetItemPedidoAsync(itemPedidoId));
        }
    }
}
