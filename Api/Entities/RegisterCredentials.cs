using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Entities
{
    
    public class RegisterCredentials
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Usuario { get; set; }
        public String Password { get; set; }
        public String User { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Email { get; set; }
        public String Rol { get; set; }
        public DateTime Fecha { get; set; }
        public RegisterCredentials(string password, string user, string nombre, string apellidos, string email,string rol, DateTime fecha)
        {
            Password = password;
            User = user;
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            Rol = rol;
            Fecha = fecha;
        }

        public RegisterCredentials()
        {
        }
    }
}
