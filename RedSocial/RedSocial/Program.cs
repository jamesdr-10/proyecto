using RedSocialAmigos;

class Program
{
    static RedDeUsuarios redDeUsuarios = new RedDeUsuarios();
    public static void Menu()
    {

        Console.WriteLine("USUARIO ACTUAL\n");

        redDeUsuarios.PersonaActual();

        Console.WriteLine("\n=====================================");
        Console.WriteLine("            MENÚ PRINCIPAL          ");
        Console.WriteLine("=====================================");

        Console.WriteLine("\n[1] Agregar una persona nueva");
        Console.WriteLine("[2] Agregar un amigo");
        Console.WriteLine("[3] Ver las solicitudes de amistad aceptadas");
        Console.WriteLine("[4] Ver las amistades mutuas");
        Console.WriteLine("[5] Ver las amistades que no son mutuas (la persona actual no es amigo de quienes lo tienen como amigo)");
        Console.WriteLine("[6] Ver solicitudes de amistad pendientes");
        Console.WriteLine("[7] Ver árbol con la persona actual como raíz y luego ver el árbol como representación de lista");
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
                    redDeUsuarios.ArmarArbol();
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