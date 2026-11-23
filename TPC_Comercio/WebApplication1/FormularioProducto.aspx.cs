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
            txtCodigo.Enabled = false;

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
                cblProveedores.DataSource = proveedorNegocio.listar();
                cblProveedores.DataTextField = "RazonSocial";
                cblProveedores.DataValueField = "Id";
                cblProveedores.DataBind();

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                btnInactivar.Visible = id != "";

                if (id != "")
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    Producto seleccionado = negocio.listar(id)[0];

                    Session.Add("productoSeleccionado", seleccionado);

                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;

                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    
                    foreach (ListItem item in cblProveedores.Items)
                    {
                        item.Selected = seleccionado.ListaProveedores.Exists(
                            x => x.Id.ToString() == item.Value
                        );
                    }

                    txtStockMinimo.Text = seleccionado.StockMinimo.ToString();
                    txtPorcentajeGanancia.Text = seleccionado.PorcentajeGanancia.ToString();
                    txtImagenUrl.Text = seleccionado.ImagenUrl;

                    if (!seleccionado.Activo)
                        btnInactivar.Text = "Reactivar";
                }
                else
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    txtCodigo.Text = negocio.generarCodigo();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                /// Validaciones que muestran mensajes de error si los campos no cumplen con los requisitos. Terminan en Producto nuevo = new Producto();
                lblErrorMarca.Text = "";
                lblErrorCategoria.Text = "";
                lblErrorProveedor.Text = "";
                lblErrorStockMinimo.Text = "";

                Page.Validate();

                if (!Page.IsValid) return;

                if (ddlMarca.SelectedValue == "")
                {
                    lblErrorMarca.Text = "Selecciona una marca.";
                    return;
                }
                if (ddlCategoria.SelectedValue == "")
                {
                    lblErrorCategoria.Text = "Selecciona una categoria.";
                    return;
                }

                bool hayProveedorSeleccionado = false;

                foreach (ListItem item in cblProveedores.Items)
                {
                    if (item.Selected)
                    {
                        hayProveedorSeleccionado = true;
                        break;
                    }
                }

                if (!hayProveedorSeleccionado)
                {
                    lblErrorProveedor.Text = "Selecciona al menos un proveedor.";
                    return;
                }

                decimal porcentajeGanancia = decimal.Parse(txtPorcentajeGanancia.Text);
                int stockMinimo = int.Parse(txtStockMinimo.Text);

                if (stockMinimo <= 0)
                {
                    lblErrorStockMinimo.Text = "El stock minimo debe ser mayor a cero.";
                    return;
                }

                Producto nuevo = new Producto();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Proveedor = new Proveedor();
                nuevo.ListaProveedores = new List<Proveedor>();

                foreach (ListItem item in cblProveedores.Items)
                {
                    if (item.Selected)
                    {
                        Proveedor proveedor = new Proveedor();
                        proveedor.Id = int.Parse(item.Value);
                        nuevo.ListaProveedores.Add(proveedor);
                    }
                }

                nuevo.Proveedor = nuevo.ListaProveedores[0];

                nuevo.StockMinimo = int.Parse(txtStockMinimo.Text);
                nuevo.PorcentajeGanancia = porcentajeGanancia;
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
                Session.Add("error", ex);
                throw;
            }
        }
    }
}