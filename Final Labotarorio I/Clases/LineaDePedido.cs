namespace Ingeniería_de_Software.Clases
{
    public class LineaDePedido
    {
        public int NumeroPedido { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
    }
}
