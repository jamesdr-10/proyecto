using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RedArbolAmigos
{
    class Usuario
    {
        public string Nombre;
        public string Apellido;
        public int Edad;
        public string Telefono;
        public string Email;
        public Usuario Siguiente;
        public Usuario Anterior;

        public Usuario(string nombre, string apellido, int edad, string telefono, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Telefono = telefono;
            Email = email;
            Siguiente = null;
            Anterior = null;
        }
    }
}
