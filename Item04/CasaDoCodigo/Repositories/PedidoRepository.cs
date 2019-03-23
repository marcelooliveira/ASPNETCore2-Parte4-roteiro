using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        private readonly IHttpHelper httpHelper;
        private readonly ICadastroRepository cadastroRepository;

        public PedidoRepository(IConfiguration configuration,
            ApplicationContext contexto,
            IHttpContextAccessor contextAccessor,
            IHttpHelper sessionHelper,
            ICadastroRepository cadastroRepository) : base(configuration, contexto)
        {
            this.contextAccessor = contextAccessor;
            this.httpHelper = sessionHelper;
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
            var pedidoId = httpHelper.GetPedidoId(clienteId);
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
                httpHelper.SetPedidoId(clienteId, pedido.Id);
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
            httpHelper.ResetPedidoId(clienteId);
            await GerarRelatorio(pedido);
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

        private async Task GerarRelatorio(Pedido pedido)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(
$@"
=============================================
No. Pedido: {pedido.Id:00000}
Cliente: 
    Nome: {pedido.Cadastro.Nome}
    Endereco: {pedido.Cadastro.Endereco} {pedido.Cadastro.Complemento}  {pedido.Cadastro.Bairro}  {pedido.Cadastro.Municipio}  {pedido.Cadastro.UF}
    Fone: {pedido.Cadastro.Telefone}
    Email: {pedido.Cadastro.Email}
    Total: {pedido.Itens.Sum(i => i.Subtotal):C2}
Itens:
");

                foreach (var i in pedido.Itens)
                {
                    sb.AppendLine(
$@"
    Código: {i.Produto.Codigo:00000}
    Preco Unitário: {i.PrecoUnitario:00000}
    Descrição: {i.Produto.Nome}
    Quantidade: {i.Quantidade:000}
    Subtotal: {i.Subtotal:C2}");
                }
                sb.AppendLine($@"=============================================
");
                var json = JsonConvert.SerializeObject(sb.ToString());
                using (HttpContent content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    await System.IO.File.AppendAllLinesAsync("Relatorio.txt", new string[] { sb.ToString() });
                }
            }
        }
    }
}
