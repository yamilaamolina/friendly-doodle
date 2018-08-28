using System;

namespace Ingeniería_de_Software.Clases
{
    public class Pedido
    {
        public int NumeroPedido { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public int TurnoId { get; set; }
    }
}
