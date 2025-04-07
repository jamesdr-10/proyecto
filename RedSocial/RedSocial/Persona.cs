using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialAmigos
{
    class Persona
    {
        public string Nombre;
        public string Apellido;
        public int Edad;
        public string Telefono;
        public string Email;
        public Persona Siguiente;
        public Persona Anterior;
        //public ListaAmigos ListaDeAmigos;
        //public ColaSolicitudes SolicitudesAmistad;
        public int TotalAmigos;

        public Persona(string nombre, string apellido, int edad, string telefono, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Telefono = telefono;
            Email = email;
            Siguiente = null;
            Anterior = null;
            //ListaDeAmigos = new ListaAmigos();
            //SolicitudesAmistad = new ColaSolicitudes();
            TotalAmigos = 0;
        }

         public void MostrarDatos()
        {
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Apellido: {Apellido}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Total de amigos: {TotalAmigos}");
        }
    }
}
