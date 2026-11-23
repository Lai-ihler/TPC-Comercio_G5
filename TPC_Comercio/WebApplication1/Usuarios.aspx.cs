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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioNegocio un = new UsuarioNegocio();
                Session["listaUsuarios"] = un.listar();
                gvUsuarios.DataSource = Session["listaUsuarios"];
                gvUsuarios.DataBind();
            }
        }
        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvUsuarios.SelectedDataKey.Value.ToString();

            Response.Redirect("FormularioUsuario.aspx?id=" + id);
        }
        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                bool activo = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Activo"));

                if (!activo)
                {
                    e.Row.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Usuario> lista = (List<Usuario>)Session["listaUsuarios"];
            string filtro = txtFiltro.Text.ToUpper();

            List<Usuario> listaFiltrada = lista.FindAll(x =>
                x.NombreUsuario.ToUpper().Contains(filtro) ||
                x.Nombre.ToUpper().Contains(filtro) ||
                x.Apellido.ToUpper().Contains(filtro) ||
                x.Email.ToUpper().Contains(filtro)
            );

            gvUsuarios.DataSource = listaFiltrada;
            gvUsuarios.DataBind();
        }
    }
}