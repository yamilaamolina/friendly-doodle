using System;

namespace Ingeniería_de_Software.Clases
{
    public class Turno
    {
        public int TurnoId { get; set; }
        public string NombreTurno {get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
    }
}
