using RedSocialAmigos.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialAmigos.EstructuraDeDatos.TablasHash
{
    class NodoHash
    {
        public Persona Persona;
        public NodoHash Siguiente;

        public NodoHash(Persona persona)
        {
            Persona = persona;
            Siguiente = null;
        }
    }
}
