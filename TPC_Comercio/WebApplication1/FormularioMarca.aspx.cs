using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebApplication1
{
    public partial class FormularioMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                btnInactivar.Visible = id != "";

                if (id != "" && !IsPostBack)
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    Marca seleccionada = (negocio.listar(id))[0];
                    txtDescripcion.Text = seleccionada.Descripcion;

                    Session.Add("marcaSeleccionada", seleccionada);
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
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Marca nueva = new Marca();
                MarcaNegocio negocio = new MarcaNegocio();

                lblErrorDescripcion.Text = "";
                string descripcion = txtDescripcion.Text.Trim();

                int idActual = Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"]) : 0;
                if (negocio.existe(descripcion, idActual))
                {
                    lblErrorDescripcion.Text = "Esa marca ya existe.";
                    return;
                }

                nueva.Descripcion = descripcion;

                if (Request.QueryString["id"] != null)
                {
                    nueva.Id = int.Parse(Request.QueryString["id"]);
                    negocio.modificar(nueva);
                }
                else
                    negocio.agregar(nueva);

                Response.Redirect("Marcas.aspx", false);
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
                MarcaNegocio negocio = new MarcaNegocio();
                Marca seleccionada = (Marca)Session["marcaSeleccionada"];

                negocio.eliminarLogico(seleccionada.Id, !seleccionada.Activo);
                Response.Redirect("Marcas.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}