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
    public partial class FormularioProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
       {
            try
            {
                Proveedor nuevo = new Proveedor();
                ProveedorNegocio negocio = new ProveedorNegocio();

                nuevo.RazonSocial = txtRazonSocial.Text;
                nuevo.Cuit = txtCuit.Text;
                nuevo.Email = txtEmail.Text;
               nuevo.Telefono = txtTelefono.Text;
                nuevo.Direccion = txtDireccion.Text;

                negocio.agregar(nuevo);
                Response.Redirect("Proveedores.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

    }
}