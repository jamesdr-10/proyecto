using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaEnlazada
{
    class Lista
    {
        private Nodo cabeza;
        private Nodo cola;

        public void AgregarPorCabeza(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);
            if (cabeza == null)
            {
                cabeza = cola = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = cabeza;
                cabeza = nuevoNodo;
            }
        }

        public void AgregarPorCola(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);
            if (cabeza == null)
            {
                cabeza = cola = nuevoNodo;
            }
            else
            {
                cola.Siguiente = nuevoNodo;
                cola = nuevoNodo;
            }
        }

        public void AgregarOrdenado(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);
            if (cabeza == null)
            {
                cabeza = cola = nuevoNodo;
            }
            else
            {
                if (nuevoNodo.Dato < cabeza.Dato)
                {
                    nuevoNodo.Siguiente = cabeza;
                    cabeza = nuevoNodo;
                }
                else if (nuevoNodo.Dato >= cola.Dato)
                {
                    cola.Siguiente = nuevoNodo;
                    cola = nuevoNodo;
                }
                else
                {
                    Nodo actual = cabeza;
                    while (actual.Siguiente != null && nuevoNodo.Dato >= actual.Siguiente.Dato)
                    {
                        actual = actual.Siguiente;
                    }
                    nuevoNodo.Siguiente = actual.Siguiente;
                    actual.Siguiente = nuevoNodo;
                }
            }
        }

        public void InsertarDespuesDe(int dato, int buscarDato)
        {
            Nodo nuevoNodo = new Nodo(dato);
            if (cabeza == null)
            {
                Console.WriteLine("La lista está vacía, no hay elemento para insertar después de");
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Dato != buscarDato)
                {
                    actual = actual.Siguiente;
                    if (actual == null)
                    {
                        Console.WriteLine("No existe ese dato a buscar");
                    }
                }
                nuevoNodo.Siguiente = actual.Siguiente;
                actual.Siguiente = nuevoNodo;

                if (nuevoNodo.Siguiente == null)
                {
                    cola = nuevoNodo;
                }

            }
        }


        public int Localizar(int datoABuscar)
        {
            int contador = 1;
            if (cabeza == null)
            {
                return -1;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Dato != datoABuscar && actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                    contador++;
                }
                if (actual.Dato == datoABuscar)
                {
                    return contador;
                }
                else
                {
                    return -1;
                }
            }
        }

        public void EliminarDato(int datoAEliminar)
        {
            if (cabeza == null)
            {
                Console.WriteLine("La lista está vacía, no hay elemento para eliminar");
            }
            else
            {
                if (cabeza.Dato == datoAEliminar)
                {
                    cabeza = cabeza.Siguiente;
                }
                else
                {
                    Nodo actual = cabeza;
                    while (actual.Siguiente != null && actual.Siguiente.Dato != datoAEliminar)
                    {
                        actual = actual.Siguiente;
                    }

                    if (actual.Siguiente == null)
                    {
                        Console.WriteLine("No se encontró");
                    }
                    else
                    {
                        actual.Siguiente = actual.Siguiente.Siguiente;
                        if (actual.Siguiente == null)
                        {
                            cola = actual;
                        }
                    }
                }
            }
        }

        public void EliminarPorCabeza()
        {
            if (cabeza == null)
            {
                Console.WriteLine("La lista esta vacia, no hay ningún nodo por eliminar");
            }
            else
            {
                cabeza = cabeza.Siguiente;

                if (cabeza == null)
                {
                    cola = null;
                }
            }
        }

        public void EliminarPorCola()
        {
            if (cabeza == null)
            {
                Console.WriteLine("La lista esta vacia, no hay ningún nodo por eliminar");
            }
            else
            {
                if (cabeza == cola)
                {
                    cabeza = cola = null;
                }
                else
                {

                    Nodo actual = cabeza;
                    while (actual.Siguiente != cola)
                    {
                        actual = actual.Siguiente;
                    }

                    actual.Siguiente = null;
                    cola = actual;
                }
            }
        }

        public void Imprimir()
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                Console.Write($"{actual.Dato} -> ");
                actual = actual.Siguiente;
            }
            Console.Write("NULL");
            Console.WriteLine();




        }



    }
}
