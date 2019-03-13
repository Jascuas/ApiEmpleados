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
        [Required(ErrorMessage = "Necesita un nombre.")]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "Necesita un apellido.")]
        public String Apellidos { get; set; }
        [Required(ErrorMessage = "Necesita un email.")]
        [EmailAddress(ErrorMessage = "Necesita un email valido.")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Necesita una contraseña.")]
        public String Password { get; set; }
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public String PasswordConfirm { get; set; }
    }
}
