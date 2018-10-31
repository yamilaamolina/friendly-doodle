using System.Collections.Generic;

namespace Ingeniería_de_Software.Clases
{
    public static class AutoCarga
    {
       public static void Cargarproducto(ref List<EspecificacionDeProducto> ListaProducto)
       {
           ListaProducto.Add(new EspecificacionDeProducto()
           {
               ProdCodigo = "1",
               ProdDescripcion = "Milanesa",
               ProdPrecio = decimal.Parse("75"),
               Rubro = "Comestible",
               ProdStock = 100
           });

           ListaProducto.Add(new EspecificacionDeProducto()
           {
               ProdCodigo = "2",
               ProdDescripcion = "Hamburguesa",
               ProdPrecio = decimal.Parse("55"),
               Rubro = "Comestible",
               ProdStock = 100
           });

            ListaProducto.Add(new EspecificacionDeProducto()
            {
                ProdCodigo = "3",
                ProdDescripcion = "Papas Fritas",
                ProdPrecio = decimal.Parse("25"),
                Rubro = "Comestible",
                ProdStock = 5
            });

            ListaProducto.Add(new EspecificacionDeProducto()
            {
                ProdCodigo = "4",
                ProdDescripcion = "Gaseosa 350 cc.",
                ProdPrecio = decimal.Parse("30"),
                Rubro = "Bebida",
                ProdStock = 10
            });
        }

        public static void Cargarturno(ref List<Turno> ListaTurno)
        {
            ListaTurno.Add(new Turno()
            {
                TurnoId = 1,
                NombreTurno = "Manaña"
            });

            ListaTurno.Add(new Turno()
            {
                TurnoId = 2,
                NombreTurno = "Noche"
            });
        }

        public static void CargarCajero(ref List<Usuario> ListaUsuario)
        {
            ListaUsuario.Add(new Usuario()
            {
                NombreUsuario = "yamilam",
                ContraseñaUsuario = "42209"
            });

            ListaUsuario.Add(new Usuario()
            {
                NombreUsuario = "paulag",
                ContraseñaUsuario = "39479"
            });

            ListaUsuario.Add(new Usuario()
            {
                NombreUsuario = "laurar",
                ContraseñaUsuario = "39585"
            });
        }

        public static void CargarNegocio(ref List<Negocio> ListaNegocio)
        {
            ListaNegocio.Add(new Negocio()
            {
                RazonSocial = "La Sandwichería",
                CUIT = "36-45678959-3",
                Direccion = "Monteagudo 412, San Miguel de Tucumán",
                Telefono = 4347852,
                TipoContribucionId = 13
            });
        }

        public static void CargarCondicionTributaria(ref List<CondicionTributaria> ListaCondicionTributaria)
        {
            ListaCondicionTributaria.Add(new CondicionTributaria()
            {
                TipoContribucionId = 13,
                TipoContribucion = "Monotributista"
            });

            ListaCondicionTributaria.Add(new CondicionTributaria()
            {
                TipoContribucionId = 5,
                TipoContribucion = "Consumidor Final"
            });
        }
    }
}
