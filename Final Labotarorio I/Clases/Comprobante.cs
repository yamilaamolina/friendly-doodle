using System;

namespace Ingeniería_de_Software.Clases
{
    public class Comprobante
    {
        public int NumeroPeido { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
        public decimal Total { get; set; }
    }
}
