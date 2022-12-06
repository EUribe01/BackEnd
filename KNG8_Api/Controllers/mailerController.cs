using KNG8_Api.Models;
using KNG8_Api.Models.Mailer;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using static KNG8_Api.Models.Mailer.mailObjDos;

namespace KNG8_Api.Controllers
{
    public class mailerController : ApiController
    {
        private mailObjeto mailObjeto = new mailObjeto();

        public List<mailObjeto> SendEmail(mailObjeto mail)
        {
            return new List<mailObjeto>();
        }

        public RespuestaUsuarioObj EnviarCorreo(ClaseCorreo email)
        {
            if (email.Destinatario.Trim() != string.Empty)
            {
                string servidor = "smtp.office365.com";
                int puerto = 587;
                string CorreoNotificacion = ConfigurationManager.AppSettings["UsuarioCorreo"].ToString();
                string Clave = ConfigurationManager.AppSettings["ClaveCorreo"].ToString();

                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(CorreoNotificacion);
                correo.To.Add(email.Destinatario);

                if (email.CopiaDestinatario.Trim() != string.Empty)
                {
                    MailAddress copy = new MailAddress(email.CopiaDestinatario);
                    correo.CC.Add(copy);
                }

                correo.Subject = email.Asunto;
                correo.Body = email.Mensaje;
                correo.IsBodyHtml = false;
                correo.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = servidor;
                smtp.Port = puerto;
                smtp.EnableSsl = true;

                ServicePointManager.ServerCertificateValidationCallback = delegate
                (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };

                smtp.Credentials = new System.Net.NetworkCredential(CorreoNotificacion, Clave);

                smtp.Send(correo);

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = 1;
                respuesta.Mensaje = "Correo enviado";
                return respuesta;
            }
            else
            {
                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = 0;
                respuesta.Mensaje = "Correo no enviado";
                return respuesta;
            }
        }
    }
}