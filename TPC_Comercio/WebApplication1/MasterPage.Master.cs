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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.LoginActivo && !(Page is Login || Page is Default || Page is Error))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
            }

            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Usuario usuario = (Usuario)Session["usuario"];
                UsuarioNegocio negocio = new UsuarioNegocio();
                List<Usuario> lista = negocio.listar(usuario.Id.ToString());
                if (lista.Count == 0 || !lista[0].Activo)
                {
                    Session.Clear();
                    Session.Add("error", "Tu usuario fue dado de baja. Comunicate con el administrador.");
                    Response.Redirect("Error.aspx", false);
                    return;
                }
                lblUsuario.Text = usuario.NombreUsuario;
            }
            if (Seguridad.LoginActivo && Seguridad.sesionActiva(Session["usuario"]) && !Seguridad.esAdmin(Session["usuario"]))
            {
                if (!(Page is Default || Page is Login || Page is Error || Page is Clientes || Page is FormularioCliente || Page is Ventas || Page is FormularioVenta || Page is DetalleVenta))
                {
                    Session.Add("error", "No tenés permisos para ingresar a esta pantalla. Se requiere perfil Administrador.");
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}