using System;

namespace Agenda3.Entidades
{
    public class CuentaCte
    {
        public int Id { get; set; }

        public string PersonaId { get; set; }

        public DateTime FechaApertura { get; set; }

        public decimal LimiteCredito { get; set; }

        public string EstadoCredito { get; set; }
    }
}