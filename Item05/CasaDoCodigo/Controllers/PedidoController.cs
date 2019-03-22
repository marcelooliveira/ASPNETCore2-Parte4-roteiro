using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using CasaDoCodigo.Repositories;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository,
            IPedidoRepository pedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
        }

        public async Task<IActionResult> Carrossel()
        {
            return View(await produtoRepository.GetProdutosAsync());
        }

        public async Task<IActionResult> BuscaProdutos(string pesquisa)
        {
            return View(await produtoRepository.GetProdutosAsync(pesquisa));
        }

        [Authorize]
        public async Task<IActionResult> Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                await pedidoRepository.AddItemAsync(codigo, GetUserId());
            }

            var pedido = await pedidoRepository.GetPedidoAsync(GetUserId());
            List<ItemPedido> itens = pedido.Itens;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return base.View(carrinhoViewModel);
        }

        [Authorize]
        public async Task<IActionResult> Cadastro()
        {
            var pedido = await pedidoRepository.GetPedidoAsync(GetUserId());

            if (pedido == null)
            {
                return RedirectToAction("Carrossel");
            }

            return View(pedido.Cadastro);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Resumo(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                return View(await pedidoRepository.UpdateCadastroAsync(cadastro, GetUserId()));
            }
            return RedirectToAction("Cadastro");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<UpdateQuantidadeResponse> UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            return await pedidoRepository.UpdateQuantidadeAsync(itemPedido, GetUserId());
        }

        [Authorize]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

        private string GetUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x
                => new[] {
                    JwtClaimTypes.Subject, ClaimTypes.NameIdentifier
                }.Contains(x.Type)
                && !string.IsNullOrWhiteSpace(x.Value));

            if (userIdClaim != null)
                return userIdClaim.Value;

            return null;
        }
    }
}
