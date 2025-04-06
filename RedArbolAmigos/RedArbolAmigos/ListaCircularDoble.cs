using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RedArbolAmigos
{
    class ListaCircularDoble
    {
        private Usuario cabeza;
        private Usuario cola;
        private Usuario actual;
        private TablaHash usuario = new TablaHash(100);
        private int contadorUsuario;

        public void AgregarUsuario()
        {
            Console.Write("Digite el nombre del usuario: ");
            string nombre = Console.ReadLine();
            Console.Write("Digite el apellido del usuario: ");
            string apellido = Console.ReadLine();
            Console.Write("Digite la edad del usuario: ");
            int edad = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite el teléfono del usuario: ");
            string telefono = Console.ReadLine();
            Console.Write("Digite el email del usuario: ");
            string email = Console.ReadLine();

            if (usuario.ExisteEmail(email))
            {
                Console.WriteLine($"Error: El correo {email} ya está registrado.");
                return;
            }

            if (usuario.ExisteTelefono(telefono))
            {
                Console.WriteLine($"Error: El teléfono {telefono} ya está registrado.");
                return;
            }

            Usuario nuevoUsuario = new Usuario(nombre, apellido, edad, telefono, email);
            contadorUsuario++;

            usuario.Insertar(nuevoUsuario);

            if (cabeza == null)
            {
                cabeza = cola = nuevoUsuario;
                cabeza.Siguiente = nuevoUsuario;
                cabeza.Anterior = nuevoUsuario;
                actual = cabeza;
            }
            else
            {
                cola.Siguiente = nuevoUsuario;
                nuevoUsuario.Anterior = cola;
                nuevoUsuario.Siguiente = cabeza;
                cabeza.Anterior = nuevoUsuario;
                cola = nuevoUsuario;
            }
        }

        public void UsuarioActual()
        {
            if (actual == null)
            {
                Console.WriteLine("No hay usuario actual.");
            }
            else
            {
                Console.Write($"Nombre: {actual.Nombre}\n");
                Console.Write($"Apellido: {actual.Apellido}\n");
                Console.Write($"Edad: {actual.Edad}\n");
                Console.Write($"Teléfono: {actual.Telefono}\n");
                Console.Write($"Email: {actual.Email}\n");
            }
        }

        public void ImprimirAscendente()
        {
            Usuario actual = cabeza;
            if (actual == null)
            {
                Console.WriteLine("No se han agregado usuarios todavía.");
                return;
            }
            else
            {
                int contador = 1;
                do
                {
                    Console.WriteLine($"Usuario {contador}:");
                    Console.Write($"Nombre: {actual.Nombre}\n");
                    Console.Write($"Apellido: {actual.Apellido}\n");
                    Console.Write($"Edad: {actual.Edad}\n");
                    Console.Write($"Teléfono: {actual.Telefono}\n");
                    Console.Write($"Email: {actual.Email}\n");
                    Console.WriteLine();
                    contador++;
                    actual = actual.Siguiente;
                } while (actual != cabeza);
            }
        }

        public void ImprimirDescendente()
        {
            Usuario actual = cola;
            if (actual == null)
            {
                Console.WriteLine("No se han agregado usuarios todavía.");
                return;
            }
            else
            {
                int contador = contadorUsuario;
                do
                {
                    Console.WriteLine($"Usuario {contador}:");
                    Console.Write($"Nombre: {actual.Nombre}\n");
                    Console.Write($"Apellido: {actual.Apellido}\n");
                    Console.Write($"Edad: {actual.Edad}\n");
                    Console.Write($"Teléfono: {actual.Telefono}\n");
                    Console.Write($"Email: {actual.Email}\n");
                    Console.WriteLine();
                    contador--;
                    actual = actual.Anterior;
                } while (actual != cola);
            }
        }

        public void UsuarioSiguiente()
        {
            if (actual == null)
            {
                Console.WriteLine("No se ha agregado un usuario todavía.");
                return;
            }
            else
            {
                actual = actual.Siguiente;
            }
        }

        public void UsuarioAnterior()
        {
            if (actual == null)
            {
                Console.WriteLine("No se ha agregado un usuario todavía.");
                return;
            }
            else
            {
                actual = actual.Anterior;
            }
        }

    }
}
