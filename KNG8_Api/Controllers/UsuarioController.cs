using KNG8_Api.Models;
using System;
using System.Reflection;
using System.Threading;
using System.Web.Http;

namespace KNG8_Api.Controllers
{
    public class UsuarioController : ApiController
    {
        private UsuarioModel instanciaUsuario = new UsuarioModel();
        private BitacoraModel instanciaBitacora = new BitacoraModel();

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Usuario/Validar_Usuario")]
        public RespuestaUsuarioObj Validar_Usuario(UsuarioObj usuario)
        {
            try
            {
                return instanciaUsuario.Validar_Usuario(usuario);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_Bitacora(usuario.Correo, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        // [AllowAnonymous]
        [HttpGet]
        [Route("api/Usuario/Consultar_Usuarios")]
        public RespuestaUsuarioObj Consultar_Usuarios()
        {
            var corrreoToken = Thread.CurrentPrincipal.Identity.Name;

            try
            {
                return instanciaUsuario.Consultar_Usuarios_Estado();
            }
            catch (Exception)
            {
                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error";
                return respuesta;
            }
        }

        // [AllowAnonymous]
        [HttpGet]
        [Route("api/Usuario/Consultar_Roles")]
        public RespuestaroleObj Consultar_Roles()
        {
            var corrreoToken = Thread.CurrentPrincipal.Identity.Name;

            try
            {
                return instanciaUsuario.consultar_Roles();
            }
            catch (Exception)
            {
                RespuestaroleObj respuesta = new RespuestaroleObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error";
                return respuesta;
            }
        }

        [HttpGet]
        [Route("api/Usuario/Consultar_Tipos_Citas")]
        public RespuestatiposCitasObj Consultar_TCitas()
        {
            var corrreoToken = Thread.CurrentPrincipal.Identity.Name;

            try
            {
                return instanciaUsuario.consultar_Citas();
            }
            catch (Exception)
            {
                RespuestatiposCitasObj respuesta = new RespuestatiposCitasObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error";
                return respuesta;
            }
        }

        [HttpGet]
        [Route("api/Usuario/Consultar_Bitacora")]
        public RespuestaBitacoraObj Consultar_Bitacora()
        {
            var corrreoToken = Thread.CurrentPrincipal.Identity.Name;

            try
            {
                return instanciaUsuario.consultar_Bitacora();
            }
            catch (Exception)
            {
                RespuestaBitacoraObj respuesta = new RespuestaBitacoraObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error";
                return respuesta;
            }
        }
    }
}