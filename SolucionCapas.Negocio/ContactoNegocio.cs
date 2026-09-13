using System;
using Agenda3.Entidades;
using SolucionCapas.Datos;

namespace SolucionCapas.Negocio
{
    public class ContactoNegocio
    {
        private ContactoDatos _datos =
            new ContactoDatos();


        public Contacto BuscarPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return null;

            return _datos.BuscarPorDni(dni);
        }


        public bool Agregar(Contacto contacto)
        {
            if (contacto == null)
                return false;

            if (string.IsNullOrWhiteSpace(contacto.DNI))
                return false;

            if (string.IsNullOrWhiteSpace(contacto.Apellido))
                return false;

            if (string.IsNullOrWhiteSpace(contacto.Nombres))
                return false;

            if (contacto.CuentaCte != null &&
                contacto.CuentaCte.LimiteCredito < 0)
                return false;

            return _datos.Agregar(contacto);
        }


        public bool Modificar(Contacto contacto)
        {
            if (contacto == null)
                return false;

            if (string.IsNullOrWhiteSpace(contacto.DNI))
                return false;

            return _datos.Modificar(contacto);
        }


        public bool Eliminar(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return false;

            return _datos.Eliminar(dni);
        }
    }
}