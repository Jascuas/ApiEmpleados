using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Models
{

    public class Producto 
    {
        public int Id_Producto { get; set; }
        public String Nombre { get; set; }
        public double Precio { get; set; }
        public String Imagen { get; set; }
        public Producto(int id_producto, string nombre, double precio, string imagen)
        {
            Id_Producto = id_producto;
            Nombre = nombre;
            Precio = precio;
            Imagen = imagen;
        }

        public Producto()
        {
        }
    }
}
