﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace CasaDoCodigo.Relatorio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly List<string> Relatorio = new List<string>();

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Relatorio)
            {
                sb.AppendLine(item);
            }
            return sb.ToString();
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        public void PostAsync([FromBody] string value)
        {
            Relatorio.Add(value);
        }
    }
}
