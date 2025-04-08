using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialAmigos.EstructuraDeDatos.TablasHash
{
    class TablaHashEmail
    {
        private const int TAMANO = 100;
        private NodoHashEmail[] tabla;

        public TablaHashEmail()
        {
            tabla = new NodoHashEmail[TAMANO];
        }

        private int ObtenerIndice(string clave)
        {
            int hash = 0;
            foreach (char c in clave)
                hash = (hash * 31 + c) % TAMANO;
            return hash;
        }

        public bool Insertar(string email)
        {
            int indice = ObtenerIndice(email);
            NodoHashEmail actual = tabla[indice];
            while (actual != null)
            {
                if (actual.Email == email)
                    return false;
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
                    return true;
                actual = actual.Siguiente;
            }
            return false;
        }
    }
}
