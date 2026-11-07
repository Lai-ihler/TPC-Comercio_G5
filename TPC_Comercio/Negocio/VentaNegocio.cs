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
    }
}
