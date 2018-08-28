using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_Facturacion.Clases;
namespace Sistema_de_Facturacion
{
    public partial class Productos : Form
    {
        private List<Sistema_de_Facturacion.Clases.Productos> listadeProductos;
        
        public Productos()
        {

            InitializeComponent();
            listadeProductos = new List<Sistema_de_Facturacion.Clases.Productos>();

        }
        private void CrearProducto(
            string producto,
            int stock,
            int codigo,
            decimal precio,
            string descripcion)
        {
            Sistema_de_Facturacion.Clases.Productos nuevoProducto = new Sistema_de_Facturacion.Clases.Productos();


            nuevoProducto.Producto = producto;
            nuevoProducto.Stock = stock;
            nuevoProducto.Codigo = codigo;
            nuevoProducto.Precio = precio;
            nuevoProducto.Descripcion = descripcion;

            listadeProductos.Add(nuevoProducto);
        
        }
        private void ActualizarDatos()
        {
            this.dgvFactura.DataSource = listadeProductos.ToList();
        
        }
        private void limpiar()
        {
            this.txtProducto.Clear();
            this.txtStock.Clear();
            this.txtCodigo.Clear();
            this.txtPrecio.Clear();
            this.txtDescripcion.Clear();

            this.txtProducto.Focus();
        
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Productos_Load(object sender, EventArgs e)
        {
            ActualizarDatos();
        }

       

        private void btnAgregar_Click(object sender, EventArgs e)
        {
                CrearProducto(this.txtProducto.Text,
                int.Parse(this.txtStock.Text),
                int.Parse(this.txtCodigo.Text),
                decimal.Parse(this.txtPrecio.Text),
                this.txtDescripcion.Text);

            ActualizarDatos();
                

        }

     
        private void dgvFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
