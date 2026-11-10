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

        public void agregar(Proveedor nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO PROVEEDOR (RazonSocial, Cuit, Email, Telefono, Direccion, Activo) VALUES (@razonSocial, @cuit, @email, @telefono, @direccion, 1)");
                datos.setearParametro("@razonSocial", nuevo.RazonSocial);
                datos.setearParametro("@cuit", nuevo.Cuit);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@telefono", nuevo.Telefono);
                datos.setearParametro("@direccion", nuevo.Direccion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
