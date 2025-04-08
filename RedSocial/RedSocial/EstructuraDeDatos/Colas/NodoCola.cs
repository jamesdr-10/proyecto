using RedSocialAmigos.EstructuraDeDatos.Arbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialAmigos.EstructuraDeDatos.Colas
{
    class NodoCola
    {
        public NodoArbol NodoArbol;
        public NodoCola Siguiente;

        public NodoCola(NodoArbol nodo)
        {
            NodoArbol = nodo;
            Siguiente = null;
        }
    }
}
