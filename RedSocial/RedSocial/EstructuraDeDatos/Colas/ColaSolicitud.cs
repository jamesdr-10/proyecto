using RedSocialAmigos.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialAmigos.EstructuraDeDatos.Colas
{
    class ColaSolicitud
    {
        public Persona Solicitante;
        public ColaSolicitud Siguiente;

        public ColaSolicitud(Persona solicitante)
        {
            Solicitante = solicitante;
            Siguiente = null;
        }
    }
}
