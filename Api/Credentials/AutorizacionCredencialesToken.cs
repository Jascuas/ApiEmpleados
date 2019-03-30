using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using ApiOberon.Models;
using ApiOberon.Repositories;
using ApiOberon.Entities;

namespace ApiOberon.Credentials
{
    public class AutorizacionCredencialesToken : OAuthAuthorizationServerProvider
    {
        RepositoryOberon repo;

        public AutorizacionCredencialesToken()
        {
            this.repo = new RepositoryOberon();
        }
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.CompletedTask;
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //INCLUIMOS EN LA CABECERA DEL CONTEXTO QUE ESTAMOS
            //CONTROLANDO LOS PERMISOS DE ACCESO
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //MEDIANTE NUESTRA ENTIDAD, VALIDAMOS LOS DATOS QUE
            //NOS ESTAN LLEGANDO AL SERVIDOR PARA LA GENERACION
            //DE UN USUARIO
            //EL CONTEXTO TRAERA EN SU CABECERA LA INFORMACION
            //DE USERNAME Y PASSWORD, QUE SON ELEMENTOS ESTATICOS
            //DE LAS PETICIONES
            LoginCredentials credentials = new LoginCredentials(context.UserName, context.Password);
            UsuarioDTO user = repo.LoginUsuario(credentials);
            //EN CASO DE QUE EL USUARIO NO EXISTA
            //INCLUIMOS UN ERROR EN LA PETICION Y NO CONTINUARA
            //REALIZANDO PETICIONES
            if (user == null)
            {
                context.SetError("Acceso denegado", "El usuario/password son incorrectos.");
                return Task.CompletedTask;
            }
            UsuarioDTO u = this.repo.ExisteUsuario(credentials);
            if (u == null)
            {
                context.SetError("Acceso denegado", "El usuario o el email no existen en nuestra plataforma.");
                return Task.CompletedTask;
            }
            u = this.repo.LoginUsuario(credentials);
            if (u == null)
            {
                context.SetError("Acceso denegado", "La contraseña no coincide para este usuario.");
                return Task.CompletedTask;
            }

            //SI EL EMPLEADO EXISTE, NOS CREAMOS UN NUEVO OBJETO CLAIM
            //QUE INTRODUCE AL USUARIO DENTRO DEL SERVIDOR CON
            //LA VALIDACION DE "TERCEROS", ES DECIR, UNA VALIDACION
            //DE GOOGLE O FACEBOOK, O UNA VALIDACION POR TOKENS
            //PERSONALIZADAS COMO ESTAMOS REALIZANDO NOSOTROS
            ClaimsIdentity identidad = new ClaimsIdentity(context.Options.AuthenticationType);
            //ALMACENAMOS EL PASSWORD QUE EN NUESTRO EJEMPLO ES
            //EL ID DEL EMPLEADO PARA TENER ACCESO EN NUESTRA APLICACION
            identidad.AddClaim(new Claim(ClaimTypes.Name, user.Id_Usuario.ToString()));
            //EL ROLE INDICARA EL GRUPO AL QUE PERTENECE
            //POR SI DESEAMOS INCLUIR POSTERIORMENTE CABECERAS
            //EN LOS METODOS GET TALES COMO [Authorization(Roles=...)]
            identidad.AddClaim(new Claim(ClaimTypes.Role, user.Rol));
            context.Validated(identidad);
            return Task.CompletedTask;
        }
    }
}
