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
        private const string SELECT_BASE = "SELECT * FROM USUARIO";
        public List<Usuario> listar(bool activos = true)
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(SELECT_BASE);
                datos.setearParametro("@Activo",activos);
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
                    u.Perfil = (int)datos.Lector["Perfil"];
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
    }
}
