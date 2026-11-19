using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace WebApplication1
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MarcaNegocio negocio = new MarcaNegocio();
                Session.Add("listaMarcas", negocio.listar());
                gvMarcas.DataSource = Session["listaMarcas"];
                gvMarcas.DataBind();
            }
        }

        protected void gvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvMarcas.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioMarca.aspx?id=" + id);
        }
        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Marca> lista = (List<Marca>)Session["listaMarcas"];
            List<Marca> listaFiltrada = lista.FindAll(x => x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            gvMarcas.DataSource = listaFiltrada;
            gvMarcas.DataBind();
        }
}

}