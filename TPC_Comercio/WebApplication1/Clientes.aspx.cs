using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteNegocio cn = new ClienteNegocio();

                gvClientes.DataSource = cn.listar();
                gvClientes.DataBind();
            }
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvClientes.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioCliente.aspx?id=" + id);
        }
    }
}