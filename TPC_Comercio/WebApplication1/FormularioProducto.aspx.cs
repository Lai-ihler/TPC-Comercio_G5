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
    public partial class FormularioProducto : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                ddlMarca.DataSource = marcaNegocio.listar();
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataBind();
                ddlMarca.Items.Insert(0, new ListItem("Selecciona una marca", ""));

                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                ddlCategoria.DataSource = categoriaNegocio.listar();
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();
                ddlCategoria.Items.Insert(0, new ListItem("Selecciona una categoria", ""));

                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                ddlProveedor.DataSource = proveedorNegocio.listar();
                ddlProveedor.DataTextField = "RazonSocial";
                ddlProveedor.DataValueField = "Id";
                ddlProveedor.DataBind();
                ddlProveedor.Items.Insert(0, new ListItem("Selecciona un proveedor", ""));

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                if (id != "")
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    Producto seleccionado = negocio.listar(id)[0];

                    Session.Add("productoSeleccionado", seleccionado);

                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtCosto.Text = seleccionado.Costo.ToString();
                    txtPrecioVenta.Text = seleccionado.PrecioVenta.ToString();

                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlProveedor.SelectedValue = seleccionado.Proveedor.Id.ToString();

                    txtStockActual.Text = seleccionado.StockActual.ToString();
                    txtStockMinimo.Text = seleccionado.StockMinimo.ToString();
                    txtPorcentajeGanancia.Text = seleccionado.PorcentajeGanancia.ToString();
                    txtImagenUrl.Text = seleccionado.ImagenUrl;

                    if (!seleccionado.Activo)
                        btnInactivar.Text = "Reactivar";
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto nuevo = new Producto();

            nuevo.Codigo = txtCodigo.Text;
            nuevo.Nombre = txtNombre.Text;
            nuevo.Descripcion = txtDescripcion.Text;
            nuevo.Costo = decimal.Parse(txtCosto.Text);
            nuevo.PrecioVenta = decimal.Parse(txtPrecioVenta.Text);

            nuevo.Marca = new Marca();
            nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

            nuevo.Categoria = new Categoria();
            nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

            nuevo.Proveedor = new Proveedor();
            nuevo.Proveedor.Id = int.Parse(ddlProveedor.SelectedValue);

            nuevo.StockActual = int.Parse(txtStockActual.Text);
            nuevo.StockMinimo = int.Parse(txtStockMinimo.Text);
            nuevo.PorcentajeGanancia = decimal.Parse(txtPorcentajeGanancia.Text);
            nuevo.ImagenUrl = txtImagenUrl.Text;
            nuevo.Activo = true;

            ProductoNegocio negocio = new ProductoNegocio();
            if (Request.QueryString["id"] != null)
            {
                nuevo.Id = int.Parse(Request.QueryString["id"]);
                negocio.modificar(nuevo);
            }
            else
            {
                negocio.agregar(nuevo);
            }

            Response.Redirect("Productos.aspx", false);
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                Producto productoSeleccionado = (Producto)Session["productoSeleccionado"];
                if (productoSeleccionado != null)
                {
                    negocio.eliminarLogico(productoSeleccionado.Id,!productoSeleccionado.Activo);
                    Response.Redirect("Productos.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                //Response.Redirect("Error.aspx");
            }
        }
    }
}