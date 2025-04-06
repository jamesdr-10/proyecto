using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace RedArbolAmigos
{
    class TablaHash
    {
        private int tamañoTabla;
        private Usuario[] tablaEmail;
        private Usuario[] tablaTelefono;
        private int numElementos;
        private double factorCarga;

        public TablaHash(int tamaño)
        {
            tamañoTabla = tamaño;
            tablaEmail = new Usuario[tamaño];
            tablaTelefono = new Usuario[tamaño];
            numElementos = 0;
            factorCarga = 0.0;
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

        public int PosicionEmail(string email)
        {
            int i = 0;
            long direccion = TransformarCadena(email);
            long indice = direccion % tamañoTabla;

            while (tablaEmail[indice] != null && !tablaEmail[indice].Email.Equals(email))
            {
                i++;
                indice = indice + i * 1;
                indice = indice % tamañoTabla;
            }
            return (int)indice;
        }

        public int PosicionTelefono(string telefono)
        {
            int i = 0;
            long direccion = TransformarCadena(telefono);
            long indice = direccion % tamañoTabla;

            while (tablaTelefono[indice] != null && !tablaTelefono[indice].Telefono.Equals(telefono))
            {
                i++;
                indice = indice + i * 1;
                indice = indice % tamañoTabla;
            }
            return (int)indice;
        }

        public bool ExisteEmail(string email)
        {
            int indice = PosicionEmail(email);
            if (tablaEmail[indice] != null && tablaEmail[indice].Email.Equals(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExisteTelefono(string telefono)
        {
            int indice = PosicionTelefono(telefono);
            if (tablaTelefono[indice] != null && tablaTelefono[indice].Telefono.Equals(telefono))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Insertar(Usuario usuario)
        {

            if (ExisteEmail(usuario.Email))
            {
                Console.WriteLine($"Error: El  correo {usuario.Email} ya está registrado.");
                return;
            }

            if (ExisteTelefono(usuario.Telefono))
            {
                Console.WriteLine($"Error: El  teléfono {usuario.Telefono} ya está registrado.");
                return;
            }

            int posicionEmail = PosicionEmail(usuario.Email);
            int posicionTelefono = PosicionTelefono(usuario.Telefono);
            tablaEmail[posicionEmail] = usuario;
            tablaTelefono[posicionTelefono] = usuario;
            numElementos++;
            factorCarga = (double)numElementos / tamañoTabla;
            if (factorCarga > 0.7)
            {
                Console.WriteLine("\n El faactor de carga supera el 70%. Conviene aumentar el tamaño");
            }
        }
        public Usuario BuscarPorEmail(string email)
        {
            int indice = PosicionEmail(email);
            if (tablaEmail[indice] != null && tablaEmail[indice].Email.Equals(email))
            {
                return tablaEmail[indice];
            }
            else
            {
                return null;
            }
        }

        public Usuario BuscarPorTelefono(string telefono)
        {
            int indice = PosicionTelefono(telefono);
            if (tablaTelefono[indice] != null && tablaTelefono[indice].Telefono.Equals(telefono))
            {
                return tablaTelefono[indice];
            }
            else
            {
                return null;
            }
        }
    }
}