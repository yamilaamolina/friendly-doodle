using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Ingeniería_de_Software.Clases;
using Ingeniería_de_Software.Controladores;

namespace Final_Labotarorio_I
{
    public partial class Formulario : Form
    {
        //Variables
        public List<EspecificacionDeProducto> ListaProducto;
        public List<Cliente> ListaCliente;
        public List<Pedido> ListaFactura;
        public List<Pedido> ListaFacturaEmpleado;
        public List<LineaDePedido> ListaDetallesFact;
        public List<Turno> ListaTurno;
        public List<Usuario> ListaUsuario;
        public List<Negocio> ListaNegocio;
        public List<CondicionTributaria> ListaCondicionTributaria;
        int NumFact = 0;

        public string EmpleadoActuApellido;
        public string DNIActualEMpelado;
        public string ClietActualApellido;
        public string ClienteActualCuil;
        public string EmpActualCodig;

        public bool ModoRapido;
        public EspecificacionDeProducto ProdActual;
        public string ProductoActual;
        public Pedido FactNueva;
        public bool debefactura = true;
        public int contadorIdempleado = 3;
        public int contadorIDcliente = 3;
        public int contadorProdID = 3;
        public int contadorCtaID = 1;
        public int contadorFactID = 1;

        public bool FactA = false;
        public bool FactB = false;
        public bool FactC = true;

        // Para cargar el costo de los productos apesar de que no haya stock
        public decimal CostoProdAux;
        DateTime fecha;

        public Formulario()
        {
            InitializeComponent();
            
            ListaProducto = new List<EspecificacionDeProducto>();
            ListaCliente = new List<Cliente>();
            ListaDetallesFact = new List<LineaDePedido>();
            ListaFactura = new List<Pedido>();
            ListaFacturaEmpleado = new List<Pedido>();
            ListaTurno = new List<Turno>();
            ListaUsuario = new List<Usuario>();
            ListaNegocio = new List<Negocio>();
            ListaCondicionTributaria = new List<CondicionTributaria>();
            Facturacion.ExiteProductosListaFact(txtTOTALFactura, nudImporteFact);
            fecha = DateTime.Now;

            this.txtFechaFactura.Text = fecha.ToString();
        }

        //-------------------------------------------------------------------
        //Cargar Formulario
        private void Formulario_Load(object sender, EventArgs e)
        {
            AutoCarga.CargarCajero(ref ListaUsuario);
            AutoCarga.Cargarproducto(ref ListaProducto);
            AutoCarga.Cargarturno(ref ListaTurno);
            AutoCarga.CargarNegocio(ref ListaNegocio);
            AutoCarga.CargarCondicionTributaria(ref ListaCondicionTributaria);

            Facturacion.cargarGrillas(this, ListaProducto, ListaDetallesFact, ListaFactura, ListaFacturaEmpleado,
                dgvListaProducto, dgvGrillaFactura, dgvVentas, dgvListaVentaEmpleado);
            Facturacion.CargarComboProducto(ListaProducto, cmbProductoStock);
            Facturacion.CargarComboTurno(ListaTurno, cmbTurno);
            Facturacion.FacturaABC(FactA, FactB, FactC, txtIvaFact, ListaDetallesFact, txtSubTotalFactura, txtTOTALFactura);
            txtNroFactura.Text = "1";
            Facturacion.ExiteProductosListaFact(txtTOTALFactura, nudImporteFact);
            Facturacion.EnableComponent(false, cmbProductoStock, nudCantidadDetallesFAct, btnAgregarfactura, btnCancelarFactura,
                cbLechuga, cbTomate, cbAderezos, cbPicante, cbJamon, cbQueso, cbHuevo, btnFinalizarTurno);
        }

        //----------------------------------------------------------------------------------------------------
        // Botón Agregar, valida que este todo ok y agrega un producto a la lista, calcula el total, sub e iva
        private void btnAgregarfactura_Click(object sender, EventArgs e)
        {
            Facturacion.AgregarPedido(this,
                txtCodigoProductoFactura,
                ListaProducto,
                ProdActual,
                nudCantidadDetallesFAct,
                dgvListaProducto,
                btnGuardarFactura,
                nudImporteFact,
                ListaDetallesFact,
                txtDescripcionProductoFactura,
                dgvGrillaFactura,
                nudPrecioProducto,
                FactA,
                FactB,
                FactC,
                txtIvaFact,
                ProdActual,//
                txtSubTotalFactura,
                txtTOTALFactura);
        }
        
        //-------------------------------------------------------------------
        // Botón Guardar, aumenta en 1 el número de factura, checkea que el tipo de factura y agrega a los datos de la factura
        // agraega la lista factura y borra todo para dejar limpio para que se vuelva a utilizar
        private void btnGuardarFactura_Click(object sender, EventArgs e)
        {
            Facturacion.GuardarComprobante(this,
                nudImporteFact,
                txtTOTALFactura,
                NumFact,
                txtNroFactura,
                FactNueva,
                EmpleadoActuApellido,
                EmpActualCodig,
                txtFechaFactura,
                txtIvaFact,
                ListaTurno,
                txtTurno,
                ListaFactura,
                ListaDetallesFact,
                txtSubTotalFactura,
                txtVueltoFAct,
                dgvGrillaFactura,
                dgvVentas,
                ListaFacturaEmpleado,
                dgvListaVentaEmpleado,
                btnGuardarFactura,
                btnAgregarfactura);
        }
        
        //-----------------------------------------------------------
        //Evento que se produce cuando cambiamos en valor del nudcon
        private void nudDescuentoFactura_ValueChanged(object sender, EventArgs e)
        {
            Facturacion.FacturaABC(FactA, FactB, FactC, txtIvaFact, ListaDetallesFact, txtSubTotalFactura, txtTOTALFactura);
        }
        
        //--------------------------------------------------------
        //Cancela todo y devuleve el stock a la lista de productos
        private void btnCancelarFactura_Click(object sender, EventArgs e)
        {
            Facturacion.CancelarPedido(this,
                ListaDetallesFact,
                ListaProducto,
                txtSubTotalFactura,
                txtTOTALFactura,
                txtIvaFact,
                nudImporteFact,
                txtVueltoFAct,
                btnAgregarfactura,
                dgvListaProducto,
                dgvGrillaFactura);
        }

        //---------------------------------------------------------------
        //Evento que se produce cuando se hace click en el combobox turno
        private void cmbTurno_TextChanged(object sender, EventArgs e)
        {
            ListaFacturaEmpleado.Clear();
        }

        //--------------------------------------------------------------------------------
        //el evento que ocurre cuando se hace clic en el combox de Turnos y selecionadmos un turno
        private void cmbTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            Facturacion.CargarVentasPorTurno(this,
                cmbTurno,
                ListaTurno,
                ListaFacturaEmpleado,
                dgvListaVentaEmpleado,
                ListaFactura,
                txtTotalTurno);
        }

        //Calcular vuelto
        private void nudImporteFact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Facturacion.CalcularCambio(txtTOTALFactura,
                    nudImporteFact,
                    btnAgregarfactura,
                    txtVueltoFAct);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //----------------------------------------------
        // Funcion del comboBox para buscar un producto //
        private void cmbProductoStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            Facturacion.CargarProductoSeleccionado(cmbProductoStock,
                cbLechuga,
                cbTomate,
                cbAderezos,
                cbPicante,
                cbJamon,
                cbQueso,
                cbHuevo,
                ProdActual,
                ListaProducto,
                txtCodigoProductoFactura,
                txtDescripcionProductoFactura,
                nudPrecioProducto);
        }

        private void cbJamon_CheckedChanged(object sender, EventArgs e)
        {
            Facturacion.AgregarAdicionales(
                cbJamon, ", c/jamón", txtDescripcionProductoFactura, nudPrecioProducto);
        }

        private void cbQueso_CheckedChanged(object sender, EventArgs e)
        {
            Facturacion.AgregarAdicionales(
                cbQueso, ", c/queso", txtDescripcionProductoFactura, nudPrecioProducto);
        }

        private void cbHuevo_CheckedChanged(object sender, EventArgs e)
        {
            Facturacion.AgregarAdicionales(
                cbHuevo, ", c/huevo", txtDescripcionProductoFactura, nudPrecioProducto);
        }

        private void cbLechuga_CheckedChanged(object sender, EventArgs e)
        {
            Facturacion.QuitarAdicionales(
                cbLechuga, ", s/lechuga", txtDescripcionProductoFactura, nudPrecioProducto);
        }

        private void cbTomate_CheckedChanged(object sender, EventArgs e)
        {
            Facturacion.QuitarAdicionales(
                cbTomate, ", s/tomate", txtDescripcionProductoFactura, nudPrecioProducto);
        }

        private void cbAderezos_CheckedChanged(object sender, EventArgs e)
        {
            Facturacion.QuitarAdicionales(
                cbAderezos, ", s/aderezos", txtDescripcionProductoFactura, nudPrecioProducto);
        }

        private void cbPicante_CheckedChanged(object sender, EventArgs e)
        {
            Facturacion.AgregarAdicionales(
                cbPicante, ", c/picante", txtDescripcionProductoFactura, nudPrecioProducto);
        }

        //Botón verde de inicio o fin de turno
        private void btnTurno_Click(object sender, EventArgs e)
        {
            Facturacion.CambiarTurno(cmbProductoStock,
                nudCantidadDetallesFAct,
                btnAgregarfactura,
                btnCancelarFactura,
                cbLechuga,
                cbTomate,
                cbAderezos,
                cbPicante,
                cbJamon,
                cbQueso,
                cbHuevo,
                btnFinalizarTurno,
                btnTurno,
                ListaTurno,
                txtTurno,
                ListaFacturaEmpleado,
                tabControl1,
                txtTotalTurno,
                cmbTurno);
        }

        //Botón rojo de fin de turno
        private void btnFinalizarTurno_Click(object sender, EventArgs e)
        {
            Facturacion.ConfirmarFinalizarTurno(
                ListaTurno,
                txtTurno,
                btnTurno,
                ListaFacturaEmpleado,
                txtTotalTurno,
                tabControl1,
                cmbProductoStock,
                nudCantidadDetallesFAct,
                btnAgregarfactura,
                btnCancelarFactura,
                cbLechuga,
                cbTomate,
                cbAderezos,
                cbPicante,
                cbJamon,
                cbQueso,
                cbHuevo,
                btnFinalizarTurno);
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            var cantReg = ListaDetallesFact.Count;
            ServicioAfip.ConectarAfip(cantReg, txtTOTALFactura, txtSubTotalFactura);
        }
    }
}