using Negocio;
using System;
using Dominio;
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

                Session["listaClientes"] = cn.listar();
                gvClientes.DataSource = Session["listaClientes"];
                gvClientes.DataBind();
            }
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvClientes.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioCliente.aspx?id=" + id);
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Cliente> lista = (List<Cliente>)Session["listaClientes"];
            string filtro = txtFiltro.Text.ToUpper();

            List<Cliente> listaFiltrada = lista.FindAll(x =>
                x.Nombre.ToUpper().Contains(filtro) ||
                x.Apellido.ToUpper().Contains(filtro) ||
                x.Dni.ToUpper().Contains(filtro) ||
                x.Email.ToUpper().Contains(filtro)
            );

            gvClientes.DataSource = listaFiltrada;
            gvClientes.DataBind();
        }
    }
}