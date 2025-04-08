using RedSocialAmigos;

class Program
{
    static RedDeUsuarios redDeUsuarios = new RedDeUsuarios();
    public static void Menu()
    {

        Console.WriteLine("=====================================");
        Console.WriteLine("            USUARIO ACTUAL          ");
        Console.WriteLine("=====================================\n");

        redDeUsuarios.PersonaActual();

        Console.WriteLine("\n=====================================");
        Console.WriteLine("            MENÚ PRINCIPAL          ");
        Console.WriteLine("=====================================");

        Console.WriteLine("\n[1] Agregar una persona nueva a la lista");
        Console.WriteLine("[2] Agregar un amigo a la persona actual");
        Console.WriteLine("[3] Ver las solicitudes de amistad aceptadas de la persona actual");
        Console.WriteLine("[4] Ver los amigos de la persona actual que también tienen a este como amigo (amistad mutua)");
        Console.WriteLine("[5] Ver las personas que tienen a la persona actual como amigo, pero que no están en la lista de amigos de la persona actual");
        Console.WriteLine("[6] Ver solicitudes de amistad enviadas a la persona actual");
        Console.WriteLine("[7] Ver árbol con el usuario actual como raíz y luego ver el árbol como representación de lista");
        Console.WriteLine("[8] Ver listado de personas en orden ascendente");
        Console.WriteLine("[9] Ver listado de personas en orden descendente");
        Console.WriteLine("[10] Ver factor de carga del directorio teléfonico");
        Console.WriteLine("[11] Ver siguiente usuario");
        Console.WriteLine("[12] Ver usuario anterior");
        Console.WriteLine("[0] Salir");

        Console.WriteLine($"\nTotal de usuarios registrados: {redDeUsuarios.ObtenerTotalUsuarios()}");
        Console.WriteLine("\n**** Digite la opción que desea ****");
        Console.WriteLine("=====================================");
    }
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Menu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    redDeUsuarios.AgregarUsuario();
                    break;
                case "2":
                    Console.Clear();
                    redDeUsuarios.AgregarAmigo();
                    break;
                case "3":
                    Console.Clear();
                    redDeUsuarios.MostrarListaDeAmigos();
                    break;
                case "4":
                    Console.Clear();
                    redDeUsuarios.MostrarAmigosReciprocos();
                    break;
                case "5":
                    Console.Clear();
                    redDeUsuarios.MostrarAmigosNoReciprocos();
                    break;
                case "6":
                    Console.Clear();
                    redDeUsuarios.ProcesarSolicitudesAmistad();
                    break;
                case "7":
                    Console.Clear();
                    //redDeUsuarios.ArmarArbol();
                    break;
                case "8":
                    Console.Clear();
                    redDeUsuarios.ImprimirAscendente();
                    break;
                case "9":
                    Console.Clear();
                    redDeUsuarios.ImprimirDescendente();
                    break;
                case "10":
                    Console.Clear();
                    redDeUsuarios.MostrarFactorCarga();
                    break;
                case "11":
                    Console.Clear();
                    redDeUsuarios.PersonaSiguiente();
                    break;
                case "12":
                    Console.Clear();
                    redDeUsuarios.PersonaAnterior();
                    break;
                case "0":
                    Console.Clear();
                    Console.WriteLine("Saliendo del programa...");
                    continuar = false;
                    break;
                default:
                    Console.Clear();
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