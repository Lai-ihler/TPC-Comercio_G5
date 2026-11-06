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
            negocio.agregar(nuevo);

            Response.Redirect("Productos.aspx", false);
        }
    }
}