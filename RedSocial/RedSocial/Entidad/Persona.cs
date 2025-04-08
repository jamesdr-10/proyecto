using RedSocialAmigos.EstructuraDeDatos.Colas;
using RedSocialAmigos.EstructuraDeDatos.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialAmigos.Entidad
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
        public ListaAmigos ListaDeAmigos;
        public ColaSolicitud SolicitudesAmistad;
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
            ListaDeAmigos = null;
            SolicitudesAmistad = null;
            TotalAmigos = 0;
        }

        public void MostrarDatos()
        {
            Console.WriteLine($"Nombre: {Nombre}, Apellido: {Apellido}, Edad: {Edad}, Email: {Email}, Telefono: {Telefono}, Total de amigos: {TotalAmigos}");
        }
    }
}
