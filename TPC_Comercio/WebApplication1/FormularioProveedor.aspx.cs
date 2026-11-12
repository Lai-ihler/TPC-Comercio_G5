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
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Proveedor nuevo = new Proveedor();
                ProveedorNegocio negocio = new ProveedorNegocio();

                lblErrorCuit.Text = "";
                string cuit = txtCuit.Text.Trim();

                int idActual = Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"]) : 0;
                if (negocio.existe(cuit, idActual))
                {
                    lblErrorCuit.Text = "Ya existe un proveedor con ese CUIT.";
                    return;
                }

                nuevo.RazonSocial = txtRazonSocial.Text.Trim();
                nuevo.Cuit = cuit;
                nuevo.Email = txtEmail.Text.Trim();
                nuevo.Telefono = txtTelefono.Text.Trim();
                nuevo.Direccion = txtDireccion.Text.Trim();

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