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
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                Session.Add("listaCategorias", negocio.listar());
                gvCategorias.DataSource = Session["listaCategorias"];
                gvCategorias.DataBind();
            }
        }
        protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvCategorias.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioCategoria.aspx?id=" + id);
        }
        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Categoria> lista = (List<Categoria>)Session["listaCategorias"];
            List<Categoria> listaFiltrada = lista.FindAll(x => x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            gvCategorias.DataSource = listaFiltrada;
            gvCategorias.DataBind();
        }
    }
}