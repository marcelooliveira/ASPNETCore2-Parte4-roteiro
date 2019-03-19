﻿using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    class DataService
    {
        public static async Task InicializaDBAsync(IWebHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var contexto = provider.GetService<ApplicationContext>();
                var produtoRepository = provider.GetService<IProdutoRepository>();

                await contexto.Database.MigrateAsync();

                List<Livro> livros = await GetLivrosAsync();

                await produtoRepository.SaveProdutosAsync(livros);
            }
        }

        private static async Task<List<Livro>> GetLivrosAsync()
        {
            var json = await File.ReadAllTextAsync("livros.json");
            return JsonConvert.DeserializeObject<List<Livro>>(json);
        }
    }
}
