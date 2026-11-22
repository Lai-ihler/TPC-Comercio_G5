using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CompraNegocio
    {
        private const string SELECT_DATABASE = "SELECT C.ID, C.Fecha, C.Total, P.RazonSocial AS PROVEEDOR, U.NombreUsuario AS USUARIO FROM COMPRA C INNER JOIN PROVEEDOR P ON P.ID = C.Proveedor INNER JOIN USUARIO U ON U.ID = C.Usuario";
        public List<Compra> listar()
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(SELECT_DATABASE);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Compra c = new Compra();
                    c.Id = (int)datos.Lector["ID"];
                    c.Fecha = (DateTime)datos.Lector["Fecha"];
                    c.Proveedor = new Proveedor()
                    {
                        RazonSocial = (string)datos.Lector["PROVEEDOR"]
                    };
                    c.Usuario = new Usuario()
                    {
                        NombreUsuario = (string)datos.Lector["USUARIO"]
                    };
                    c.Total = (decimal)datos.Lector["Total"];
                    lista.Add(c);
                }
                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Compra compra, List<CompraDetalle> detalles)
        {
            int idCompra = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO COMPRA (Fecha, Proveedor, Usuario, Total) " +
                    "VALUES (@Fecha, @Proveedor, @Usuario, @Total); " +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT) AS IdCompra"
                );

                datos.setearParametro("@Fecha", compra.Fecha);
                datos.setearParametro("@Proveedor", compra.Proveedor.Id);
                datos.setearParametro("@Usuario", compra.Usuario.Id);
                datos.setearParametro("@Total", compra.Total);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    idCompra = (int)datos.Lector["IdCompra"];
            }
            finally
            {
                datos.cerrarConexion();
            }

            foreach (CompraDetalle detalle in detalles)
            {
                AccesoDatos datosDetalle = new AccesoDatos();

                try
                {
                    datosDetalle.setearConsulta(
                        "INSERT INTO COMPRA_DETALLE " +
                        "(Compra, Producto, Cantidad, PrecioUnitario) " +
                        "VALUES (@Compra, @Producto, @Cantidad, @PrecioUnitario); " +
                        "UPDATE PRODUCTO " +
                        "SET Costo = @PrecioUnitario, " +
                        "SET StockActual = StockActual + @Cantidad, " +
                        "PrecioVenta = @PrecioUnitario * (1 + PorcentajeGanancia / 100.0) " +
                        "WHERE ID = @Producto"
                    );

                    datosDetalle.setearParametro("@Compra", idCompra);
                    datosDetalle.setearParametro("@Producto", detalle.Producto.Id);
                    datosDetalle.setearParametro("@Cantidad", detalle.Cantidad);
                    datosDetalle.setearParametro("@PrecioUnitario", detalle.PrecioUnitario);

                    datosDetalle.ejecutarAccion();
                }
                finally
                {
                    datosDetalle.cerrarConexion();
                }
            }
        }
    }
}
