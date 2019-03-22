using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        // POST api/values
        [Authorize]
        [HttpPost]
        public async Task PostAsync([FromBody] string value)
        {
            //Formato do item do relatório
            //============================
            //DATA E HORA       CLIENTE PEDIDO         COD PRODUTO  DESCRIÇÃO PRODUTO         PRECO UNITARIO        QTD TOTAL ITEM
            //22/03/2019 14:05  ALICE SMITH     0000000001     0123456      LIVRO DE PROGRAMAÇÃO              123,45        02         246,90

            await System.IO.File.AppendAllLinesAsync("Relatorio.txt", new string[] { value });
        }
    }
}
