using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebApplication1
{
    public partial class Detallecompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idCompra;
                if (!int.TryParse(Request.QueryString["id"], out idCompra) || idCompra <= 0)
                {
                    Response.Redirect("Compras.aspx", false);
                    return;
                }

                CompraNegocio negocio = new CompraNegocio();
                List<CompraDetalle> detalles = negocio.listarDetalles(idCompra);

                gvDetalle.DataSource = detalles;
                gvDetalle.DataBind();

                lblTotal.Text = detalles.Sum(x => x.Subtotal).ToString("C");
            }
        }
    }
}