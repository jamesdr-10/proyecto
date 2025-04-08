using RedSocialAmigos.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialAmigos.EstructuraDeDatos.Listas
{
    class ListaAmigos
    {

        public Persona Amigo;
        public ListaAmigos Siguiente;

        public ListaAmigos(Persona amigo) 
        {
            Amigo = amigo;
            Siguiente = null;
        }
    }
}
