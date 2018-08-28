using Final_Labotarorio_I;
using Ingeniería_de_Software.Clases;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ingeniería_de_Software.Controladores
{
    public class Facturacion
    {
        //--------------------------------------------------
        // Funcion para actualizar las listas en las grillas
        public static void cargarGrillas(Formulario formulario,
            List<EspecificacionDeProducto> ListaProducto,
            List<LineaDePedido> ListaDetallesFact,
            List<Pedido> ListaFactura,
            List<Pedido> ListaFacturaEmpleado,
            DataGridView dgvListaProducto,
            DataGridView dgvGrillaFactura,
            DataGridView dgvVentas,
            DataGridView dgvListaVentaEmpleado)
        {
            cargargrillaproducto(formulario, ListaProducto, dgvListaProducto);
            cargarGrillaFact(formulario, ListaDetallesFact, dgvGrillaFactura);
            cargarGrillaVentas(formulario, ListaFactura, dgvVentas);
            cargarGrillaVentaEmpleado(formulario, ListaFacturaEmpleado, dgvListaVentaEmpleado);
        }

        public static void cargargrillaproducto(Formulario formulario,
            List<EspecificacionDeProducto> ListaProducto,
            DataGridView dgvListaProducto)
        {
            dgvListaProducto.DataSource = ListaProducto.ToList();
            formatearGrillaProducto(formulario, dgvListaProducto);
        }

        public static void cargarGrillaFact(Formulario formulario,
            List<LineaDePedido> ListaDetallesFact,
            DataGridView dgvGrillaFactura)
        {
            dgvGrillaFactura.DataSource = ListaDetallesFact.ToList();
            formateargrillaDtaFact(formulario, dgvGrillaFactura);
        }

        public static void cargarGrillaVentas(Formulario formulario,
            List<Pedido> ListaFactura,
            DataGridView dgvVentas)
        {
            dgvVentas.DataSource = ListaFactura.ToList();
            formatearGrillaVentas(formulario, dgvVentas);
        }

        public static void cargarGrillaVentaEmpleado(Formulario formulario,
            List<Pedido> ListaFacturaEmpleado,
            DataGridView dgvListaVentaEmpleado)
        {
            dgvListaVentaEmpleado.DataSource = ListaFacturaEmpleado.ToList();
            formatearGrillaVentaEmple(formulario, dgvListaVentaEmpleado);
        }

        //-----------------------------------
        // Funcion para Formatear las grillas
        private static void formateargrillaDtaFact(Formulario formulario, DataGridView dgvGrillaFactura)
        {
            formulario.dgvGrillaFactura.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private static void formatearGrillaVentas(Formulario formulario, DataGridView dgvVentas)
        {
            formulario.dgvVentas.Columns["NumeroPedido"].HeaderText = "Número de Pedido";
            formulario.dgvVentas.Columns["NumeroPedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            formulario.dgvVentas.Columns["FechaHora"].HeaderText = "Fecha Hora";
            formulario.dgvVentas.Columns["FechaHora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            formulario.dgvVentas.Columns["Total"].HeaderText = "Total";
            formulario.dgvVentas.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            formulario.dgvVentas.Columns["Iva"].HeaderText = "Iva";
            formulario.dgvVentas.Columns["Iva"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private static void formatearGrillaVentaEmple(Formulario formulario, DataGridView dgvListaVentaEmpleado)
        {
            formulario.dgvListaVentaEmpleado.Columns["NumeroPedido"].HeaderText = "Número de Pedido";
            formulario.dgvListaVentaEmpleado.Columns["NumeroPedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            formulario.dgvListaVentaEmpleado.Columns["FechaHora"].HeaderText = "Fecha Hora";
            formulario.dgvListaVentaEmpleado.Columns["FechaHora"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            formulario.dgvListaVentaEmpleado.Columns["Total"].HeaderText = "Total";
            formulario.dgvListaVentaEmpleado.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            formulario.dgvListaVentaEmpleado.Columns["Iva"].HeaderText = "Iva";
            formulario.dgvListaVentaEmpleado.Columns["Iva"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private static void formatearGrillaProducto(Formulario formulario, DataGridView dgvListaProducto)
        {
            formulario.dgvListaProducto.Columns["NumeroPedidoId"].Visible = false;
            formulario.dgvListaProducto.Columns["ProdCodigo"].HeaderText = "Código";
            formulario.dgvListaProducto.Columns["ProdCodigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            formulario.dgvListaProducto.Columns["ProdDescripcion"].HeaderText = "Descripción";
            formulario.dgvListaProducto.Columns["ProdDescripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            formulario.dgvListaProducto.Columns["ProdPrecio"].HeaderText = "Precio";
            formulario.dgvListaProducto.Columns["ProdPrecio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            formulario.dgvListaProducto.Columns["Rubro"].HeaderText = "Rubro";
            formulario.dgvListaProducto.Columns["Rubro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            formulario.dgvListaProducto.Columns["ProdStock"].HeaderText = "Stock";
            formulario.dgvListaProducto.Columns["ProdStock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public static EspecificacionDeProducto BuscarProd(string buscar, List<EspecificacionDeProducto> ListaProducto)
        {
            EspecificacionDeProducto producto = new EspecificacionDeProducto();
            // el foreach buscar en la lista de producto el dato que le pasamos por "buscar"
            foreach (var prod in ListaProducto)
            {
                if (Convert.ToString(prod.ProdCodigo) == buscar ||
                    prod.ProdDescripcion == buscar)
                {
                    producto = prod;
                    break;
                }
            }

            return producto;
        }

        // Función para cargar todos los comboBox
        public static void CargarComboProducto(List<EspecificacionDeProducto> ListaProducto, ComboBox cmbProductoStock)
        {
            cmbProductoStock.DataSource = ListaProducto.ToList();
            cmbProductoStock.DisplayMember = "ProdDescripcion";
            cmbProductoStock.ValueMember = "ProdDescripcion";
        }

        public static void CargarComboTurno(List<Turno> ListaTurno, ComboBox cmbTurno)
        {
            cmbTurno.DataSource = ListaTurno.ToList();
            cmbTurno.DisplayMember = "NombreTurno";
            cmbTurno.ValueMember = "NombreTurno";
        }

        public static void AgregarPedido(Formulario formulario,
            TextBox txtCodigoProductoFactura,
            List<EspecificacionDeProducto> ListaProducto,
            EspecificacionDeProducto ProdActual,
            NumericUpDown nudCantidadDetallesFAct,
            DataGridView dgvListaProducto,
            Button btnGuardarFactura,
            NumericUpDown nudImporteFact,
            List<LineaDePedido> ListaDetallesFact,
            TextBox txtDescripcionProductoFactura,
            DataGridView dgvGrillaFactura,
            NumericUpDown nudPrecioProducto,
            bool FactA,
            bool FactB,
            bool FactC,
            TextBox txtIvaFact,
            EspecificacionDeProducto factura, TextBox txtSubTotalFactura,
            TextBox txtTOTALFactura)
        {
            if (string.IsNullOrEmpty(formulario.cmbProductoStock.SelectedValue.ToString()))
            {
                MessageBox.Show("Seleccione un producto");
            }
            else
            {
                if (string.IsNullOrEmpty(txtCodigoProductoFactura.Text))
                {
                    MessageBox.Show("El producto no existe");
                }
                else
                {
                    ProdActual = Facturacion.BuscarProd(formulario.txtCodigoProductoFactura.Text, ListaProducto);

                    AgregarEspecificacionProducto(formulario, ProdActual, Convert.ToInt32(nudCantidadDetallesFAct.Value), nudCantidadDetallesFAct, ProdActual,
                        ListaDetallesFact, txtDescripcionProductoFactura, dgvGrillaFactura, txtCodigoProductoFactura,
                        nudPrecioProducto, ListaProducto, dgvListaProducto, FactA, FactB, FactC, txtIvaFact, factura,
                        txtSubTotalFactura, txtTOTALFactura);

                    Facturacion.cargargrillaproducto(formulario, ListaProducto, dgvListaProducto);
                    nudCantidadDetallesFAct.Value = 1;
                    FacturaABC(FactA, FactB, FactC, txtIvaFact, ListaDetallesFact, txtSubTotalFactura, txtTOTALFactura);

                    ExiteProductosListaFact(txtTOTALFactura, nudImporteFact);
                    btnGuardarFactura.Enabled = true;
                    nudImporteFact.Enabled = true;
                }
            }
        }

        //--------------------------------------------------
        //Función para agregar los datos al detalles factura
        public static void AgregarEspecificacionProducto(Formulario formulario,
            EspecificacionDeProducto codiProd,
            int cantidadProd,
            NumericUpDown nudCantidadDetallesFAct,
            EspecificacionDeProducto ProdActual,
            List<LineaDePedido> ListaDetallesFact,
            TextBox txtDescripcionProductoFactura,
            DataGridView dgvGrillaFactura,
            TextBox txtCodigoProductoFactura,
            NumericUpDown nudPrecioProducto,
            List<EspecificacionDeProducto> ListaProducto,
            DataGridView dgvListaProducto,
            bool FactA,
            bool FactB,
            bool FactC,
            TextBox txtIvaFact,
            EspecificacionDeProducto factura,
            TextBox txtSubTotalFactura,
            TextBox txtTOTALFactura)
        {
            //Verifica  si existe un producto en la lista de detalles
            if (ExisteProd(factura, ListaDetallesFact, txtDescripcionProductoFactura))
            {
                //Verifica el stock
                if (nudCantidadDetallesFAct.Value <= ProdActual.ProdStock)
                {
                    foreach (var busc in ListaDetallesFact)
                    {
                        //Verifica que cod de la lista es igual al del producto a agregar, le suma la cantidad y calcula nuevamente el subtotal
                        if (busc.Descripcion == txtDescripcionProductoFactura.Text)
                        {
                            busc.Cantidad += cantidadProd;
                            busc.SubTotal = busc.Cantidad * busc.Precio;
                            ProdActual.ProdStock = ProdActual.ProdStock - cantidadProd;
                            FacturaABC(FactA, FactB, FactC, txtIvaFact, ListaDetallesFact, txtSubTotalFactura, txtTOTALFactura);
                        }

                        Facturacion.cargarGrillaFact(formulario, ListaDetallesFact, dgvGrillaFactura);
                    }
                }
                else
                {
                    MessageBox.Show("No hay Stock del producto");
                }
            }
            else
            //Si el producto es nuevo en la lista de detalles
            {
                //Verifica el stock
                if (nudCantidadDetallesFAct.Value <= ProdActual.ProdStock)
                {
                    LineaDePedido ObjDetalle = new LineaDePedido();

                    ObjDetalle.Codigo = txtCodigoProductoFactura.Text;
                    ObjDetalle.Descripcion = txtDescripcionProductoFactura.Text;
                    ObjDetalle.Precio = nudPrecioProducto.Value;
                    ObjDetalle.Cantidad = Convert.ToInt32(nudCantidadDetallesFAct.Value);
                    ObjDetalle.SubTotal = ObjDetalle.Precio * ObjDetalle.Cantidad;
                    ProdActual.ProdStock = ProdActual.ProdStock - Convert.ToInt32(nudCantidadDetallesFAct.Value);
                    ListaDetallesFact.Add(ObjDetalle);
                    Facturacion.cargarGrillaFact(formulario, ListaDetallesFact, dgvGrillaFactura);
                    Facturacion.cargargrillaproducto(formulario, ListaProducto, dgvListaProducto);
                }
                else { MessageBox.Show("No hay Stock del producto"); }
            }
        }

        //---------------------------------------------------------------------------------------
        //Función para poder calcular la factura dependiendo del tipo de factura que este tildada
        public static void FacturaABC(bool FactA, bool FactB, bool FactC, TextBox txtIvaFact,
            List<LineaDePedido> ListaDetallesFact, TextBox txtSubTotalFactura, TextBox txtTOTALFactura)
        {
            if (FactA == true)
            {
                FactA = true;
                FactB = false;
                FactC = false;
                CalculaSubtotal(ListaDetallesFact, txtSubTotalFactura);
                CalcularIva(ListaDetallesFact, txtIvaFact);
                CalcularTotal(txtSubTotalFactura, txtTOTALFactura, txtIvaFact);
            }
            else
            {
                if (FactB == true || FactC == true)
                {
                    FactB = true;
                    FactA = false;
                    FactC = false;
                }
                else
                {
                    FactC = true;
                    FactB = false;
                    FactA = false;
                }

                txtIvaFact.Text = "0";
                CalculaSubtotal(ListaDetallesFact, txtSubTotalFactura);
                CalcularTotal(txtSubTotalFactura, txtTOTALFactura, txtIvaFact);
            }
        }

        //------------------------------------------------------
        //Función para ver si hay productos en la listaDetalles
        public static bool ExisteProd(EspecificacionDeProducto factura, List<LineaDePedido> ListaDetallesFact, TextBox txtDescripcionProductoFactura)
        {
            foreach (var busc in ListaDetallesFact)
            {
                if (busc.Descripcion == txtDescripcionProductoFactura.Text)
                {
                    return true;
                }
            }

            return false;
        }

        //----------------------------------
        //Calcular Subtotal detalle factura
        public static void CalculaSubtotal(List<LineaDePedido> ListaDetallesFact, TextBox txtSubTotalFactura)
        {
            decimal TotalFact = 0;

            foreach (var busc in ListaDetallesFact)
            {
                TotalFact += busc.SubTotal;
            }

            txtSubTotalFactura.Text = TotalFact.ToString();
        }

        //-------------
        //Calcular iva
        public static void CalcularIva(List<LineaDePedido> ListaDetallesFact, TextBox txtIvaFact)
        {
            decimal _iva = 0;
            decimal _suma = 0;
            foreach (var busc in ListaDetallesFact)
            {
                _suma += busc.SubTotal;
                _iva = (_suma - (_suma / 1.21m));

            }
            txtIvaFact.Text = string.Format("{00:0.00}", _iva);

        }

        //-------------------------------
        //Calcular total detalle factura
        public static void CalcularTotal(TextBox txtSubTotalFactura,
            TextBox txtTOTALFactura,
            TextBox txtIvaFact)
        {
            decimal _total = 0;
            decimal _subtotal = 0;
            decimal _iva = 0;
            
            _total = Convert.ToDecimal(txtSubTotalFactura.Text);
            _subtotal = decimal.Parse(txtSubTotalFactura.Text);

            _total = (_subtotal + _iva - (_subtotal / 100));
            txtTOTALFactura.Text = string.Format("{00:0.00}", _total);
        }

        //-----------------------------------------------------------------------------------------------
        //Función para ver si existe un producto en la lista de factura asi active o no el txt de importe
        public static void ExiteProductosListaFact(TextBox txtTOTALFactura, NumericUpDown nudImporteFact)
        {
            string _total = txtTOTALFactura.Text;
            if (_total == "0,00")
            {
                nudImporteFact.Enabled = false;
            }
            else
            {
                nudImporteFact.Enabled = true;
            }
        }

        public static void CancelarPedido(Formulario formulario,
            List<LineaDePedido> ListaDetallesFact,
            List<EspecificacionDeProducto> ListaProducto,
            TextBox txtSubTotalFactura,
            TextBox txtTOTALFactura,
            TextBox txtIvaFact,
            NumericUpDown nudImporteFact,
            TextBox txtVueltoFAct,
            Button btnAgregarfactura,
            DataGridView dgvListaProducto,
            DataGridView dgvGrillaFactura)
        {
            foreach (var itemDetalle in ListaDetallesFact)
            {
                foreach (var itemProducto in ListaProducto)
                {
                    if (itemDetalle.Codigo == itemProducto.ProdCodigo)
                    {
                        itemProducto.ProdStock += itemDetalle.Cantidad;
                    }
                }
            }

            txtSubTotalFactura.Text = "0";
            txtTOTALFactura.Text = "0";
            txtIvaFact.Text = "0";
            nudImporteFact.Value = 0;
            txtVueltoFAct.Text = "0";
            btnAgregarfactura.Enabled = true;

            ListaDetallesFact.Clear();
            Facturacion.cargargrillaproducto(formulario, ListaProducto, dgvListaProducto);
            Facturacion.cargarGrillaFact(formulario, ListaDetallesFact, dgvGrillaFactura);
        }

        public static void CargarVentasPorTurno(Formulario formulario,
            ComboBox cmbTurno,
            List<Turno> ListaTurno,
            List<Pedido> ListaFacturaEmpleado,
            DataGridView dgvListaVentaEmpleado,
            List<Pedido> ListaFactura,
            TextBox txtTotalTurno)
        {
            var nombreTurnoSelected = cmbTurno.SelectedValue.ToString();
            var turnoSelected = ListaTurno.Find(tur => tur.NombreTurno == nombreTurnoSelected);

            ListaFacturaEmpleado.Clear();
            obtenerVentasTurno(formulario, turnoSelected, ListaFactura, ListaFacturaEmpleado, dgvListaVentaEmpleado, txtTotalTurno);
            cargarGrillaVentaEmpleado(formulario, ListaFacturaEmpleado, dgvListaVentaEmpleado);
        }

        //----------------------------------------
        //obtiene las ventas del empleado elegido
        private static void obtenerVentasTurno(Formulario formulario,
            Turno turnoSelected,
            List<Pedido> ListaFactura,
            List<Pedido> ListaFacturaEmpleado,
            DataGridView dgvListaVentaEmpleado,
            TextBox txtTotalTurno)
        {
            Pedido VentaEmpleado = new Pedido();
            decimal totalRecaudadoTurno = 0;

            foreach (var item in ListaFactura)
            {
                if (turnoSelected.TurnoId == item.TurnoId)
                {
                    ListaFacturaEmpleado.Add(item);
                    cargarGrillaVentaEmpleado(formulario, ListaFacturaEmpleado, dgvListaVentaEmpleado);

                    totalRecaudadoTurno = totalRecaudadoTurno + item.Total;
                }
            }

            txtTotalTurno.Text = totalRecaudadoTurno.ToString();
        }

        public static void GuardarComprobante(Formulario formulario,
            NumericUpDown nudImporteFact,
            TextBox txtTOTALFactura,
            int NumFact,
            TextBox txtNroFactura,
            Pedido FactNueva,
            string EmpleadoActuApellido,
            string EmpActualCodig,
            TextBox txtFechaFactura,
            TextBox txtIvaFact,
            List<Turno> ListaTurno,
            TextBox txtTurno,
            List<Pedido> ListaFactura,
            List<LineaDePedido> ListaDetallesFact,
            TextBox txtSubTotalFactura,
            TextBox txtVueltoFAct,
            DataGridView dgvGrillaFactura,
            DataGridView dgvVentas,
            List<Pedido> ListaFacturaEmpleado,
            DataGridView dgvListaVentaEmpleado,
            Button btnGuardarFactura,
            Button btnAgregarfactura)
        {
            {
                if (nudImporteFact.Value < decimal.Parse(txtTOTALFactura.Text))
                {
                    MessageBox.Show("Importe insuficiente");
                }
                else
                {

                    NumFact += 1;

                    txtNroFactura.Text = NumFact.ToString();

                    FactNueva = new Pedido();

                    EmpleadoActuApellido = null;
                    EmpActualCodig = null;

                    FactNueva.NumeroPedido = int.Parse(txtNroFactura.Text);
                    FactNueva.FechaHora = Convert.ToDateTime(txtFechaFactura.Text);
                    FactNueva.Iva = Convert.ToDecimal(txtIvaFact.Text);
                    FactNueva.Total = Convert.ToDecimal(txtTOTALFactura.Text);
                    FactNueva.TurnoId = ListaTurno.Find(tur => tur.NombreTurno == txtTurno.Text).TurnoId;

                    ListaFactura.Add(FactNueva);
                    ListaDetallesFact.Clear();
                    cargarGrillaFact(formulario, ListaDetallesFact, dgvGrillaFactura);
                    txtSubTotalFactura.Clear();
                    txtTOTALFactura.Clear();
                    txtIvaFact.Clear();
                    nudImporteFact.Value = 0;

                    txtVueltoFAct.Clear();
                    ExiteProductosListaFact(txtTOTALFactura, nudImporteFact);
                    cargarGrillaVentas(formulario, ListaFactura, dgvVentas);

                    ListaFacturaEmpleado.Add(FactNueva);
                    cargarGrillaVentaEmpleado(formulario, ListaFacturaEmpleado, dgvListaVentaEmpleado);

                    nudImporteFact.Enabled = false;
                    btnGuardarFactura.Enabled = false;
                    btnAgregarfactura.Enabled = true;
                }
            }
        }

        public static void CalcularCambio(TextBox txtTOTALFactura,
            NumericUpDown nudImporteFact,
            Button btnAgregarfactura,
            TextBox txtVueltoFAct)
        {
            decimal _total = Convert.ToDecimal(txtTOTALFactura.Text);

            decimal _importe = Convert.ToDecimal(nudImporteFact.Value);
            btnAgregarfactura.Enabled = false;
            if (_importe >= _total)
            {
                decimal _vuelto = _total - _importe;
                //Para que no sea negativo el vuelto
                _vuelto = -(_vuelto);
                txtVueltoFAct.Text = _vuelto.ToString();
                nudImporteFact.Enabled = false;
            }
            else
            {
                MessageBox.Show("$$ ingresado es insuficiente");
            }
        }

        public static void CargarProductoSeleccionado(ComboBox cmbProductoStock,
            CheckBox cbLechuga,
            CheckBox cbTomate,
            CheckBox cbAderezos,
            CheckBox cbPicante,
            CheckBox cbJamon,
            CheckBox cbQueso,
            CheckBox cbHuevo,
            EspecificacionDeProducto ProdActual,
            List<EspecificacionDeProducto> ListaProducto,
            TextBox txtCodigoProductoFactura,
            TextBox txtDescripcionProductoFactura,
            NumericUpDown nudPrecioProducto)
        {
            cbLechuga.Checked = true;
            cbTomate.Checked = true;
            cbAderezos.Checked = true;
            cbPicante.Checked = false;
            cbJamon.Checked = false;
            cbQueso.Checked = false;
            cbHuevo.Checked = false;

            if (cmbProductoStock.SelectedValue.ToString() == "Papas Fritas")
            {
                cbLechuga.Enabled = false;
                cbTomate.Enabled = false;
                cbAderezos.Enabled = false;
                cbPicante.Enabled = false;
                cbJamon.Enabled = false;
                cbQueso.Enabled = true;
                cbHuevo.Enabled = false;
            }
            else if (cmbProductoStock.SelectedValue.ToString() == "Gaseosa 350 cc.")
            {
                cbLechuga.Enabled = false;
                cbTomate.Enabled = false;
                cbAderezos.Enabled = false;
                cbPicante.Enabled = false;
                cbJamon.Enabled = false;
                cbQueso.Enabled = false;
                cbHuevo.Enabled = false;
            }
            else
            {
                cbLechuga.Enabled = true;
                cbTomate.Enabled = true;
                cbAderezos.Enabled = true;
                cbPicante.Enabled = true;
                cbJamon.Enabled = true;
                cbQueso.Enabled = true;
                cbHuevo.Enabled = true;
            }

            ProdActual = new EspecificacionDeProducto();
            ProdActual = Facturacion.BuscarProd(Convert.ToString(cmbProductoStock.Text), ListaProducto);

            if (ProdActual != null)
            {
                txtCodigoProductoFactura.Text = Convert.ToString(ProdActual.ProdCodigo);
                txtDescripcionProductoFactura.Text = ProdActual.ProdDescripcion;
                nudPrecioProducto.Value = ProdActual.ProdPrecio;
            }
        }

        //Agregar agregados adicionales que vienen
        public static void AgregarAdicionales(CheckBox checkBox,
            string adicional,
            TextBox txtDescripcionProductoFactura,
            NumericUpDown nudPrecioProducto)
        {
            if (checkBox.Checked)
            {
                if (!txtDescripcionProductoFactura.Text.Contains(adicional))
                {
                    txtDescripcionProductoFactura.Text = txtDescripcionProductoFactura.Text + adicional;

                    if (checkBox.Name.ToString() != "cbPicante")
                    {
                        nudPrecioProducto.Value = nudPrecioProducto.Value + 10;
                    }
                }
            }
            else
            {
                if (txtDescripcionProductoFactura.Text.Contains(adicional))
                {
                    txtDescripcionProductoFactura.Text = txtDescripcionProductoFactura.Text.Replace(adicional, "");

                    if (checkBox.Name.ToString() != "cbPicante")
                    {
                        nudPrecioProducto.Value = nudPrecioProducto.Value - 10;
                    }
                }
            }
        }

        //Quitar los agregados que vienen por defecto
        public static void QuitarAdicionales(CheckBox checkBox,
            string adicional,
            TextBox txtDescripcionProductoFactura,
            NumericUpDown nudPrecioProducto)
        {
            if (!checkBox.Checked)
            {
                if (!txtDescripcionProductoFactura.Text.Contains(adicional))
                {
                    txtDescripcionProductoFactura.Text = txtDescripcionProductoFactura.Text + adicional;
                }
            }
            else
            {
                if (txtDescripcionProductoFactura.Text.Contains(adicional))
                {
                    txtDescripcionProductoFactura.Text = txtDescripcionProductoFactura.Text.Replace(adicional, "");
                }
            }
        }

        public static void EnableComponent(bool valueEnable,
            ComboBox cmbProductoStock,
            NumericUpDown nudCantidadDetallesFAct,
            Button btnAgregarfactura,
            Button btnCancelarFactura,
            CheckBox cbLechuga,
            CheckBox cbTomate,
            CheckBox cbAderezos,
            CheckBox cbPicante,
            CheckBox cbJamon,
            CheckBox cbQueso,
            CheckBox cbHuevo,
            Button btnFinalizarTurno)
        {
            cmbProductoStock.Enabled = valueEnable;
            nudCantidadDetallesFAct.Enabled = valueEnable;
            btnAgregarfactura.Enabled = valueEnable;
            btnCancelarFactura.Enabled = valueEnable;
            cbLechuga.Enabled = valueEnable;
            cbTomate.Enabled = valueEnable;
            cbAderezos.Enabled = valueEnable;
            cbPicante.Enabled = valueEnable;
            cbJamon.Enabled = valueEnable;
            cbQueso.Enabled = valueEnable;
            cbHuevo.Enabled = valueEnable;
            btnFinalizarTurno.Enabled = valueEnable;
        }

        public static void CambiarTurno(ComboBox cmbProductoStock,
            NumericUpDown nudCantidadDetallesFAct,
            Button btnAgregarfactura,
            Button btnCancelarFactura,
            CheckBox cbLechuga,
            CheckBox cbTomate,
            CheckBox cbAderezos,
            CheckBox cbPicante,
            CheckBox cbJamon,
            CheckBox cbQueso,
            CheckBox cbHuevo,
            Button btnFinalizarTurno,
            Button btnTurno,
            List<Turno> ListaTurno,
            TextBox txtTurno,
            List<Pedido> ListaFacturaEmpleado,
            TabControl tabControl1,
            TextBox txtTotalTurno,
            ComboBox cmbTurno)
        {
            if (btnTurno.Text == "Iniciar Turno")
            {
                foreach (Turno turno in ListaTurno)
                {
                    if (turno.FechaHoraInicio == DateTime.MinValue)
                    {
                        turno.FechaHoraInicio = DateTime.Now;

                        txtTurno.Text = turno.NombreTurno;
                        btnTurno.Text = "Finalizar Turno";

                        EnableComponent(true, cmbProductoStock, nudCantidadDetallesFAct, btnAgregarfactura,
                            btnCancelarFactura, cbLechuga, cbTomate, cbAderezos, cbPicante, cbJamon,
                            cbQueso, cbHuevo, btnFinalizarTurno);
                        ListaFacturaEmpleado.Clear();

                        break;
                    }
                }
            }
            else
            {
                tabControl1.SelectedIndex = 2;

                decimal totalRecaudadoTurno = 0;

                foreach (var venta in ListaFacturaEmpleado)
                {
                    totalRecaudadoTurno = totalRecaudadoTurno + venta.Total;
                }

                txtTotalTurno.Text = totalRecaudadoTurno.ToString();
                cmbTurno.Text = txtTurno.Text;
            }
        }

        public static void ConfirmarFinalizarTurno(
            List<Turno> ListaTurno,
            TextBox txtTurno,
            Button btnTurno,
            List<Pedido> ListaFacturaEmpleado,
            TextBox txtTotalTurno,
            TabControl tabControl1,
            ComboBox cmbProductoStock,
            NumericUpDown nudCantidadDetallesFAct,
            Button btnAgregarfactura,
            Button btnCancelarFactura,
            CheckBox cbLechuga,
            CheckBox cbTomate,
            CheckBox cbAderezos,
            CheckBox cbPicante,
            CheckBox cbJamon,
            CheckBox cbQueso,
            CheckBox cbHuevo,
            Button btnFinalizarTurno)
        {
            decimal totalRecaudadoTurno = 0;

            foreach (Turno turno in ListaTurno)
            {
                if (turno.FechaHoraInicio != DateTime.MinValue && turno.FechaHoraFin == DateTime.MinValue)
                {
                    turno.FechaHoraFin = DateTime.Now;

                    txtTurno.Text = "";
                    btnTurno.Text = "Iniciar Turno";

                    foreach (var venta in ListaFacturaEmpleado)
                    {
                        totalRecaudadoTurno = totalRecaudadoTurno + venta.Total;
                    }

                    Facturacion.EnableComponent(false, cmbProductoStock, nudCantidadDetallesFAct, btnAgregarfactura,
                        btnCancelarFactura, cbLechuga, cbTomate, cbAderezos, cbPicante, cbJamon, cbQueso, cbHuevo,
                        btnFinalizarTurno);
                    break;
                }
            }

            txtTotalTurno.Text = totalRecaudadoTurno.ToString();
            tabControl1.SelectedIndex = 0;
        }
    }
}
