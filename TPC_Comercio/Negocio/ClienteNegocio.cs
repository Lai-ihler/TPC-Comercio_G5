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
    }
}
