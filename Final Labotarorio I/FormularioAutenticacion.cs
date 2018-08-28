using Ingeniería_de_Software.Clases;
using Ingeniería_de_Software.Controladores;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Final_Labotarorio_I
{
    public partial class FormularioAutenticacion : Form
    {
        public List<Usuario> ListaUsuario;

        public FormularioAutenticacion()
        {
            InitializeComponent();

            ListaUsuario = new List<Usuario>();

            Autenticacion.cargarListado(ListaUsuario);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Autenticacion.cargarFormularioVenta(this, ListaUsuario, txtUsuario, txtContraseña);
        }
    }
}
