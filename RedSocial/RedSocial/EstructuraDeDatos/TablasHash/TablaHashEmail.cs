using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialAmigos.EstructuraDeDatos.TablasHash
{
    class TablaHashEmail
    {
        private int tamaño = 100;
        private NodoHashEmail[] tabla;

        public TablaHashEmail()
        {
            tabla = new NodoHashEmail[tamaño];
        }
        public long TransformarCadena(string clave)
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

        public int ObtenerIndice(string clave)
        {
            long valorTransformado = TransformarCadena(clave);
            return (int)(valorTransformado % tamaño);
        }

        public bool Insertar(string email)
        {
            int indice = ObtenerIndice(email);
            NodoHashEmail actual = tabla[indice];
            while (actual != null)
            {
                if (actual.Email == email)
                {
                    return false;
                }
                actual = actual.Siguiente;
            }
            NodoHashEmail nuevo = new NodoHashEmail(email);
            nuevo.Siguiente = tabla[indice];
            tabla[indice] = nuevo;
            return true;
        }

        public bool Contiene(string email)
        {
            int indice = ObtenerIndice(email);
            NodoHashEmail actual = tabla[indice];
            while (actual != null)
            {
                if (actual.Email == email)
                {
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }
    }
}
