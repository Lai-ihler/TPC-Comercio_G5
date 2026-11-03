using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProveedorNegocio
    {
        private const string SELECT_DATABASE = "SELECT * FROM PROVEEDOR";
        public List<Proveedor> listar(bool activos = true)
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(SELECT_DATABASE);
                datos.setearParametro("@Activo", activos);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Proveedor p = new Proveedor();
                    p.Id = (int)datos.Lector["ID"];
                    p.RazonSocial = (string)datos.Lector["RazonSocial"];
                    p.Cuit = (string)datos.Lector["Cuit"];
                    p.Email = (string)datos.Lector["Email"];
                    p.Telefono = (string)datos.Lector["Telefono"];
                    p.Direccion = (string)datos.Lector["Direccion"];
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
