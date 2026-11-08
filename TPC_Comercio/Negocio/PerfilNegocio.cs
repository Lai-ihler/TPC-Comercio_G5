using Dominio;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PerfilNegocio
    {
        private const string SELECT_DATABASE = "SELECT * FROM PERFIL";
        public List<Perfil> listar()
        {
            List<Perfil> lista = new List<Perfil>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(SELECT_DATABASE);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Perfil p = new Perfil();
                    p.Id = (int)datos.Lector["ID"];
                    p.Descripcion = (string)datos.Lector["Descripcion"];
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
