using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        private const string SELECT_BASE = "SELECT P.*, M.Descripcion AS MarcaDescripcion, C.Descripcion AS CategoriaDescripcion, PR.RazonSocial AS ProveedorRazonSocial, PP.Proveedor AS ProveedorAsociadoId, PROV.RazonSocial AS ProveedorAsociado FROM PRODUCTO P INNER JOIN MARCA M ON M.ID = P.Marca INNER JOIN CATEGORIA C ON C.ID = P.Categoria INNER JOIN PROVEEDOR PR ON PR.ID = P.Proveedor LEFT JOIN PRODUCTO_PROVEEDOR PP ON PP.Producto = P.ID LEFT JOIN PROVEEDOR PROV ON PROV.ID = PP.Proveedor";

        public List<Producto> listar(string id = "")
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = SELECT_BASE;

                if (id != "")
                {
                    consulta += " WHERE P.ID = @id";
                    datos.setearParametro("@id", int.Parse(id));
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int idProducto = (int)datos.Lector["Id"];
                    Producto existente = lista.Find(x => x.Id == idProducto);

                    if (existente != null)
                    {
                        if (datos.Lector["ProveedorAsociado"] != DBNull.Value)
                        {
                            existente.Proveedores += ", " + (string)datos.Lector["ProveedorAsociado"];

                            Proveedor proveedorAsociado = new Proveedor();
                            proveedorAsociado.Id = (int)datos.Lector["ProveedorAsociadoId"];
                            proveedorAsociado.RazonSocial = (string)datos.Lector["ProveedorAsociado"];

                            existente.ListaProveedores.Add(proveedorAsociado);
                        }

                        continue;
                    }

                    Producto p = new Producto();

                    p.Id = idProducto;
                    p.Codigo = (string)datos.Lector["Codigo"];
                    p.Nombre = (string)datos.Lector["Nombre"];
                    p.Descripcion = (string)datos.Lector["Descripcion"];
                    p.Costo = (decimal)datos.Lector["Costo"];
                    p.PrecioVenta = (decimal)datos.Lector["PrecioVenta"];

                    p.Marca = new Marca();
                    p.Marca.Id = (int)datos.Lector["Marca"];
                    p.Marca.Descripcion = (string)datos.Lector["MarcaDescripcion"];

                    p.Categoria = new Categoria();
                    p.Categoria.Id = (int)datos.Lector["Categoria"];
                    p.Categoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];

                    p.Proveedor = new Proveedor();
                    p.Proveedor.Id = (int)datos.Lector["Proveedor"];
                    p.Proveedor.RazonSocial = (string)datos.Lector["ProveedorRazonSocial"];

                    p.ListaProveedores = new List<Proveedor>();

                    if (datos.Lector["ProveedorAsociado"] == DBNull.Value)
                    {
                        p.Proveedores = "Sin proveedores asociados";
                    }
                    else
                    {
                        p.Proveedores = (string)datos.Lector["ProveedorAsociado"];

                        Proveedor proveedorAsociado = new Proveedor();
                        proveedorAsociado.Id = (int)datos.Lector["ProveedorAsociadoId"];
                        proveedorAsociado.RazonSocial = (string)datos.Lector["ProveedorAsociado"];

                        p.ListaProveedores.Add(proveedorAsociado);
                    }

                    p.StockActual = (int)datos.Lector["StockActual"];
                    p.StockMinimo = (int)datos.Lector["StockMinimo"];
                    p.PorcentajeGanancia = (decimal)datos.Lector["PorcentajeGanancia"];
                    p.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    p.Activo = (bool)datos.Lector["Activo"];

                    lista.Add(p);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
     
        }

        public string generarCodigo()
        {
            int ultimoNumero = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT Codigo FROM PRODUCTO WHERE Codigo LIKE 'PROD%'"
                );
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    string codigo = (string)datos.Lector["Codigo"];
                    int numero = int.Parse(codigo.Substring(4));

                    if (numero > ultimoNumero)
                        ultimoNumero = numero;
                }

                return "PROD" + (ultimoNumero + 1).ToString("D3");
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO PRODUCTO (Codigo, Nombre, Descripcion, Costo, PrecioVenta, Marca, Categoria, Proveedor, StockActual, StockMinimo, PorcentajeGanancia, ImagenUrl, Activo) VALUES (@Codigo, @Nombre, @Descripcion, @Costo, @PrecioVenta, @Marca, @Categoria, @Proveedor, @StockActual, @StockMinimo, @PorcentajeGanancia, @ImagenUrl, @Activo)");

                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Costo", nuevo.Costo);
                datos.setearParametro("@PrecioVenta", nuevo.PrecioVenta);
                datos.setearParametro("@Marca", nuevo.Marca.Id);
                datos.setearParametro("@Categoria", nuevo.Categoria.Id);
                datos.setearParametro("@Proveedor", nuevo.Proveedor.Id);
                datos.setearParametro("@StockActual", nuevo.StockActual);
                datos.setearParametro("@StockMinimo", nuevo.StockMinimo);
                datos.setearParametro("@PorcentajeGanancia", nuevo.PorcentajeGanancia);
                datos.setearParametro("@ImagenUrl", nuevo.ImagenUrl);
                datos.setearParametro("@Activo", nuevo.Activo);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }

            AccesoDatos datosId = new AccesoDatos();

            try
            {
                datosId.setearConsulta("SELECT ID FROM PRODUCTO WHERE Codigo = @Codigo");
                datosId.setearParametro("@Codigo", nuevo.Codigo);
                datosId.ejecutarLectura();

                if (datosId.Lector.Read())
                    nuevo.Id = (int)datosId.Lector["ID"];
            }
            finally
            {
                datosId.cerrarConexion();
            }

            guardarProveedores(nuevo.Id, nuevo.ListaProveedores);
        }

        public void modificar(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE PRODUCTO SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Costo = @Costo, PrecioVenta = @PrecioVenta, Marca = @Marca, Categoria = @Categoria, Proveedor = @Proveedor, StockActual = @StockActual, StockMinimo = @StockMinimo, PorcentajeGanancia = @PorcentajeGanancia, ImagenUrl = @ImagenUrl WHERE ID = @Id");

                datos.setearParametro("@Codigo", producto.Codigo);
                datos.setearParametro("@Nombre", producto.Nombre);
                datos.setearParametro("@Descripcion", producto.Descripcion);
                datos.setearParametro("@Costo", producto.Costo);
                datos.setearParametro("@PrecioVenta", producto.PrecioVenta);
                datos.setearParametro("@Marca", producto.Marca.Id);
                datos.setearParametro("@Categoria", producto.Categoria.Id);
                datos.setearParametro("@Proveedor", producto.Proveedor.Id);
                datos.setearParametro("@StockActual", producto.StockActual);
                datos.setearParametro("@StockMinimo", producto.StockMinimo);
                datos.setearParametro("@PorcentajeGanancia", producto.PorcentajeGanancia);
                datos.setearParametro("@ImagenUrl", producto.ImagenUrl);
                datos.setearParametro("@Id", producto.Id);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }

            guardarProveedores(producto.Id, producto.ListaProveedores);

        }

        public void eliminarLogico(int id,bool activo=false)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE PRODUCTO SET Activo = @Activo WHERE ID = @Id");
                datos.setearParametro("@Activo", activo);
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private void guardarProveedores(int idProducto, List<Proveedor> proveedores)
        {
            AccesoDatos datosEliminar = new AccesoDatos();

            try
            {
                datosEliminar.setearConsulta(
                    "DELETE FROM PRODUCTO_PROVEEDOR WHERE Producto = @IdProducto"
                );
                datosEliminar.setearParametro("@IdProducto", idProducto);
                datosEliminar.ejecutarAccion();
            }
            finally
            {
                datosEliminar.cerrarConexion();
            }

            foreach (Proveedor proveedor in proveedores)
            {
                AccesoDatos datosAgregar = new AccesoDatos();

                try
                {
                    datosAgregar.setearConsulta(
                        "INSERT INTO PRODUCTO_PROVEEDOR (Producto, Proveedor) " +
                        "VALUES (@IdProducto, @IdProveedor)"
                    );
                    datosAgregar.setearParametro("@IdProducto", idProducto);
                    datosAgregar.setearParametro("@IdProveedor", proveedor.Id);
                    datosAgregar.ejecutarAccion();
                }
                finally
                {
                    datosAgregar.cerrarConexion();
                }
            }
        }
    }
}
