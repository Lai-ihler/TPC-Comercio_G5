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
        public void Page_Load(object sender, EventArgs e)
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
        public void btnAgregar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";

            if (string.IsNullOrEmpty(ddlProducto.SelectedValue))
            {
                lblMensaje.Text = "Seleccioná un producto.";
                return;
            }

            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                lblMensaje.Text = "Ingresá una cantidad mayor a cero.";
                return;
            }

            int idProducto = int.Parse(ddlProducto.SelectedValue);

            ProductoNegocio negocio = new ProductoNegocio();
            Producto producto = negocio.buscar(idProducto);

            if (producto == null)
            {
                lblMensaje.Text = "No se encontró el producto.";
                return;
            }

            List<VentaDetalle> detalle =
                (List<VentaDetalle>)Session["DetalleVenta"];

            int cantidadYaAgregada = detalle
                .Where(x => x.Producto.Id == idProducto)
                .Sum(x => x.Cantidad);

            if (cantidad + cantidadYaAgregada > producto.StockActual)
            {
                lblMensaje.Text = "No hay stock suficiente para esa cantidad.";
                return;
            }

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
            txtCantidad.Text = "";
        }
        public void btnConfirmar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";

            try
            { 
            
                if (string.IsNullOrEmpty(ddlCliente.SelectedValue))
                {
                    lblMensaje.Text = "Seleccioná un cliente.";
                    return;
                }

                List<VentaDetalle> detalles =
                    (List<VentaDetalle>)Session["DetalleVenta"];
                if (detalles == null || detalles.Count == 0)
                {
                    lblMensaje.Text = "Agregá al menos un producto.";
                    return;
                }

                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario == null || usuario.Id <= 0)
                {
                    lblMensaje.Text = "No se encontró un usuario válido.";
                    return;
                }

                Venta nuevaVenta = new Venta();
                nuevaVenta.Fecha = DateTime.Now;

                nuevaVenta.Cliente = new Cliente();
                nuevaVenta.Cliente.Id = int.Parse(ddlCliente.SelectedValue);

                nuevaVenta.Usuario = usuario;

                nuevaVenta.Total = detalles.Sum(x => x.Subtotal);
                VentaNegocio negocio = new VentaNegocio();
                negocio.agregar(nuevaVenta, detalles);

                Session["DetalleVenta"] = new List<VentaDetalle>();
                gvDetalle.DataSource = null;
                gvDetalle.DataBind();
                lblTotal.Text = "$0";
                txtCantidad.Text = "";

                lblMensaje.CssClass = "text-success";
                lblMensaje.Text = "Venta registrada correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Error al registrar la venta: " + ex.Message;
            }
        }
    }
}