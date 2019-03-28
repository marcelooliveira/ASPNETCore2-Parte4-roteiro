using CasaDoCodigo.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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

        public void SetCadastro(string clienteId, Cadastro cadastro)
        {
            string json = JsonConvert.SerializeObject(cadastro.GetClone());
            contextAccessor.HttpContext.Session.SetString($"cadastro_{clienteId}", json);
        }

        public Cadastro GetCadastro(string clienteId)
        {
            string json = contextAccessor.HttpContext.Session.GetString($"cadastro_{clienteId}");
            if (string.IsNullOrWhiteSpace(json))
                return new Cadastro();

            return JsonConvert.DeserializeObject<Cadastro>(json);
        }

        public async Task<string> GetAccessToken(HttpClient client, string scope)
        {
            var response = await client.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = Configuration["IdentityUrl"] + "/connect/token",
                    ClientId = "CasaDoCodigo.MVC",
                    ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0",
                    Scope = scope
                });

            return response.AccessToken ?? response.Error;
        }
    }
}
