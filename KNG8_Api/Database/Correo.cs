//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KNG8_Api.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Correo
    {
        public int ConsecutivoCorreos { get; set; }
        public int ConsecutivoUsuario { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public System.DateTime FechaHora { get; set; }
    }
}