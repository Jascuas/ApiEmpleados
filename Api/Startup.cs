using System;
using System.Threading.Tasks;
using System.Web.Http;
using Api;
using ApiOberon.Helper;
using AutoMapper;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(ApiOberon.Startup))]

namespace ApiOberon
{
    public class Startup
    {
        public void ConfigurarOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions opcionesautorizacion
                = new OAuthAuthorizationServerOptions()
                {
                    //PERMITIMOS AUTORIZACIONES HTTP
                    AllowInsecureHttp = true,
                    //INCLUIMOS UNA RUTA PARA ACCEDER A LA GENERACION
                    //DEL TOKEN
                    TokenEndpointPath = new PathString("/recuperartoken"),
                    //TIEMPO QUE EL TOKEN NOS PERMITIRA ACCEDER A LAS
                    //PETICIONES GET SIN NECESIDAD DE GENERAR NINGUN OTRO
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    //CLASE ENCARGADA DE VALIDAR SI EL USUARIO
                    //TIENE ACCESO A LA GENERACION DE TOKENS
                    Provider = new Credentials.AutorizacionCredencialesToken(),
                };
            //AÑADIMOS LA AUTORIZACION A NUESTRA APLICACION
            app.UseOAuthAuthorizationServer(opcionesautorizacion);
            //AHORA INDICAMOS QUE LA AUTORIZACION ESTARA
            //ACTIVA MEDIANTE BEARER (OAUTH 2.0)
            OAuthBearerAuthenticationOptions opcionesoauth =
                new OAuthBearerAuthenticationOptions()
                {
                    AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
                };
            app.UseOAuthBearerAuthentication(opcionesoauth);
        }
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            //REGISTRAMOS LA CLASE DE CONFIGURACION
            //DE APIS
            WebApiConfig.Register(config);
            //INCLUIMOS EL METODO QUE SE 
            //ENCARGARA DE LAS PETICIONES MIDDLEWARE
            ConfigurarOAuth(app);
            //ANTES DE LAS PETICIONES, EL METODO
            //HABRA AUTORIZADO LOS TOKENS
            //POR LO QUE INDICAMOS DESPUES QUE
            //CONFIGURACION UTILIZARA NUESTRO API
            UserProfile profile = new UserProfile();
            Mapper.Initialize(cfg => {
                cfg.AddProfile(profile);
            });
            app.UseWebApi(config);
        }


    }
}
