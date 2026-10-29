using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Marca { get; set; }
        public int Categoria { get; set; }
        public int Proveedor { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        public string ImagenUrl { get; set; }
        public bool Activo { get; set; }
    }
}
