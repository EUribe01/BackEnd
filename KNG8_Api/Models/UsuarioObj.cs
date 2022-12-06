using System;
using System.Collections.Generic;

namespace KNG8_Api.Models
{
    public class UsuarioObj
    {
        public long ConsecutivoUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public int Cedula { get; set; }
        public string Correo { get; set; }
        public string Contrasenna { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int telefono { get; set; }
        public int roleID { get; set; }
        public int estadoID { get; set; }
        public int errorID { get; set; }
        public int expedienteID { get; set; }
        public int citaID { get; set; }
        public int Cronograma { get; set; }
        public int TipoUsuario { get; set; }
        public int Estado { get; set; }
        public string Token { get; set; }
        public string DescriptionRole { get; set; }
        public string DescriptionStatus { get; set; }   
    }

    public class RespuestaUsuarioObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public UsuarioObj objeto { get; set; }
        public List<UsuarioObj> lista { get; set; }
    }

    public class roleObj
    {
        public int RoleID { get; set; }
        public string RoleDescription { get; set; }
    }

    public class RespuestaroleObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public roleObj objeto { get; set; }
        public List<roleObj> lista { get; set; }
    }

    public class tiposCitasObj
    {
        public int TipoID { get; set; }
        public string TipoDescription { get; set; }
    }

    public class RespuestatiposCitasObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public tiposCitasObj objeto { get; set; }
        public List<tiposCitasObj> lista { get; set; }
    }

    public class BitacoraObj
    {
        public int UsuarioID { get; set; }
        public DateTime fechaHora { get; set; }
        public int CodigoError { get; set; }
        public string Description { get; set; }
        public string Origen { get; set; }
    }

    public class RespuestaBitacoraObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public BitacoraObj objeto { get; set; }
        public List<BitacoraObj> lista { get; set; }
    }
}