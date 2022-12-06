using KNG8_Api.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KNG8_Api.Models
{
    public class BitacoraModel
    {

        public void Registrar_Bitacora(string correo, Exception ex, string origen)
        {
            using (var conn = new KNG8_ProjectEntities())   
            {
                conn.Registrar_Bitacora(correo, DateTime.Now, ex.HResult, ex.Message, origen);
            }
        }

    }
}