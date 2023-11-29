using System.ComponentModel.DataAnnotations;

namespace ProyectoAdministradorTienda.Models
{
    public class Usuario
    {
        
        public int IdUsuario { get; set; }

        public string Cedula { get; set; }

        public string Nombre { get; set; }


        public string Apellido { get; set; }


        private string Login { get; set; }


        private string Contrasenia { get; set; }


        private int NumeroSeguridad { get; set; }
    }
}
