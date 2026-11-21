using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class FormularioVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                ddlCliente.DataSource = clienteNegocio.listar();
                ddlCliente.DataTextField = "Nombre";
                ddlCliente.DataValueField = "Id";
                ddlCliente.DataBind();
                ddlCliente.Items.Insert(0, new ListItem("Selecciona un Cliente", ""));

                
                ProductoNegocio productoNegocio = new ProductoNegocio();
                ddlProducto.DataSource = productoNegocio.listar();
                ddlProducto.DataTextField = "Nombre";
                ddlProducto.DataValueField = "Id";
                ddlProducto.DataBind();
                ddlProducto.Items.Insert(0, new ListItem("Selecciona un producto", ""));

                Session["DetalleVenta"] = new List<VentaDetalle>();
            }

        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            List<VentaDetalle> detalle = (List<VentaDetalle>)Session["DetalleVenta"];

            int idProducto = int.Parse(ddlProducto.SelectedValue);
            int cantidad = int.Parse(txtCantidad.Text);

            ProductoNegocio negocio = new ProductoNegocio();
            Producto producto = negocio.buscar(idProducto);
            if (producto == null)
                return;
            
            VentaDetalle nuevo = new VentaDetalle();

            nuevo.Producto = producto;
            nuevo.Cantidad = cantidad;
            nuevo.PrecioUnitario = producto.PrecioVenta;
            nuevo.Subtotal = producto.PrecioVenta * cantidad;
            detalle.Add(nuevo);

            gvDetalle.DataSource = detalle;
            gvDetalle.DataBind();
            decimal total = detalle.Sum(x => x.Subtotal);

            lblTotal.Text = total.ToString("C");
            Session["DetalleVenta"] = detalle;
        }
    }
}