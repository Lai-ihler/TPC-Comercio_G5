using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        private const string SELECT_BASE = "SELECT * FROM CLIENTE";
        public List<Cliente> listar(bool activos = true)
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(SELECT_BASE);
                datos.setearParametro("@Activo", activos);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Cliente c = new Cliente();

                    c.Id = (int)datos.Lector["Id"];
                    c.Nombre = (string)datos.Lector["Nombre"];
                    c.Apellido = (string)datos.Lector["Apellido"];
                    c.Dni = (string)datos.Lector["Dni"];
                    c.Email = (string)datos.Lector["Email"];
                    c.Telefono = (string)datos.Lector["Telefono"];
                    c.Direccion = (string)datos.Lector["Direccion"];
                    c.Activo = (bool)datos.Lector["Activo"];
                    lista.Add(c);
                }
                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO CLIENTE (Nombre, Apellido, Dni, Email, Telefono, Direccion, Activo) " +
                    "VALUES (@nombre, @apellido, @dni, @email, @telefono, @direccion, 1)"
                );

                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@dni", nuevo.Dni);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@telefono", nuevo.Telefono);
                datos.setearParametro("@direccion", nuevo.Direccion);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "UPDATE CLIENTE SET Nombre = @nombre, Apellido = @apellido, " +
                    "Dni = @dni, Email = @email, Telefono = @telefono, " +
                    "Direccion = @direccion WHERE ID = @id"
                );

                datos.setearParametro("@nombre", cliente.Nombre);
                datos.setearParametro("@apellido", cliente.Apellido);
                datos.setearParametro("@dni", cliente.Dni);
                datos.setearParametro("@email", cliente.Email);
                datos.setearParametro("@telefono", cliente.Telefono);
                datos.setearParametro("@direccion", cliente.Direccion);
                datos.setearParametro("@id", cliente.Id);

                datos.ejecutarAccion();
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
                    "UPDATE CLIENTE SET Activo = @activo WHERE ID = @id"
                );

                datos.setearParametro("@activo", activo);
                datos.setearParametro("@id", id);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool existe(string dni, int idExcluir = 0)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT ID FROM CLIENTE WHERE Dni = @dni AND ID <> @id"
                );

                datos.setearParametro("@dni", dni);
                datos.setearParametro("@id", idExcluir);
                datos.ejecutarLectura();

                return datos.Lector.Read();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
