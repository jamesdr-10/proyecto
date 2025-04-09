using RedSocialAmigos.Entidad;
using RedSocialAmigos.EstructuraDeDatos.Arbol;
using RedSocialAmigos.EstructuraDeDatos.Colas;
using RedSocialAmigos.EstructuraDeDatos.Listas;
using RedSocialAmigos.EstructuraDeDatos.TablasHash;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RedSocialAmigos.Main
{
    class RedDeUsuarios
    {
        private Persona cabeza;
        private Persona cola;
        private Persona actual;
        private int contadorPersona;
        private TablaHash tablaDirectorio;

        public RedDeUsuarios()
        {
            tablaDirectorio = new TablaHash(100);
        }

        public void AgregarUsuario()
        {
            Console.Write("Digite el nombre de la persona: ");
            string nombre = Console.ReadLine();

            Console.Write("Digite el apellido del usuario: ");
            string apellido = Console.ReadLine();

            int edad;
            while (true)
            {
                Console.Write("Digite la edad de la persona: ");
                if (int.TryParse(Console.ReadLine(), out edad))
                {
                    if (edad > 0)
                        break;
                    else
                        Console.WriteLine("Error: La edad debe ser mayor que 0. Intente nuevamente.");
                }
                else
                {
                    Console.WriteLine("Error: Debe ingresar un número válido para la edad. Intente nuevamente.");
                }
            }

            string telefono;
            while (true)
            {
                Console.Write("Digite el teléfono de la persona: ");
                telefono = Console.ReadLine();

                if (telefono.All(char.IsDigit))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: El teléfono debe contener únicamente números. Intente nuevamente.");
                }
            }

            if (tablaDirectorio.Buscar(telefono) != null)
            {
                Console.WriteLine("Error: Ya existe una persona con este número de teléfono.");
                return;
            }

            string email;
            while (true)
            {
                Console.Write("Digite el email de la persona: ");
                email = Console.ReadLine();

                if (email.Contains(" "))
                {
                    Console.WriteLine("Error: El email no puede contener espacios. Intente nuevamente.");
                }
                else
                {
                    break;
                }
            }

            if (BuscarPorEmail(email) != null)
            {
                Console.WriteLine("Error: Ya existe una persona con este email.");
                return;
            }

            Persona nuevaPersona = new Persona(nombre, apellido, edad, telefono, email);
            contadorPersona++;

            tablaDirectorio.Insertar(nuevaPersona);

            if (cabeza == null)
            {
                cabeza = cola = nuevaPersona;
                cabeza.Siguiente = nuevaPersona;
                cabeza.Anterior = nuevaPersona;
                actual = cabeza;
            }
            else
            {
                cola.Siguiente = nuevaPersona;
                nuevaPersona.Anterior = cola;
                nuevaPersona.Siguiente = cabeza;
                cabeza.Anterior = nuevaPersona;
                cola = nuevaPersona;
            }
        }
        public void AgregarAmigo()
        {
            if (actual == null)
            {
                Console.WriteLine("No se han registrado personas todavía.");
                return;
            }

            Console.Write("Correo de la persona a agregar: ");
            string email = Console.ReadLine();

            if (actual.Email == email)
            {
                Console.WriteLine("No puedes agregarte a ti mismo.");
                return;
            }

            Persona personaAgregar = BuscarPorEmail(email);

            if (personaAgregar == null)
            {
                Console.WriteLine("Esta persona no existe.");
                return;
            }

            if (YaSonAmigos(actual, personaAgregar))
            {
                Console.WriteLine("Ya eres amigo de esta persona.");
                return;
            }

            ColaSolicitud solicitudActual = personaAgregar.SolicitudesAmistad;
            while (solicitudActual != null)
            {
                if (solicitudActual.Solicitante.Email == actual.Email)
                {
                    Console.WriteLine("Ya enviaste una solicitud de amistad a esta persona.");
                    return;
                }
                solicitudActual = solicitudActual.Siguiente;
            }


            if (personaAgregar.SolicitudesAmistad == null)
            {
                personaAgregar.SolicitudesAmistad = new ColaSolicitud(actual);
            }
            else
            {
                ColaSolicitud ultimo = personaAgregar.SolicitudesAmistad;
                while (ultimo.Siguiente != null)
                {
                    ultimo = ultimo.Siguiente;
                }
                ultimo.Siguiente = new ColaSolicitud(actual);
            }

            Console.WriteLine("Solicitud de amistad enviada.");
        }

        public void ProcesarSolicitudesAmistad()
        {
            if (actual == null)
            {
                Console.WriteLine("No se han registrado personas todavía.");
                return;
            }

            ColaSolicitud solicitud = actual.SolicitudesAmistad;
            ColaSolicitud anterior = null;

            if (solicitud == null)
            {
                Console.WriteLine("No tienes solicitudes pendientes");
                return;
            }


            while (solicitud != null)
            {
                Console.WriteLine($"Tienes una solicitud de: {solicitud.Solicitante.Nombre} {solicitud.Solicitante.Apellido} ({solicitud.Solicitante.Email})");

                string opcion;
                do
                {
                    Console.Write("¿Deseas aceptarla? (S/N): ");
                    opcion = Console.ReadLine().ToUpper();
                }
                while (opcion != "S" && opcion != "N");

                if (opcion == "S")
                {
                    if (!YaSonAmigos(solicitud.Solicitante, actual))
                    {
                        ListaAmigos nuevoAmigo = new ListaAmigos(actual);
                        nuevoAmigo.Siguiente = solicitud.Solicitante.ListaDeAmigos;
                        solicitud.Solicitante.ListaDeAmigos = nuevoAmigo;

                        solicitud.Solicitante.TotalAmigos++;

                        Console.WriteLine("Solicitud aceptada.");
                    }
                    else
                    {
                        Console.WriteLine("Ya esta persona te tiene como amigo.");
                    }
                }
                else
                {
                    Console.WriteLine("Solicitud rechazada.");
                }
                if (anterior == null)
                {
                    actual.SolicitudesAmistad = solicitud.Siguiente;
                }
                else
                {
                    anterior.Siguiente = solicitud.Siguiente;
                }

                solicitud = solicitud.Siguiente;
            }
        }

        public void MostrarListaDeAmigos()
        {
            if (actual == null)
            {
                Console.WriteLine("No se han registrado personas todavía.");
                return;
            }

            if (actual.ListaDeAmigos == null)
            {
                Console.WriteLine($"No tienes amigos agregados todavía.");
                return;
            }

            Console.WriteLine($"Lista de amigos de {actual.Nombre} {actual.Apellido}:");

            ListaAmigos amigoActual = actual.ListaDeAmigos;
            int contador = 1;

            while (amigoActual != null)
            {
                Console.WriteLine($"{contador}. {amigoActual.Amigo.Nombre} {amigoActual.Amigo.Apellido} ({amigoActual.Amigo.Email})");
                amigoActual = amigoActual.Siguiente;
                contador++;
            }
        }

        public void MostrarAmigosReciprocos()
        {
            if (actual == null || actual.ListaDeAmigos == null)
            {
                Console.WriteLine("No tienes amigos registrados.");
                return;
            }

            Console.WriteLine($"Amigos mutuos de {actual.Nombre} {actual.Apellido}:");

            ListaAmigos amigoActual = actual.ListaDeAmigos;
            bool hayMutuos = false;

            while (amigoActual != null)
            {
                ListaAmigos listaDelOtro = amigoActual.Amigo.ListaDeAmigos;
                while (listaDelOtro != null)
                {
                    if (listaDelOtro.Amigo == actual)
                    {
                        Console.WriteLine($"- {amigoActual.Amigo.Nombre} {amigoActual.Amigo.Apellido} ({amigoActual.Amigo.Email})");
                        hayMutuos = true;
                        break;
                    }
                    listaDelOtro = listaDelOtro.Siguiente;
                }
                amigoActual = amigoActual.Siguiente;
            }

            if (!hayMutuos)
            {
                Console.WriteLine("No tienes amistades mutuas.");
            }
        }

        public void MostrarAmigosNoReciprocos()
        {
            if (actual == null)
            {
                Console.WriteLine("No se han registrado personas todavía.");
                return;
            }

            Persona temp = cabeza;
            bool hayNoReciprocados = false;

            Console.WriteLine($"Personas que te tienen como amigo, pero tú no los has agregado:");

            do
            {
                if (temp != actual && temp.ListaDeAmigos != null)
                {
                    ListaAmigos listaTemp = temp.ListaDeAmigos;
                    while (listaTemp != null)
                    {
                        if (listaTemp.Amigo == actual && !YaSonAmigos(actual, temp))
                        {
                            Console.WriteLine($"- {temp.Nombre} {temp.Apellido} ({temp.Email})");
                            hayNoReciprocados = true;
                            break;
                        }
                        listaTemp = listaTemp.Siguiente;
                    }
                }

                temp = temp.Siguiente;
            } while (temp != cabeza);

            if (!hayNoReciprocados)
            {
                Console.WriteLine("No hay personas que te hayan agregado sin reciprocidad.");
            }
        }

        public void ArmarArbol()
        {
            if (actual == null)
            {
                Console.WriteLine("No se han registrado personas todavía.");
                return;
            }

            NodoArbol raiz = new NodoArbol(actual);
            TablaHashEmail visitados = new TablaHashEmail();
            visitados.Insertar(actual.Email);

            NodoCola frente = new NodoCola(raiz);
            NodoCola final = frente;

            while (frente != null)
            {
                NodoArbol nodoActual = frente.NodoArbol;
                frente = frente.Siguiente;

                ListaAmigos amigo = nodoActual.Persona.ListaDeAmigos;
                while (amigo != null)
                {
                    Persona amigoPersona = amigo.Amigo;
                    if (!visitados.Contiene(amigoPersona.Email))
                    {
                        visitados.Insertar(amigoPersona.Email);
                        NodoArbol nuevoHijo = new NodoArbol(amigoPersona);

                        if (nodoActual.PrimerHijo == null)
                            nodoActual.PrimerHijo = nuevoHijo;
                        else
                        {
                            NodoArbol temp = nodoActual.PrimerHijo;
                            while (temp.SiguienteHijo != null)
                                temp = temp.SiguienteHijo;
                            temp.SiguienteHijo = nuevoHijo;
                        }

                        if (frente == null)
                            frente = final = new NodoCola(nuevoHijo);
                        else
                        {
                            final.Siguiente = new NodoCola(nuevoHijo);
                            final = final.Siguiente;
                        }
                    }
                    amigo = amigo.Siguiente;
                }
            }

            Console.WriteLine($"Árbol como representación en forma de lista:");
            Console.WriteLine(ObtenerRepresentacionLista(raiz));

        }

        public string ObtenerRepresentacionLista(NodoArbol nodo)
        {
            if (nodo == null)
            {
                return "";
            }

            string resultado = $"{nodo.Persona.Nombre} {nodo.Persona.Apellido}";

            if (nodo.PrimerHijo != null)
            {
                resultado += "(";
                NodoArbol hijo = nodo.PrimerHijo;
                while (hijo != null)
                {
                    resultado += ObtenerRepresentacionLista(hijo);
                    if (hijo.SiguienteHijo != null) resultado += ", ";
                    hijo = hijo.SiguienteHijo;
                }
                resultado += ")";
            }

            return resultado;
        }

        public bool YaSonAmigos(Persona p1, Persona p2)
        {
            ListaAmigos lista = p1.ListaDeAmigos;
            while (lista != null)
            {
                if (lista.Amigo.Email == p2.Email)
                    return true;
                lista = lista.Siguiente;
            }
            return false;
        }

        public Persona BuscarPorEmail(string email)
        {
            Persona actual = cabeza;
            if (actual == null)
            {
                return null;
            }

            do
            {
                if (actual.Email == email)
                {
                    return actual;
                }
                actual = actual.Siguiente;
            } while (actual != cabeza);

            return null;
        }

        public int ObtenerTotalUsuarios()
        {
            return contadorPersona;
        }
        public void MostrarFactorCarga()
        {
            double factorCarga = tablaDirectorio.ObtenerFactorCarga();
            Console.WriteLine($"El factor de carga del directorio telefónico es: {factorCarga} ({factorCarga * 100}%)");
        }

        public void ImprimirAscendente()
        {
            Persona actual = cabeza;
            if (actual == null)
            {
                Console.WriteLine("No se han registrado personas todavía.");
                return;
            }
            else
            {
                int contador = 1;
                do
                {
                    Console.WriteLine($"Persona {contador}:");
                    actual.MostrarDatos();
                    Console.WriteLine();
                    contador++;
                    actual = actual.Siguiente;
                } while (actual != cabeza);
            }
        }

        public void ImprimirDescendente()
        {
            Persona actual = cola;
            if (actual == null)
            {
                Console.WriteLine("No se han registrado personas todavía.");
                return;
            }
            else
            {
                int contador = contadorPersona;
                do
                {
                    Console.WriteLine($"Persona {contador}:");
                    actual.MostrarDatos();
                    Console.WriteLine();
                    contador--;
                    actual = actual.Anterior;
                } while (actual != cola);
            }
        }

        public void PersonaActual()
        {
            if (actual == null)
            {
                Console.WriteLine("No se han registrado personas todavía.");
            }
            else
            {
                actual.MostrarDatos();
            }
        }

        public void PersonaSiguiente()
        {
            if (actual == null)
            {
                Console.WriteLine("No se han registrado personas todavía.");
                return;
            }
            actual = actual.Siguiente;
        }

        public void PersonaAnterior()
        {
            if (actual == null)
            {
                Console.WriteLine("No se han registrado personas todavía.");
                return;
            }
            actual = actual.Anterior;
        }
    }
}