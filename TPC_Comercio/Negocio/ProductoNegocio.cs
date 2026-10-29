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
        private const string SELECT_BASE = "SELECT * FROM PRODUCTO";

        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(SELECT_BASE);
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
                    p.Marca = (int)datos.Lector["Marca"];
                    p.Categoria = (int)datos.Lector["Categoria"];
                    p.Proveedor = (int)datos.Lector["Proveedor"];
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
    }
}
