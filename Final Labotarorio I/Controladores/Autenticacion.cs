using Final_Labotarorio_I;
using Ingeniería_de_Software.Clases;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ingeniería_de_Software.Controladores
{
    public class Autenticacion
    {

        public static void cargarListado(List<Usuario> ListaUsuario)
        {
            AutoCarga.CargarCajero(ref ListaUsuario);
        }

        public static void cargarFormularioVenta(
            FormularioAutenticacion formularioAutenticacion,
            List<Usuario> ListaUsuario,
            TextBox txtUsuario,
            TextBox txtContraseña)
        {
            var usuarioExistente = 0;

            cargarListado(ListaUsuario);

            foreach (var usuario in ListaUsuario)
            {
                if (usuario.NombreUsuario == txtUsuario.Text
                    && usuario.ContraseñaUsuario == txtContraseña.Text)
                {
                    formularioAutenticacion.Hide();
                    Formulario formularioVenta = new Formulario();
                    formularioVenta.Show();

                    usuarioExistente = 1;
                    break;
                }
            }

            if (usuarioExistente == 0)
            {
                MessageBox.Show("Usuario y/o Contraseña incorrecto");
            }
        }
    }
}
