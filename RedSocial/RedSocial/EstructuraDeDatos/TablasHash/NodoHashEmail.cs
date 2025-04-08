using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedSocialAmigos.EstructuraDeDatos.TablasHash
{
    class NodoHashEmail
    {
        public string Email;
        public NodoHashEmail Siguiente;
        public NodoHashEmail(string email)
        {
            Email = email;
            Siguiente = null;
        }
    }
}
