using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProveedorNegocio negocio = new ProveedorNegocio();
                Session["listaProveedores"] = negocio.listar();
                gvProveedores.DataSource = Session["listaProveedores"];
                gvProveedores.DataBind();
            }
        }

        protected void gvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvProveedores.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioProveedor.aspx?id=" + id);
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Proveedor> lista = (List<Proveedor>)Session["listaProveedores"];
            string filtro = txtFiltro.Text.ToUpper();

            List<Proveedor> listaFiltrada = lista.FindAll(x =>
                x.RazonSocial.ToUpper().Contains(filtro) ||
                x.Cuit.ToUpper().Contains(filtro)
            );

            gvProveedores.DataSource = listaFiltrada;
            gvProveedores.DataBind();
        }
    }
    }