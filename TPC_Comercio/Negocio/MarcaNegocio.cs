using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar(string id = "")
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT * FROM MARCA";
                if (id != "")
                {
                    consulta += " WHERE ID = @id";
                    datos.setearParametro("@id", int.Parse(id));
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.Id = (int)datos.Lector["ID"];
                    marca.Descripcion = (string)datos.Lector["Descripcion"];
                    marca.Activo = (bool)datos.Lector["Activo"];
                    lista.Add(marca);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregar(Marca nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO MARCA (Descripcion, Activo) VALUES (@desc, 1)");
                datos.setearParametro("@desc", nueva.Descripcion);
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

        public void modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE MARCA SET Descripcion = @desc WHERE ID = @id");
                datos.setearParametro("@desc", marca.Descripcion);
                datos.setearParametro("@id", marca.Id);
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
