using KNG8_Api.Database;
using KNG8_Api.Models.Mailer;
using System;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.WebPages;

namespace KNG8_Api.Controllers
{
    public class HomeController : Controller
    {
        private mailObjeto mailObjeto = new mailObjeto();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            //  sendEmail();

            // saveEmailDB();

            return View();
        }

        public void sendEmail()
        {
            try
            {
                if (mailObjeto.to.IsEmpty() || mailObjeto.from.IsEmpty() || mailObjeto.subject.IsEmpty() || mailObjeto.body.IsEmpty())
                {
                    Console.WriteLine("Ingresar información correctamente");
                }
                else
                {
                    MailAddress from = new MailAddress(mailObjeto.from, "Progra Avanzada");

                    MailAddress to = new MailAddress(mailObjeto.to, "Receptor");

                    MailMessage message = new MailMessage(from, to);

                    message.Subject = mailObjeto.subject;

                    message.Body = mailObjeto.body;

                    // Add a carbon copy recipient.

                    MailAddress copy = new MailAddress(mailObjeto.cc);

                    message.CC.Add(copy);

                    SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

                    client.Port = 587;

                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    // Include credentials if the server requires them.

                    client.Credentials = new System.Net.NetworkCredential(mailObjeto.from, mailObjeto.contrasenna);

                    client.EnableSsl = true;

                    Console.WriteLine("Sending an email message to {0} by using the SMTP host {1}.", to.Address, client.Host);

                    client.Send(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please provide a correct Email Address",
                    ex.ToString());
            }
        }

        public void saveEmailDB()
        {
            using (var conn = new KNG8_ProjectEntities())
            {
                var resultado = conn.Registrar_Correo(mailObjeto.to, 1, DateTime.Now, mailObjeto.cc, mailObjeto.subject, mailObjeto.body);
            }
        }
    }
}