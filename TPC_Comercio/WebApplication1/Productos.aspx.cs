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
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                Session["listaProductos"] = negocio.listar();
                gvListado.DataSource = Session["listaProductos"];
                gvListado.DataBind();
            }
        }

        protected void gvListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvListado.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioProducto.aspx?id=" + id);
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Producto> lista = (List<Producto>)Session["listaProductos"];
            string filtro = txtFiltro.Text.ToUpper();

            List<Producto> listaFiltrada = lista.FindAll(x =>
                x.Nombre.ToUpper().Contains(filtro) ||
                x.Codigo.ToUpper().Contains(filtro) ||
                x.Marca.Descripcion.ToUpper().Contains(filtro) ||
                x.Categoria.Descripcion.ToUpper().Contains(filtro) ||
                x.Proveedores.ToUpper().Contains(filtro)
            );

            gvListado.DataSource = listaFiltrada;
            gvListado.DataBind();
        }
    }
}