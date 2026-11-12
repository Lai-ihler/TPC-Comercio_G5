using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class FormularioUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PerfilNegocio pn = new PerfilNegocio();
                ddlPerfil.DataSource = pn.listar();
                ddlPerfil.DataTextField = "Descripcion";
                ddlPerfil.DataValueField = "Id";
                ddlPerfil.DataBind();
                ddlPerfil.Items.Insert(0, new ListItem("Seleccione un perfil", ""));

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                btnInactivar.Visible = id != "";

                if (id != "")
                {
                    UsuarioNegocio un = new UsuarioNegocio();
                    Usuario us = un.listar(id)[0];

                    Session.Add("usuarioSeleccionado", us);

                    txtNombreUsuario.Text = us.NombreUsuario;
                    txtPass.Text = us.Pass;
                    txtNombre.Text = us.Nombre;
                    txtApellido.Text = us.Apellido.ToString();
                    txtEmail.Text = us.Email.ToString();

                    ddlPerfil.SelectedValue = us.Perfil.Id.ToString();

                    if (!us.Activo)
                        btnInactivar.Text = "Reactivar";
                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                Usuario u = new Usuario();
                u.NombreUsuario = txtNombreUsuario.Text;
                u.Pass = txtPass.Text;
                u.Nombre = txtNombre.Text;
                u.Apellido = txtApellido.Text;
                u.Email = txtEmail.Text;
                u.Perfil = new Perfil();
                u.Perfil.Id = int.Parse(ddlPerfil.SelectedValue);
                u.Activo = true;

                UsuarioNegocio un = new UsuarioNegocio();
                if (Request.QueryString["id"] != null)
                {
                    u.Id = int.Parse(Request.QueryString["id"]);
                    un.modificar(u);
                }
                else
                {
                    un.agregar(u);
                }

                Response.Redirect("Usuarios.aspx", false);
            }
            catch(Exception ex) 
            {
                Session.Add("error", ex);
                throw;
            }
        }
        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio un = new UsuarioNegocio();
                Usuario us = (Usuario)Session["usuarioSeleccionado"];
                if (us != null)
                {
                    un.eliminarLogico(us.Id, !us.Activo);
                    Response.Redirect("Usuarios.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                throw;
            }
        }
    }
}