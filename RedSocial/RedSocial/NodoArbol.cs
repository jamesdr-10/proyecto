using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialAmigos
{
    class NodoArbol
    {
        public Persona Persona;
        public NodoArbol SiguienteHijo;
        public NodoArbol PrimerHijo;

        public NodoArbol(Persona persona)
        {
            Persona = persona;
            PrimerHijo = null;
            SiguienteHijo = null;
        }

        public void AgregarHijo(NodoArbol hijo)
        {
            if (PrimerHijo == null)
            {
                PrimerHijo = hijo;
            }
            else
            {
                NodoArbol actual = PrimerHijo;
                while (actual.SiguienteHijo != null)
                {
                    actual = actual.SiguienteHijo;
                }
                actual.SiguienteHijo = hijo;
            }
        }
    }
}