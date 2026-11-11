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
    public partial class FormularioCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"] != null
               ? Request.QueryString["id"].ToString()
               : "";

            btnInactivar.Visible = id != "";

            if (!IsPostBack && id != "")
            {
                try
                {
                    ClienteNegocio negocio = new ClienteNegocio();
                    Cliente seleccionado = null;
                    int idCliente = int.Parse(id);

                    foreach (Cliente cliente in negocio.listar())
                    {
                        if (cliente.Id == idCliente)
                        {
                            seleccionado = cliente;
                            break;
                        }
                    }

                    if (seleccionado == null)
                        throw new Exception("No se encontro el cliente.");

                    txtNombre.Text = seleccionado.Nombre;
                    txtApellido.Text = seleccionado.Apellido;
                    txtDni.Text = seleccionado.Dni;
                    txtEmail.Text = seleccionado.Email;
                    txtTelefono.Text = seleccionado.Telefono;
                    txtDireccion.Text = seleccionado.Direccion;

                    Session["clienteSeleccionado"] = seleccionado;

                    if (!seleccionado.Activo)
                        btnInactivar.Text = "Reactivar";
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    throw;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                ClienteNegocio negocio = new ClienteNegocio();

                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Dni = txtDni.Text;
                cliente.Email = txtEmail.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Direccion = txtDireccion.Text;

                if (Request.QueryString["id"] != null)
                {
                    cliente.Id = int.Parse(Request.QueryString["id"]);
                    negocio.modificar(cliente);
                }
                else
                {
                    negocio.agregar(cliente);
                }

                Response.Redirect("Clientes.aspx", false);
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
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente seleccionado = (Cliente)Session["clienteSeleccionado"];

                if (seleccionado != null)
                {
                    negocio.eliminarLogico(
                        seleccionado.Id,
                        !seleccionado.Activo
                    );

                    Response.Redirect("Clientes.aspx", false);
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
