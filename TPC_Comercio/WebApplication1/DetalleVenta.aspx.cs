using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class DetalleVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idVenta;

                if (!int.TryParse(Request.QueryString["id"], out idVenta) || idVenta <= 0)
                {
                    Response.Redirect("Ventas.aspx");
                    return;
                }

                VentaNegocio negocio = new VentaNegocio();

                List<VentaDetalle> detalles = negocio.listarDetalles(idVenta);

                if (detalles.Count == 0)
                {
                    lblFactura.Text = "No se encontraron detalles para esta venta.";
                    return;
                }

                lblFactura.Text = "Factura: " + detalles[0].Venta.NumeroFactura;

                gvDetalle.DataSource = detalles;
                gvDetalle.DataBind();

                decimal total = detalles.Sum(x => x.Subtotal);

                lblTotal.Text = total.ToString("C");
            }
        }
    }
}