using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CasaDoCodigo.Relatorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            return await System.IO.File.ReadAllLinesAsync("Relatorio.txt");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task PostAsync([FromBody] string value)
        {
            //Formato do item do relatório
            //============================
            //DATA E HORA       CLIENTE PEDIDO         COD PRODUTO  DESCRIÇÃO PRODUTO         PRECO UNITARIO        QTD TOTAL ITEM
            //22/03/2019 14:05  ALICE SMITH     0000000001     0123456      LIVRO DE PROGRAMAÇÃO              123,45        02         246,90

            await System.IO.File.AppendAllLinesAsync("Relatorio.txt", new string[] { value });
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
    }
}
