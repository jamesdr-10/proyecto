using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialAmigos
{
    class RedDeUsuarios
    {
        private Persona cabeza;
        private Persona cola;
        private Persona actual;
        private int contadorPersona;
        private TablaHash tablaDirectorio;

        public RedDeUsuarios()
        {
            tablaDirectorio = new TablaHash(10);
        }

        public void AgregarUsuario()
        {
            Console.Write("Digite el nombre de la persona: ");
            string nombre = Console.ReadLine();
            Console.Write("Digite el apellido del usuario: ");
            string apellido = Console.ReadLine();
            int edad;
            while (true)
            {
                Console.Write("Digite la edad de la persona: ");
                try
                {
                    edad = Convert.ToInt32(Console.ReadLine());

                    if (edad > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingresa una edad mayor que 0.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Por favor ingresa un número válido.");
                }
            }
            Console.Write("Digite el teléfono de la persona: ");
            string telefono = Console.ReadLine();
            Console.Write("Digite el email de la persona: ");
            string email = Console.ReadLine();

            if (BuscarPorEmail(email) != null)
            {
                Console.WriteLine("Error: Ya existe una persona con este email.");
                return;
            }

            if (tablaDirectorio.Buscar(telefono) != null)
            {
                Console.WriteLine("Error: Ya existe una persona con este número de teléfono.");
                return;
            }

            Persona nuevaPersona = new Persona(nombre, apellido, edad, telefono, email);
            contadorPersona++;

            tablaDirectorio.Insertar(nuevaPersona);

            if (cabeza == null)
            {
                cabeza = cola = nuevaPersona;
                cabeza.Siguiente = nuevaPersona;
                cabeza.Anterior = nuevaPersona;
                actual = cabeza;
            }
            else
            {
                cola.Siguiente = nuevaPersona;
                nuevaPersona.Anterior = cola;
                nuevaPersona.Siguiente = cabeza;
                cabeza.Anterior = nuevaPersona;
                cola = nuevaPersona;
            }
        }
        public Persona BuscarPorEmail(string email)
        {
            Persona actual = cabeza;
            if (actual == null)
            {
                return null;
            }

            do
            {
                if (actual.Email == email)
                {
                    return actual;
                }
                actual = actual.Siguiente;
            } while (actual != cabeza);

            return null;
        }

        public int ObtenerTotalUsuarios()
        {
            return contadorPersona;
        }
        public void MostrarFactorCarga()
        {
            double factorCarga = tablaDirectorio.ObtenerFactorCarga();
            Console.WriteLine($"El factor de carga del directorio telefónico es: {factorCarga}");
        }


        public void ImprimirAscendente()
        {
            Persona actual = cabeza;
            if (actual == null)
            {
                Console.WriteLine("No se han agregado personas todavía.");
                return;
            }
            else
            {
                int contador = 1;
                do
                {
                    Console.WriteLine($"Persona {contador}:");
                    actual.MostrarDatos();
                    Console.WriteLine();
                    contador++;
                    actual = actual.Siguiente;
                } while (actual != cabeza);
            }
        }

        public void ImprimirDescendente()
        {
            Persona actual = cola;
            if (actual == null)
            {
                Console.WriteLine("No se han agregado personas todavía.");
                return;
            }
            else
            {
                int contador = contadorPersona;
                do
                {
                    Console.WriteLine($"Persona {contador}:");
                    actual.MostrarDatos();
                    Console.WriteLine();
                    contador--;
                    actual = actual.Anterior;
                } while (actual != cola);
            }
        }

        public void PersonaActual()
        {
            if (actual == null)
            {
                Console.WriteLine("No hay personas registradas.");
            }
            else
            {
                actual.MostrarDatos();
            }
        }

        public void PersonaSiguiente()
        {
            if (actual == null)
            {
                Console.WriteLine("No se ha agregado una persona todavía.");
                return;
            }
            actual = actual.Siguiente;
        }

        public void PersonaAnterior()
        {
            if (actual == null)
            {
                Console.WriteLine("No se ha agregado una persona todavía.");
                return;
            }
            actual = actual.Anterior;
        }
    }
}