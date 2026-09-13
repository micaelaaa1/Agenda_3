using System;

namespace Agenda3.Entidades
{
    public class Contacto
    {
        public string DNI { get; set; }
        public string Apellido { get; set; }
        public string Nombres { get; set; }
        public string Calle { get; set; }
        public string Depto { get; set; }
        public string Piso { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string CUIL_CUIT { get; set; }
        public DateTime FechaAlta { get; set; }
        public string EstadoCivil { get; set; }
        public string Nacionalidad { get; set; }
        public string Provincia { get; set; }
        public string CodigoPostal { get; set; }
        public string Barrio { get; set; }
        public string TelefonoAlternativo { get; set; }
        public string Instagram { get; set; }
        public string ProfesionOcupacion { get; set; }
        public string EmpresaLugarTrabajo { get; set; }
        public string NivelEstudios { get; set; }
        public string Estado { get; set; }
        public string MetodoPagoPreferido { get; set; }
        public string Observaciones { get; set; }

        public CuentaCte CuentaCte { get; set; }
    }
}