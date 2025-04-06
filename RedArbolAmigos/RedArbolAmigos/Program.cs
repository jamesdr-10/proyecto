using RedArbolAmigos;
using System;

class Program
{
    static ListaCircularDoble listaCircularDoble = new ListaCircularDoble();
    public static void Menu()
    {
        Console.Clear();

        listaCircularDoble.UsuarioActual();

        Console.WriteLine("\n=====================================");
        Console.WriteLine("            MENÚ PRINCIPAL          ");
        Console.WriteLine("=====================================");

        Console.WriteLine("\n[1] Agregar un usuario nuevo a la lista");
        Console.WriteLine("[2] Agregar un amigo al usuario actual");
        Console.WriteLine("[3] Ver los amigos aceptados del usuario actual");
        Console.WriteLine("[4] Ver los amigos del usuario actual que también tienen a este como amigo");
        Console.WriteLine("[5] Ver los usuarios que tengan al usuario actual como amigo, pero que no están en la lista de amigos de este");
        Console.WriteLine("[6] Ver solicitudes de amistad del usuario actual");
        Console.WriteLine("[7] Ver árbol con el usuario actual como raíz y luego ver el árbol como representación de lista");
        Console.WriteLine("[8] Ver listado de personas en orden ascendente");
        Console.WriteLine("[9] Ver listado de personas en orden descendente");
        Console.WriteLine("[10] Ver factor de carga del directorio teléfonico");
        Console.WriteLine("[11] Ver siguiente usuario");
        Console.WriteLine("[12] Ver usuario anterior");
        Console.WriteLine("[0] Salir");

        Console.WriteLine("\n**** Digite la opción que desea ****");
        Console.WriteLine("=====================================");
    }
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Menu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    listaCircularDoble.AgregarUsuario();
                    break;
                case "2":
                    // Lógica para agregar un amigo a la persona visualizada
                    break;
                case "3":
                    // Lógica para imprimir los amigos aceptados de la persona visualizada
                    break;
                case "4":
                    // Lógica para imprimir los amigos aceptados que también tienen a esta persona como amigo
                    break;
                case "5":
                    // Lógica para imprimir las personas que tienen a la persona visualizada como amigo pero no en su lista
                    break;
                case "6":
                    // Lógica para trabajar con la cola de solicitudes de amistad
                    break;
                case "7":
                    // Lógica para armar el árbol y imprimirlo
                    break;
                case "8":
                    Console.Clear();
                    listaCircularDoble.ImprimirAscendente();
                    break;
                case "9":
                    Console.Clear();
                    listaCircularDoble.ImprimirDescendente();
                    break;
                case "10":
                    // Lógica para imprimir el factor de carga del directorio telefónico
                    break;
                case "11":
                    Console.Clear();
                    listaCircularDoble.UsuarioSiguiente();
                    break;
                case "12":
                    Console.Clear();
                    listaCircularDoble.UsuarioAnterior();
                    break;
                case "0":
                    Console.WriteLine("Saliendo del programa...");
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

            if (continuar)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}