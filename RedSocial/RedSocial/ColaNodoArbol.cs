using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialAmigos
{
    class ColaNodoArbol
    {
        private class NodoCola
        {
            public NodoArbol Valor;
            public NodoCola Siguiente;

            public NodoCola(NodoArbol valor)
            {
                Valor = valor;
                Siguiente = null;
            }
        }

        private NodoCola frente;
        private NodoCola final;

        public ColaNodoArbol()
        {
            frente = null;
            final = null;
        }

        public void Encolar(NodoArbol valor)
        {
            NodoCola nuevoNodo = new NodoCola(valor);
            if (final == null)
            {
                frente = final = nuevoNodo;
            }
            else
            {
                final.Siguiente = nuevoNodo;
                final = nuevoNodo;
            }
        }

        public NodoArbol Desencolar()
        {
            if (frente == null)
            {
                throw new InvalidOperationException("La cola está vacía.");
            }

            NodoArbol valor = frente.Valor;
            frente = frente.Siguiente;

            if (frente == null)
            {
                final = null;
            }

            return valor;
        }

        public bool EstaVacia()
        {
            return frente == null;
        }
    }
}
