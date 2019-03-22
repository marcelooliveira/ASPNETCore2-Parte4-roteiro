using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CasaDoCodigo.Carrinho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetAsync()
        {
            return Ok(await GetLivrosAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private static async Task<IEnumerable<Livro>> GetLivrosAsync()
        {
            var json = await System.IO.File.ReadAllTextAsync("livros.json");
            return JsonConvert.DeserializeObject<List<Livro>>(json);
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
}
