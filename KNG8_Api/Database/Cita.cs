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
    
    public partial class Cita
    {
        public int CitaID { get; set; }
        public int ConsecutivoUsuario { get; set; }
        public int TipoID { get; set; }
        public int UsuarioID { get; set; }
        public System.DateTime FechaHora { get; set; }
        public string DescripcionCitas { get; set; }
    
        public virtual TiposCita TiposCita { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
