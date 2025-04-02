using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BorronEstructuraFinal;

class Nodo
{
    public string Nombre;
    public string Correo;
    public string Telefono;
    public int Edad;
    public Nodo Siguiente;
    public Nodo Anterior;


    public Nodo(string nombre, string correo, string telefono, int edad)
    {
        Nombre = nombre;
        Correo = correo;
        Telefono = telefono;
        Edad = edad;
        Siguiente = null;
        Anterior = null;
    }
}

class ListaCircular
{
    Nodo Cabeza = null;
    Nodo Cola = null;
    Nodo Actual = null;
    public void AgregarPersona()
    {
        Console.WriteLine("Introduzca el Nombre y apellido, CorreoElectronico, Telefono y edad:");
        string nombre = Console.ReadLine();
        string correo = Console.ReadLine();
        string telefono = Console.ReadLine();
        int edad = int.Parse(Console.ReadLine());

        Nodo NuevoNodo = new Nodo(nombre, correo, telefono, edad);

        if (Cabeza == null)
        {
            Cabeza = Cola = NuevoNodo;
            Cabeza.Siguiente = Cabeza;
            Cabeza.Anterior = Cabeza;
        }
        else
        {   
            NuevoNodo.Siguiente = Cabeza;
            NuevoNodo.Anterior = Cola;
            Cola.Siguiente = NuevoNodo;
            Cabeza.Anterior = NuevoNodo;
            Cola = NuevoNodo;
        }
    }

   
    //public void Imprimir()
    //{
    //    Actual = Cabeza;
    //    if (Actual == null)
    //    {
    //        Console.WriteLine("Agregue un Usuario");
    //        return;
    //    }

    //    do
    //    {
    //        Console.WriteLine($"Nombre: {Actual.Nombre}, Correo: {Actual.Correo}, Teléfono: {Actual.Telefono}, Edad: {Actual.Edad}");
    //        Actual = Actual.Siguiente;
    //    } while (Actual != Cabeza);
    //}

   


}


