using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WebApplication1
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MarcaNegocio negocio = new MarcaNegocio();
                gvMarcas.DataSource = negocio.listar();
                gvMarcas.DataBind();
            }
        }

        protected void gvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvMarcas.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioMarca.aspx?id=" + id);
        }
    }
}