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
    public partial class FormularioCategoria : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                btnInactivar.Visible = id != "";

                if (id != "" && !IsPostBack)
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    Categoria seleccionada = (negocio.listar(id))[0];
                    txtDescripcion.Text = seleccionada.Descripcion;

                    Session.Add("categoriaSeleccionada", seleccionada);
                    if (!seleccionada.Activo)
                        btnInactivar.Text = "Reactivar";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria nueva = new Categoria();
                CategoriaNegocio negocio = new CategoriaNegocio();

                nueva.Descripcion = txtDescripcion.Text;

                if (Request.QueryString["id"] != null)
                {
                    nueva.Id = int.Parse(Request.QueryString["id"]);
                    negocio.modificar(nueva);
                }
                else
                    negocio.agregar(nueva);

                Response.Redirect("Categorias.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                Categoria seleccionada = (Categoria)Session["categoriaSeleccionada"];

                categoriaNegocio.eliminarLogico(seleccionada.Id, !seleccionada.Activo);
                Response.Redirect("Categorias.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}
