using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOberon.Entities
{
    public class LoginCredentials
    {
        public LoginCredentials(string identifier, string password)
        {
            Identifier = identifier;
            Password = password;
        }

        [Required(ErrorMessage = "Necesita un email o un nombre de usuario valido.")]
        public String Identifier { get; set; }
        [Required(ErrorMessage = "Necesita una contraseña correcta.")]
        public String Password { get; set; }
    }
}
