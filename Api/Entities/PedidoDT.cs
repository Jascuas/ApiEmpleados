using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Entities
{
    public class PedidoDT
    {
        public int id_pedido { get; set; }
        public int id_Usuario { get; set; }
        public DateTime fecha_Pedido { get; set; }
        public double total { get; set; }
        public String url { get; set; }
    }
}
