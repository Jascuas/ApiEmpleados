﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        public Pedido()
        {
        }


        [Key]
        [Column("Id_Pedido")]
        public int id_pedido { get; set; }
        [Column("Id_Usuario")]
        public int id_Usuario { get; set; }
        [Column("Fecha_Pedido")]
        public DateTime fecha_Pedido { get; set; }
        [Column("Total")]
        public double total { get; set; }
        
    }
}
