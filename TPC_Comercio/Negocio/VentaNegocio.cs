using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentaNegocio
    {
        private const string SELECT_DATABASE = "SELECT V.ID, V.NumeroFactura, V.Fecha, V.Cliente AS ClienteId, C.Nombre AS ClienteNombre, C.Apellido AS ClienteApellido, " +
            "V.Usuario AS UsuarioId, U.NombreUsuario AS UsuarioNombre, V.Total FROM VENTA V INNER JOIN CLIENTE C ON C.ID = V.Cliente " +
            "INNER JOIN USUARIO U ON U.ID = V.Usuario";
        public List<Venta> listar()
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(SELECT_DATABASE);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta v = new Venta();
                    v.Id = (int)datos.Lector["ID"];
                    v.NumeroFactura = (string)datos.Lector["NumeroFactura"];
                    v.Fecha = (DateTime)datos.Lector["Fecha"];
                    v.Total = (decimal)datos.Lector["Total"];

                    v.Cliente = new Cliente();
                    v.Cliente.Id = (int)datos.Lector["ClienteId"];
                    v.Cliente.Nombre = (string)datos.Lector["ClienteNombre"];
                    v.Cliente.Apellido = (string)datos.Lector["ClienteApellido"];

                    v.Usuario = new Usuario();
                    v.Usuario.Id = (int)datos.Lector["UsuarioId"];
                    v.Usuario.NombreUsuario = (string)datos.Lector["UsuarioNombre"];

                    lista.Add(v);
                }
                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public string generarNumeroFactura()
        {
            int ultimoNumero = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT NumeroFactura FROM VENTA WHERE NumeroFactura LIKE 'FAC-%'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    string factura = (string)datos.Lector["NumeroFactura"];
                    int numero = int.Parse(factura.Substring(4));

                    if (numero > ultimoNumero)
                        ultimoNumero = numero;
                }

                return "FAC-" + (ultimoNumero + 1).ToString("D4");
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregar(Venta venta, List<VentaDetalle> detalles)
        {
            int idVenta = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO VENTA (NumeroFactura, Fecha, Cliente, Usuario, Total) " +
                    "VALUES ('PENDIENTE', @Fecha, @Cliente, @Usuario, @Total); " +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT) AS IdVenta"
                );

                datos.setearParametro("@Fecha", venta.Fecha);
                datos.setearParametro("@Cliente", venta.Cliente.Id);
                datos.setearParametro("@Usuario", venta.Usuario.Id);
                datos.setearParametro("@Total", venta.Total);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    idVenta = (int)datos.Lector["IdVenta"];
            }
            finally
            {
                datos.cerrarConexion();
            }

            venta.Id = idVenta;
            venta.NumeroFactura = "FAC-" + idVenta.ToString("D4");

            AccesoDatos datosFactura = new AccesoDatos();

            try
            {
                datosFactura.setearConsulta("UPDATE VENTA SET NumeroFactura = @NumeroFactura WHERE ID = @Id");
                datosFactura.setearParametro("@NumeroFactura", venta.NumeroFactura);
                datosFactura.setearParametro("@Id", idVenta);
                datosFactura.ejecutarAccion();
            }
            finally
            {
                datosFactura.cerrarConexion();
            }

            foreach (VentaDetalle detalle in detalles)
            {
                AccesoDatos datosDetalle = new AccesoDatos();

                try
                {
                    datosDetalle.setearConsulta(
                        "INSERT INTO VENTA_DETALLE (Venta, Producto, Cantidad, PrecioUnitario) " +
                        "VALUES (@Venta, @Producto, @Cantidad, @PrecioUnitario); " +
                        "UPDATE PRODUCTO SET StockActual = StockActual - @Cantidad WHERE ID = @Producto"
                    );

                    datosDetalle.setearParametro("@Venta", idVenta);
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
        public List<VentaDetalle> listarDetalles(int idVenta)
        {
            List<VentaDetalle> lista = new List<VentaDetalle>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT VD.ID, VD.Venta, VD.Producto, P.Nombre, " +
                    "VD.Cantidad, VD.PrecioUnitario " +
                    "FROM VENTA_DETALLE VD " +
                    "INNER JOIN PRODUCTO P ON P.ID = VD.Producto " +
                    "WHERE VD.Venta = @IdVenta"
                );

                datos.setearParametro("@IdVenta", idVenta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    VentaDetalle detalle = new VentaDetalle();

                    detalle.Id = (int)datos.Lector["ID"];
                    detalle.Cantidad = (int)datos.Lector["Cantidad"];
                    detalle.PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"];
                    detalle.Subtotal = detalle.Cantidad * detalle.PrecioUnitario;

                    detalle.Producto = new Producto();
                    detalle.Producto.Id = (int)datos.Lector["Producto"];
                    detalle.Producto.Nombre = (string)datos.Lector["Nombre"];

                    detalle.Venta = new Venta();
                    detalle.Venta.Id = (int)datos.Lector["Venta"];

                    lista.Add(detalle);
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


