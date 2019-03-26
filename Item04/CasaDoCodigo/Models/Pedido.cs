using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class Pedido : BaseModel
    {
        public Pedido()
        {
            Cadastro = new Cadastro();
        }

        public Pedido(string clienteId, Cadastro cadastro)
        {
            ClienteId = clienteId;
            Cadastro = cadastro;
        }

        public List<ItemPedido> Itens { get; private set; } = new List<ItemPedido>();

        [Required]
        public string ClienteId { get; private set; }

        [ForeignKey("CadastroId")]
        [Required]
        public virtual Cadastro Cadastro { get; private set; }
    }
}
