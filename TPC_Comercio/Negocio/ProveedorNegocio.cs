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
        public List<Proveedor> listar(string id = "")
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT * FROM PROVEEDOR";
                if (id != "")
                {
                    consulta += " WHERE ID = @id";
                    datos.setearParametro("@id", int.Parse(id));
                }
                datos.setearConsulta(consulta);
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
            catch (Exception ex)
            {
                throw ex;
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
        public void modificar(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE PROVEEDOR SET RazonSocial = @razonSocial, Cuit = @cuit, Email = @email, Telefono = @telefono, Direccion = @direccion WHERE ID = @id");
                datos.setearParametro("@razonSocial", proveedor.RazonSocial);
                datos.setearParametro("@cuit", proveedor.Cuit);
                datos.setearParametro("@email", proveedor.Email);
                datos.setearParametro("@telefono", proveedor.Telefono);
                datos.setearParametro("@direccion", proveedor.Direccion);
                datos.setearParametro("@id", proveedor.Id);
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

        public void eliminarLogico(int id, bool activo = false)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "UPDATE PROVEEDOR SET Activo = @Activo WHERE ID = @Id"
                );
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
