﻿using System.ComponentModel.DataAnnotations;

namespace ProyectoAdministradorTienda.Models
{
    public class Usuario
    {
        
        public int idUsuario { get; set; }

        public string cedula { get; set; }

        public string nombre { get; set; }


        public string apellido { get; set; }


        public string login { get; set; }


        public string contrasenia { get; set; }


        public int numeroSeguridad { get; set; }
    }
}
