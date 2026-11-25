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
    public partial class FormularioCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                ddlProveedor.DataSource = proveedorNegocio.listar();
                ddlProveedor.DataTextField = "RazonSocial";
                ddlProveedor.DataValueField = "Id";
                ddlProveedor.DataBind();
                ddlProveedor.Items.Insert(0, new ListItem("Selecciona un proveedor", ""));

                ProductoNegocio productoNegocio = new ProductoNegocio();
                ddlProducto.DataSource = productoNegocio.listar();
                ddlProducto.DataTextField = "Nombre";
                ddlProducto.DataValueField = "Id";
                ddlProducto.DataBind();
                ddlProducto.Items.Insert(0, new ListItem("Selecciona un producto", ""));

                Session["DetalleCompra"] = new List<CompraDetalle>();
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";

            // Recuperar lista temporal
            List<CompraDetalle> detalle =
                (List<CompraDetalle>)Session["DetalleCompra"];


            // Validar producto
            if (string.IsNullOrEmpty(ddlProducto.SelectedValue))
            {
                lblMensaje.Text = "Seleccioná un producto.";
                return;
            }


            // Validar cantidad
            int cantidad;

            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                lblMensaje.Text = "Ingresá una cantidad válida.";
                return;
            }


            // Validar precio
            decimal precio;

            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio <= 0)
            {
                lblMensaje.Text = "Ingresá un precio válido.";
                return;
            }


            // Buscar producto
            int idProducto = int.Parse(ddlProducto.SelectedValue);

            ProductoNegocio productoNegocio = new ProductoNegocio();

            Producto producto = productoNegocio.buscar(idProducto);


            if (producto == null)
            {
                lblMensaje.Text = "No se encontró el producto.";
                return;
            }


            // Crear detalle
            CompraDetalle nuevo = new CompraDetalle();

            nuevo.Producto = producto;
            nuevo.Cantidad = cantidad;
            nuevo.PrecioUnitario = precio;
            nuevo.Subtotal = cantidad * precio;


            // Agregar a la lista
            detalle.Add(nuevo);


            // Actualizar GridView
            gvDetalle.DataSource = detalle;
            gvDetalle.DataBind();


            // Calcular total
            decimal total = detalle.Sum(x => x.Subtotal);

            lblTotal.Text = total.ToString("C");


            // Guardar lista actualizada
            Session["DetalleCompra"] = detalle;


            // Limpiar campos
            txtCantidad.Text = "";
            txtPrecio.Text = "";
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            lblMensaje.CssClass = "text-danger";

            try
            {
                if (string.IsNullOrEmpty(ddlProveedor.SelectedValue))
                {
                    lblMensaje.Text = "Seleccioná un proveedor.";
                    return;
                }

                List<CompraDetalle> detalles =
                    (List<CompraDetalle>)Session["DetalleCompra"];

                if (detalles == null || detalles.Count == 0)
                {
                    lblMensaje.Text = "Agregá al menos un producto a la compra.";
                    return;
                }

                Usuario usuario = (Usuario)Session["usuario"];

                if (usuario == null || usuario.Id <= 0)
                {
                    lblMensaje.Text = "No se encontró un usuario válido.";
                    return;
                }

                Compra nuevaCompra = new Compra();
                nuevaCompra.Fecha = DateTime.Now;

                nuevaCompra.Proveedor = new Proveedor();
                nuevaCompra.Proveedor.Id = int.Parse(ddlProveedor.SelectedValue);

                nuevaCompra.Usuario = usuario;
                nuevaCompra.Total = detalles.Sum(x => x.Subtotal);

                CompraNegocio negocio = new CompraNegocio();
                negocio.agregar(nuevaCompra, detalles);

                Session["DetalleCompra"] = new List<CompraDetalle>();
                gvDetalle.DataSource = null;
                gvDetalle.DataBind();
                lblTotal.Text = "$0";
                txtCantidad.Text = "";
                txtPrecio.Text = "";

                lblMensaje.CssClass = "text-success";
                lblMensaje.Text = "Compra registrada correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Text = "Error al registrar la compra: " + ex.Message;
            }
        }
    }
}