using Final_Labotarorio_I.ServicioFacturacionAfip;
using Final_Labotarorio_I.ServicioAutorizacion;
using System;
using System.Windows.Forms;

namespace Ingeniería_de_Software.Clases
{
    public class ServicioAfip
    {
        public static void ConectarAfip(int cantReg,
            TextBox txtTOTALFactura,
            TextBox txtSubTotalFactura)
        {
            var codigoAfipService = "C88DFF36-99E6-4BF6-8A98-31FDCB8E016B";
            var fechaActual = DateTime.Now;
            var numeroUltimoAutorizado = 0;

            FEAuthRequest feAuth = new FEAuthRequest();

            using (var service = new LoginServiceClient())
            {
                var auth = service.SolicitarAutorizacion(codigoAfipService);

                feAuth.Cuit = auth.Cuit;
                feAuth.Sign = auth.Token;
                feAuth.Token = auth.Token;
            }

            FECAERequest FECAEReq = new FECAERequest();
            FECAECabRequest FeCabReq = new FECAECabRequest();
            FECAEDetRequest FeDetReq = new FECAEDetRequest();

            FeCabReq.CantReg = cantReg;
            FeCabReq.CbteTipo = 11; //Factura C
            FeCabReq.PtoVta = 1;

            FeDetReq.Concepto = 1; //Productos
            FeDetReq.DocTipo = 99; //Sin identificar/Venta global diaria
            FeDetReq.DocNro = 5; //PREGUNTAR PROFE
            FeDetReq.CbteDesde = 1;
            FeDetReq.CbteHasta = 99999999;
            //FeDetReq.CbteFch = string.Format("{0}{1}{2}", fechaActual.Year, fechaActual.Month, fechaActual.Day);
            FeDetReq.ImpTotal = double.Parse(txtTOTALFactura.Text);
            FeDetReq.ImpTotConc = 0;
            FeDetReq.ImpNeto = double.Parse(txtSubTotalFactura.Text);
            FeDetReq.ImpOpEx = 0;
            FeDetReq.ImpIVA = 0;
            FeDetReq.ImpTrib = 0; //PREGUNTAR PROFE 
            FeDetReq.MonId = "PES";
            FeDetReq.MonCotiz = 1;

            FECAEReq.FeCabReq = FeCabReq;
            FECAEReq.FeDetReq[0] = FeDetReq;

            using (var service2 = new ServiceSoapClient())
            {
                var ultimoAutorizado = service2.FECompUltimoAutorizado(feAuth, 1, 11);

                if (ultimoAutorizado.Errors == null)
                {
                    numeroUltimoAutorizado = ultimoAutorizado.CbteNro + 1;
                    
                    //caeSolicitar
                    service2.FECAESolicitar(feAuth, FECAEReq);
                }
                else
                {
                    MessageBox.Show("Error conexión Afip Service");
                }
            }
        }
    }
}
