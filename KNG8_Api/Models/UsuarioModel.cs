using KNG8_Api.Database;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace KNG8_Api.Models
{
    public class UsuarioModel
    {
        public RespuestaUsuarioObj Validar_Usuario(UsuarioObj usuario)
        {
            using (var con = new KNG8_ProjectEntities())
            {
                var resultado = con.Consultar_Datos_Usuario(usuario.Correo, usuario.Contrasenna).FirstOrDefault();
                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();

                if (resultado != null)
                {
                    UsuarioObj usuarioEncontrado = new UsuarioObj();

                    usuarioEncontrado.ConsecutivoUsuario = resultado.ConsecutivoUsuario;
                    usuarioEncontrado.Correo = resultado.Correo;
                    usuarioEncontrado.NombreCompleto = resultado.NombreCompleto;
                    usuarioEncontrado.Estado = resultado.EstadoID;
                    usuarioEncontrado.TipoUsuario = resultado.RoleID;
                    usuarioEncontrado.Token = CrearToken(usuario.Correo);

                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.objeto = usuarioEncontrado;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron resultados";
                }

                return respuesta;
            }
        }

        private string CrearToken(string Correo)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, Correo)
            };

            var llave = "c3e59tjnx02ovqdd51nwjjyzmmylbdfh";
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(llave));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public RespuestaUsuarioObj Consultar_Usuarios_Estado()
        {
            using (var conn = new KNG8_ProjectEntities())
            {
                var resultado = conn.SelectUsersDescription().ToList();
                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();

                if (resultado.Count > 0)
                {
                    List<UsuarioObj> datos = new List<UsuarioObj>();

                    foreach (var item in resultado)
                    {
                        datos.Add(new UsuarioObj
                        {
                            
                            NombreCompleto = item.NombreCompleto,
                            Cedula = item.Cedula,
                            Correo = item.Correo,
                            DescriptionRole = item.Descripcion,
                            DescriptionStatus=item.Descripcion,
                            FechaNacimiento = item.FechaNacimiento,
                            telefono = item.Telefono,
                            expedienteID = (int)item.ExpedienteID,
                        });
                    }

                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.lista = datos;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron resultados";
                }

                return respuesta;
            }
        }

        public RespuestaroleObj consultar_Roles()
        {
            using (var conn = new KNG8_ProjectEntities())
            {
                var resultado = conn.SelectAllRoles().ToList();
                RespuestaroleObj respuesta = new RespuestaroleObj();

                if (resultado.Count > 0)
                {
                    List<roleObj> datos = new List<roleObj>();
                    foreach (var item in resultado)
                    {
                        datos.Add(new roleObj
                        {
                            RoleID = item.RoleID,
                            RoleDescription = item.Descripcion
                        });
                    }
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.lista = datos;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron resultados";
                }
                return respuesta;
            }
        }

        public RespuestatiposCitasObj consultar_Citas()
        {
            using (var conn = new KNG8_ProjectEntities())
            {
                var resultado = conn.SelectAllTiposCitas().ToList();
                RespuestatiposCitasObj respuesta = new RespuestatiposCitasObj();

                if (resultado.Count > 0)
                {
                    List<tiposCitasObj> datos = new List<tiposCitasObj>();
                    foreach (var item in resultado)
                    {
                        datos.Add(new tiposCitasObj
                        {
                            TipoID = item.TipoID,
                            TipoDescription = item.Descripcion
                        });
                    }
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.lista = datos;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron resultados";
                }
                return respuesta;
            }
        }

        public RespuestaBitacoraObj consultar_Bitacora()
        {
            using (var conn = new KNG8_ProjectEntities())
            {
                var resultado = conn.SelectAllErrors().ToList();
                RespuestaBitacoraObj respuesta = new RespuestaBitacoraObj();

                if (resultado.Count > 0)
                {
                    List<BitacoraObj> datos = new List<BitacoraObj>();
                    foreach (var item in resultado)
                    {
                        datos.Add(new BitacoraObj
                        {
                            UsuarioID = item.ConsecutivoUsuario,
                            fechaHora = item.FechaHora,
                            CodigoError = item.CodigoError,
                            Description = item.Descripcion,
                            Origen = item.Origen,
                        });
                    }
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.lista = datos;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron resultados";
                }
                return respuesta;
            }
        }
    }
}