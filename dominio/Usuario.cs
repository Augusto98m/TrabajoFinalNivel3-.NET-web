using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string ImagenPerfil { get; set; }
        public bool TipoUsuario { get; set; }

        //public Usuario(string email, string pass, bool admin) 
        //{
        //    Email = email;
        //    Password = pass;
        //    TipoUsuario = admin;
        //}    
    }
}
