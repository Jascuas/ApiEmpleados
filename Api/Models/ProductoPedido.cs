using ApiOberon.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Models
{
    public class ProductoPedido
    {
        public Talla Talla { get; set; }
        public int Unidades { get; set; }
    }
}
