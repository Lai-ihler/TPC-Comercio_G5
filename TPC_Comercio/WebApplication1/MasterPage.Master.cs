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
                lblUsuario.Text = usuario.NombreUsuario;
            }
        }
        protected void btnSalir_Click(object sender, EventArgs e)
		{
			Session.Clear();
			Response.Redirect("Login.aspx", false);
		}
}
}