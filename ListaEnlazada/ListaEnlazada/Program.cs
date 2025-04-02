using ListaEnlazada;

class Program
{
    static void Main(string[] args)
    {
        Lista lista1 = new Lista();
        Lista lista2 = new Lista();

        //lista1.AgregarPorCabeza(5);
        //lista1.AgregarPorCabeza(3);
        //lista1.AgregarPorCabeza(7);
        //lista1.AgregarPorCabeza(9);

        //lista2.AgregarPorCola(5);
        //lista2.AgregarPorCola(3);

        lista1.AgregarOrdenado(1);
        lista1.AgregarOrdenado(50);
        lista1.AgregarOrdenado(30);
        lista1.AgregarOrdenado(32);
        lista1.AgregarOrdenado(3);

        //1 > 3 > 30 > 32 > 50 > null
        //1 > 3 > 5 > 30 > 32 > 50 > null

        lista1.InsertarDespuesDe(5, 32);

        lista1.Imprimir();
        Console.WriteLine(lista1.Localizar(500));
        Console.WriteLine(lista1.Localizar(50));

        //lista1.EliminarDato(50);
        //lista1.EliminarDato(500);
        //lista1.Imprimir();

        // lista2.Imprimir();






    }
}