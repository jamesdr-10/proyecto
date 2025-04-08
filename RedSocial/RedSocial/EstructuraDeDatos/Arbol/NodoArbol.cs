using RedSocialAmigos.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialAmigos.EstructuraDeDatos.Arbol
{
    class NodoArbol
    {
        public Persona Persona;
        public NodoArbol PrimerHijo;
        public NodoArbol SiguienteHijo;
        
        public NodoArbol(Persona persona)
        {
            Persona = persona;
            PrimerHijo = null;
            SiguienteHijo = null;
        }
    }
}