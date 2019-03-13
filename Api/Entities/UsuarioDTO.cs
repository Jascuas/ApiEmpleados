using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Entities
{
    [Table("USUARIOS")]
    public class UsuarioDTO
    {
        [Key]
        [Column("ID_USUARIO")]
        public int? Id_Usuario { get; set; }
        [Column("PASSWORD")]
        [Required(ErrorMessage = "Necesita una password.")]
        public String Password { get; set; }
        [Column("NOMBRE_USUARIO")]
        [Required(ErrorMessage = "Necesita un nombre de usuario.")]
        public String User { get; set; }
        [Column("NOMBRE")]
        [Required(ErrorMessage = "Necesita un nombre.")]
        public String Nombre { get; set; }
        [Column("APELLIDOS")]
        [Required(ErrorMessage = "Necesita los apellidos.")]
        public String Apellidos { get; set; }
        [Column("EMAIL")]
        [Required(ErrorMessage = "Necesita un email.")]
        public String Email { get; set; }
        [Column("ROLE")]
        [Required(ErrorMessage = "Necesita un rol.")]
        public String Rol { get; set; }
        [Column("FECHA_REGISTRO")]
        [Required(ErrorMessage = "Necesita una fecha de registro.")]
        public DateTime Fecha { get; set; }

        
        public UsuarioDTO(){}
        public UsuarioDTO(string password, string user, string nombre, string apellidos, string email, string rol, DateTime fecha)
        {
            Password = password;
            User = user;
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            Rol = rol;
            Fecha = fecha;
        }

    }
}
