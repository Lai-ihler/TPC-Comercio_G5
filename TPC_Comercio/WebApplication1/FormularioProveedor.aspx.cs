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
            try
            {
                if (!IsPostBack)
                {
                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                    btnInactivar.Visible = id != "";

                    if (id != "")
                    {
                        ProveedorNegocio negocio = new ProveedorNegocio();
                        Proveedor seleccionado = (negocio.listar(id))[0];
                        txtRazonSocial.Text = seleccionado.RazonSocial;
                        txtCuit.Text = seleccionado.Cuit;
                        txtEmail.Text = seleccionado.Email;
                        txtTelefono.Text = seleccionado.Telefono;
                        txtDireccion.Text = seleccionado.Direccion;

                        Session["proveedorSeleccionado"] = seleccionado;

                        if (!seleccionado.Activo)
                            btnInactivar.Text = "Reactivar";
                    }
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
                Proveedor nuevo = new Proveedor();
                ProveedorNegocio negocio = new ProveedorNegocio();

                nuevo.RazonSocial = txtRazonSocial.Text;
                nuevo.Cuit = txtCuit.Text;
                nuevo.Email = txtEmail.Text;
                nuevo.Telefono = txtTelefono.Text;
                nuevo.Direccion = txtDireccion.Text;

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    negocio.modificar(nuevo);
                }
                else

                    negocio.agregar(nuevo);

                Response.Redirect("Proveedores.aspx", false);
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
                ProveedorNegocio negocio = new ProveedorNegocio();
                Proveedor seleccionado =
                    (Proveedor)Session["proveedorSeleccionado"];

                if (seleccionado != null)
                {
                    negocio.eliminarLogico(
                        seleccionado.Id,
                        !seleccionado.Activo
                    );

                    Response.Redirect("Proveedores.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

    }
}