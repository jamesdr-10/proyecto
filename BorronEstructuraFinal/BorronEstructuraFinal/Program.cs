using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using BorronEstructuraFinal;
namespace BorronFinal;


class program
{

    public static void MENU()
    {
        Console.WriteLine("**********Bienvenido********** ");
        Console.WriteLine("1 - Agregar Nuevo usuario ");
        Console.WriteLine("2 - Agregar Amigos ");
        Console.WriteLine("3 - Ver Solicitudes enviadas ");
        Console.WriteLine("4 - ver amigos ");
        Console.WriteLine("5 - Ver personas que te siguen");
        Console.WriteLine("6 - Ver solicitudes de Amistad ");
        Console.WriteLine("7 - Ver Arbol de la persona");
        Console.WriteLine("8 - Ver listado de personas en orden ascendente.  ");
        Console.WriteLine("9 - Ver listado de personas en orden descendente.");
        Console.WriteLine("10 - Ver factor de carga del directorio telefónico. ");
        Console.WriteLine("11 - Cambiar Usuario. ");
        Console.WriteLine("0 - Salir ");
        Console.WriteLine("****Digite la opcion que desea****");
    }

    static void Main(string[] args)
    { 
        ListaCircular lista = new ListaCircular();
        
        int numero;
        do
        {
            Console.Clear();
            lista.Recorrer();
            MENU();

            numero = int.Parse(Console.ReadLine());
            if (numero > 11 || numero < 0)
            {
                Console.Clear();
            }

            switch (numero)
            {
                case 1:
                    lista.AgregarPersona();
                    Console.Clear();

                    break;
                case 2:
                    Console.WriteLine("EN MANTENIMIENTO");

                    break;
                case 3:
                    Console.WriteLine("EN MANTENIMIENTO");
                    break;
                case 4:
                    Console.WriteLine("EN MANTENIMIENTO");
                    break;
                case 5:
                    Console.WriteLine("EN MANTENIMIENTO");
                    break;
                case 6:
                    Console.WriteLine("EN MANTENIMIENTO");
                    break;
                case 7:
                    Console.WriteLine("EN MANTENIMIENTO");
                    break;
                case 8:
                    Console.WriteLine("EN MANTENIMIENTO");
                    break;
                case 9:
                    Console.WriteLine("EN MANTENIMIENTO");
                    break;
                case 10:
                    Console.WriteLine("EN MANTENIMIENTO");
                    break;
                case 11:
                    Console.Clear();
                    lista.Recorrer();
                    break;
            }
        } while (numero != 0);
    }

}