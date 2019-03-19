using CasaDoCodigo.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> AddCategoriaAsync(string categoriaNome);
    }

    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<Categoria> AddCategoriaAsync(string categoriaNome)
        {
            var categoriaDB =
                dbSet
                    .Where(c => c.Nome == categoriaNome)
                    .SingleOrDefault();

            if (categoriaDB == null)
            {
                categoriaDB = new Categoria(categoriaNome);
                await dbSet.AddAsync(categoriaDB);
                await contexto.SaveChangesAsync();
            }
            return categoriaDB;
        }

    }
}
