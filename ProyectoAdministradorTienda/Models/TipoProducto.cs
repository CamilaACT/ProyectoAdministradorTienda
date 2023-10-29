using System.ComponentModel.DataAnnotations;

namespace ProyectoAdministradorTienda.Models
{
    public class TipoProducto
    {
        
        public int idTipoProducto { get; set; }

        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
