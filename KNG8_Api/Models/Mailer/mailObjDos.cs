namespace KNG8_Api.Models.Mailer
{
    public class mailObjDos
    {
        public class ClaseCorreo
        {
            public string Destinatario { get; set; }
            public string CopiaDestinatario { get; set; }
            public string Asunto { get; set; }
            public string Mensaje { get; set; }
        }
    }
}