using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        Task SaveProdutosAsync(List<Livro> livros);
        Task<IList<Produto>> GetProdutosAsync();
        Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa);
    }

    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly ICategoriaRepository categoriaRepository;

        public ProdutoRepository(ApplicationContext contexto,
            ICategoriaRepository categoriaRepository) : base(contexto)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public async Task<IList<Produto>> GetProdutosAsync()
        {
            return await dbSet
                .Include(prod => prod.Categoria)
                .ToListAsync();
        }

        public async Task<BuscaProdutosViewModel> GetProdutosAsync(string pesquisa)
        {
            IQueryable<Produto> query = dbSet;

            if (!string.IsNullOrEmpty(pesquisa))
            {
                query = query.Where(q => q.Nome.Contains(pesquisa));
            }

            query = query
                .Include(prod => prod.Categoria);

            return new BuscaProdutosViewModel(await query.ToListAsync(), pesquisa);
        }

        public async Task SaveProdutosAsync(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                var categoria = await categoriaRepository.AddCategoriaAsync(livro.Categoria);

                if (!await dbSet.Where(p => p.Codigo == livro.Codigo).AnyAsync())
                {
                    await dbSet.AddAsync(new Produto(livro.Codigo, livro.Nome, livro.Preco, categoria));
                }
            }
            await contexto.SaveChangesAsync();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public decimal Preco { get; set; }
    }
}
