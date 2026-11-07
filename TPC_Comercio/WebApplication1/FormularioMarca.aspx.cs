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
                if (id != "" && !IsPostBack)
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    Marca seleccionada = (negocio.listar(id))[0];
                    txtDescripcion.Text = seleccionada.Descripcion;
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
                Marca nueva = new Marca();
                MarcaNegocio negocio = new MarcaNegocio();

                nueva.Descripcion = txtDescripcion.Text;

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
    }
}