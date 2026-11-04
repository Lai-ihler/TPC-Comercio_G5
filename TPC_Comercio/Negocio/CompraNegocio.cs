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
    }
}
