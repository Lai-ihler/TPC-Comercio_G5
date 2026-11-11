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
        private const string SELECT_BASE = "SELECT P.*, M.Descripcion AS MarcaDescripcion, C.Descripcion AS CategoriaDescripcion, PR.RazonSocial AS ProveedorRazonSocial FROM PRODUCTO P INNER JOIN MARCA M ON M.ID = P.Marca INNER JOIN CATEGORIA C ON C.ID = P.Categoria INNER JOIN PROVEEDOR PR ON PR.ID = P.Proveedor";

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
                    Producto p = new Producto();

                    p.Id = (int)datos.Lector["Id"];
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
    }
}
