using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WebApplication1
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                gvCategorias.DataSource = negocio.listar();
                gvCategorias.DataBind();
            }
        }
        protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvCategorias.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioCategoria.aspx?id=" + id);
        }
    }
}