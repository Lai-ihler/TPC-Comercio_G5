using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar(string id = "")
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT * FROM CATEGORIA";
                if (id != "")
                {
                    consulta += " WHERE ID = @id";
                    datos.setearParametro("@id", int.Parse(id));
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)datos.Lector["ID"];
                    categoria.Descripcion = (string)datos.Lector["Descripcion"];
                    categoria.Activo = (bool)datos.Lector["Activo"];
                    lista.Add(categoria);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregar(Categoria nueva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO CATEGORIA (Descripcion, Activo) VALUES (@desc, 1)");
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
        public void modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE CATEGORIA SET Descripcion = @desc WHERE ID = @id");
                datos.setearParametro("@desc", categoria.Descripcion);
                datos.setearParametro("@id", categoria.Id);
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
                datos.setearConsulta("UPDATE CATEGORIA SET Activo = @activo WHERE ID = @id");
                datos.setearParametro("@activo", activo);
                datos.setearParametro("@id", id);
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
        public bool existe(string descripcion, int idExcluir = 0)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT ID FROM CATEGORIA WHERE Descripcion = @desc AND ID <> @id");
                datos.setearParametro("@desc", descripcion);
                datos.setearParametro("@id", idExcluir);
                datos.ejecutarLectura();
                return datos.Lector.Read();
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
