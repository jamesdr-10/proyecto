using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialAmigos
{
    class TablaHash
    {
        private NodoHash[] tabla;
        private int tamañoTabla;
        private int numElementos;

        public TablaHash(int tamaño)
        {
            tamañoTabla = tamaño;
            tabla = new NodoHash[tamaño];
            numElementos = 0;
        }
        private long TransformarCadena(string clave)
        {
            long d = 0;
            for (int j = 0; j < clave.Length; j++)
            {
                d = d * 27 + clave[j];
            }

            if (d < 0)
            {
                d = -d;
            }

            return d;
        }

        private int ObtenerIndice(string clave)
        {
            long valorTransformado = TransformarCadena(clave);
            return (int)(valorTransformado % tamañoTabla);
        }
        public void Redimensionar()
        {
            int nuevoTamaño = tamañoTabla * 2;
            NodoHash[] nuevaTabla = new NodoHash[nuevoTamaño];

            for (int i = 0; i < tamañoTabla; i++)
            {
                NodoHash actual = tabla[i];
                while (actual != null)
                {
                    int nuevoIndice = (int)TransformarCadena(actual.Persona.Telefono) % nuevoTamaño;
                    NodoHash siguiente = actual.Siguiente;
                    actual.Siguiente = nuevaTabla[nuevoIndice];
                    nuevaTabla[nuevoIndice] = actual;
                    actual = siguiente;
                }
            }
            tabla = nuevaTabla;
            tamañoTabla = nuevoTamaño;
        }

        public bool Insertar(Persona persona)
        {

            if (ObtenerFactorCarga() >= 0.70)
            {
                Redimensionar();
            }

            int indice = ObtenerIndice(persona.Telefono);
            NodoHash nuevoNodo = new NodoHash(persona);

            if (tabla[indice] == null)
            {
                tabla[indice] = nuevoNodo;
                numElementos++;
                return true;
            }
            else
            {
                NodoHash actual = tabla[indice];
                while (actual != null)
                {
                    if (actual.Persona.Telefono == persona.Telefono)
                    {
                        return false;
                    }
                    actual = actual.Siguiente;
                }
                nuevoNodo.Siguiente = tabla[indice];
                tabla[indice] = nuevoNodo;
                numElementos++;
                return true;
            }
        }

        public Persona Buscar(string telefono)
        {
            int indice = ObtenerIndice(telefono);
            NodoHash actual = tabla[indice];

            while (actual != null)
            {
                if (actual.Persona.Telefono == telefono)
                {
                    return actual.Persona;
                }
                actual = actual.Siguiente;
            }
            return null;
        }
        public double ObtenerFactorCarga()
        {
            return (double)numElementos / tamañoTabla;
        }
    }
}