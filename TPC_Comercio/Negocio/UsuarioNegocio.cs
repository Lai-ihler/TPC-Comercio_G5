using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private const string SELECT_BASE = "SELECT U.ID, U.NombreUsuario, U.Pass, U.Nombre, U.Apellido, U.Email, P.ID AS IDPERFIL, P.Descripcion AS PERFIL, U.Activo FROM USUARIO U INNER JOIN PERFIL P ON P.ID = U.Perfil";
        public List<Usuario> listar(string id = "")
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = SELECT_BASE;

                if (id != "")
                {
                    consulta += " WHERE U.ID = @id";
                    datos.setearParametro("@id", int.Parse(id));
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario u = new Usuario();
                    u.Id = (int)datos.Lector["ID"];
                    u.NombreUsuario = (string)datos.Lector["NombreUsuario"];
                    u.Pass = (string)datos.Lector["Pass"];
                    u.Nombre = (string)datos.Lector["Nombre"];
                    u.Apellido = (string)datos.Lector["Apellido"];
                    u.Email = (string)datos.Lector["Email"];
                    u.Perfil = new Perfil()
                    {
                        Id = (int)datos.Lector["IDPERFIL"],
                        Descripcion = (string)datos.Lector["PERFIL"]
                    };
                    u.Activo = (bool)datos.Lector["Activo"];
                    lista.Add(u);
                }
                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO USUARIO (NombreUsuario, Pass, Nombre, Apellido, Email, Perfil, Activo) " +
                    "VALUES (@NombreUsuario, @Pass, @Nombre, @Apellido, @Email, @Perfil, @Activo)");

                datos.setearParametro("@NombreUsuario", nuevo.NombreUsuario);
                datos.setearParametro("@Pass", nuevo.Pass);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Perfil", nuevo.Perfil.Id);
                datos.setearParametro("@Activo", nuevo.Activo);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE USUARIO SET NombreUsuario = @NombreUsuario, Pass = @Pass, Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Perfil = @Perfil WHERE ID = @Id");

                datos.setearParametro("@NombreUsuario", usuario.NombreUsuario);
                datos.setearParametro("@Pass", usuario.Pass);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Perfil", usuario.Perfil.Id);
                datos.setearParametro("@Id", usuario.Id);

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
                datos.setearConsulta("UPDATE USUARIO SET Activo = @Activo WHERE ID = @Id");
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
