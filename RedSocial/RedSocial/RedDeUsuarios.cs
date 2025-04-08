using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RedSocialAmigos
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
            tablaDirectorio = new TablaHash(10);
        }

        public void AgregarUsuario()
        {
            Console.Write("Digite el nombre de la persona: ");
            string nombre = Console.ReadLine().Trim();
            while (string.IsNullOrWhiteSpace(nombre) || !nombre.Replace(" ", "").All(char.IsLetter))
            {
                Console.WriteLine("Error: El nombre solo puede contener letras y no puede estar vacío.");
                Console.Write("Digite el nombre de la persona: ");
                nombre = Console.ReadLine().Trim();
            }
            nombre = string.Join(" ", nombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            Console.Write("Digite el apellido del usuario: ");
            string apellido = Console.ReadLine().Trim();
            while (string.IsNullOrWhiteSpace(apellido) || !apellido.Replace(" ", "").All(char.IsLetter))
            {
                Console.WriteLine("Error: El apellido solo puede contener letras y no puede estar vacío.");
                Console.Write("Digite el apellido del usuario: ");
                apellido = Console.ReadLine().Trim();
            }
            apellido = string.Join(" ", apellido.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            int edad;
            do
            {
                Console.Write("Digite la edad de la persona: ");
                if (int.TryParse(Console.ReadLine(), out edad) && edad > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor ingresa una edad válida mayor que 0.");
                }
            } while (true);

            Console.Write("Digite el teléfono de la persona: ");
            string telefono = Console.ReadLine().Trim();
            while (string.IsNullOrWhiteSpace(telefono) || !telefono.All(char.IsDigit))
            {
                Console.WriteLine("Error: El teléfono solo puede contener números y no puede estar vacío.");
                Console.Write("Digite el teléfono de la persona: ");
                telefono = Console.ReadLine().Trim();
            }

            while (tablaDirectorio.Buscar(telefono) != null)
            {
                Console.WriteLine("Error: Ya existe una persona con este número de teléfono.");
                Console.Write("Por favor, ingrese un teléfono diferente: ");
                telefono = Console.ReadLine().Trim();
                while (string.IsNullOrWhiteSpace(telefono) || !telefono.All(char.IsDigit))
                {
                    Console.WriteLine("Error: El teléfono solo puede contener números y no puede estar vacío.");
                    Console.Write("Digite el teléfono de la persona: ");
                    telefono = Console.ReadLine().Trim();
                }
            }

            Console.Write("Digite el email de la persona: ");
            string email = Console.ReadLine().Trim();
            while (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || email.Contains(" "))
            {
                Console.WriteLine("Error: Ingrese un email válido sin espacios.");
                Console.Write("Digite el email de la persona: ");
                email = Console.ReadLine().Trim();
            }

            while (BuscarPorEmail(email) != null)
            {
                Console.WriteLine("Error: Ya existe una persona con este email.");
                Console.Write("Por favor, ingrese un email diferente: ");
                email = Console.ReadLine().Trim();
                while (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || email.Contains(" "))
                {
                    Console.WriteLine("Error: Ingrese un email válido sin espacios.");
                    Console.Write("Digite el email de la persona: ");
                    email = Console.ReadLine().Trim();
                }
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
                Console.WriteLine("No se han agregado personas todavía.");
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
                Console.WriteLine("No se han agregado personas todavía.");
                return;
            }

            ColaSolicitud solicitud = actual.SolicitudesAmistad;
            ColaSolicitud anterior = null;

            if (solicitud == null)
            {
                Console.WriteLine("Esta persona no tiene solicitudes pendientes");
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
                Console.WriteLine("No se han agregado personas todavía.");
                return;
            }

            if (actual.ListaDeAmigos == null)
            {
                Console.WriteLine($"{actual.Nombre} {actual.Apellido} no tiene amigos agregados todavía.");
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
                Console.WriteLine("No hay personas registradas.");
                return;
            }

            Persona temp = cabeza;
            bool hayNoReciprocados = false;

            Console.WriteLine($"Personas que tienen a {actual.Nombre} {actual.Apellido} como amigo, pero tú no los has agregado:");

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
                Console.WriteLine("No hay persona actual seleccionada.");
                return;
            }

            NodoArbol raiz = new NodoArbol(actual);
            TablaHash hashEmails = new TablaHash(10);
            hashEmails.Insertar(actual.Email);

            ColaNodoArbol cola = new ColaNodoArbol();
            cola.Encolar(raiz);

            while (!cola.EstaVacia())
            {
                NodoArbol nodoActual = cola.Desencolar();
                ListaAmigos listaAmigos = nodoActual.Persona.ListaDeAmigos;

                while (listaAmigos != null)
                {
                    Persona amigo = listaAmigos.Amigo;
                    if (!hashEmails.C(amigo.Email))
                    {
                        hashEmails.Insertar(amigo.Email);
                        TreeNode nuevoHijo = new TreeNode(amigo);
                        nodoActual.AgregarHijo(nuevoHijo);
                        cola.Enqueue(nuevoHijo);
                    }
                    listaAmigos = listaAmigos.Siguiente;
                }
            }

            Console.WriteLine($"Árbol con raíz en {actual.Nombre} {actual.Apellido}:");
            ImprimirArbolComoLista(raiz, 0);
        }

        private void ImprimirArbolComoLista(TreeNode nodo, int nivel)
        {
            if (nodo == null) return;

            string indentacion = new string(' ', nivel * 4);
            Console.WriteLine($"{indentacion}- {nodo.Persona.Nombre} {nodo.Persona.Apellido} ({nodo.Persona.Email})");

            TreeNode hijoActual = nodo.PrimerHijo;
            while (hijoActual != null)
            {
                ImprimirArbolComoLista(hijoActual, nivel + 1);
                hijoActual = hijoActual.SiguienteHijo;
            }
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
            Console.WriteLine($"El factor de carga del directorio telefónico es: {factorCarga}");
        }


        public void ImprimirAscendente()
        {
            Persona actual = cabeza;
            if (actual == null)
            {
                Console.WriteLine("No se han agregado personas todavía.");
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
                Console.WriteLine("No se han agregado personas todavía.");
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
                Console.WriteLine("No hay personas registradas.");
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
                Console.WriteLine("No se ha agregado una persona todavía.");
                return;
            }
            actual = actual.Siguiente;
        }

        public void PersonaAnterior()
        {
            if (actual == null)
            {
                Console.WriteLine("No se ha agregado una persona todavía.");
                return;
            }
            actual = actual.Anterior;
        }




        //public class ArbolPersona
        //{
        //    private Persona usuarioRaiz;

        //    public ArbolPersona(Persona usuario)
        //    {
        //        usuarioRaiz = usuario;
        //    }

        //    public void ImprimirArbol()
        //    {
        //        if (usuarioRaiz == null)
        //        {
        //            Console.WriteLine("No hay usuario seleccionado.");
        //            return;
        //        }

        //        Console.WriteLine($"Árbol de relaciones de {usuarioRaiz.Nombre}:");
        //        Console.WriteLine($"\nNivel 0 (Tú): {usuarioRaiz.Nombre}");

        //        ImprimirNivel1();
        //        ImprimirNivel2();
        //    }

        //    private void ImprimirNivel1()
        //    {
        //        Console.WriteLine("\nNivel 1 (Amigos directos):");
        //        Amigos amigo = usuarioRaiz.Amigos.Primero;
        //        bool tieneAmigos = false;

        //        while (amigo != null)
        //        {
        //            Console.WriteLine($"- {amigo.Amigo.Nombre}");
        //            amigo = amigo.siguiente;
        //            tieneAmigos = true;
        //        }

        //        if (!tieneAmigos) Console.WriteLine("No tienes amigos aún.");
        //    }

        //    private void ImprimirNivel2()
        //    {
        //        Console.WriteLine("\nNivel 2 (Amigos de amigos - Sugerencias):");
        //        Amigos amigo = usuarioRaiz.Amigos.Primero;
        //        bool tieneSugerencias = false;

        //        while (amigo != null)
        //        {
        //            Amigos amigoDeAmigo = amigo.Amigo.Amigos.Primero;
        //            while (amigoDeAmigo != null)
        //            {
        //                if (!usuarioRaiz.Amigos.ExisteAmigo(amigoDeAmigo.Amigo) &&
        //                    amigoDeAmigo.Amigo != usuarioRaiz)
        //                {
        //                    Console.WriteLine($"- {amigoDeAmigo.Amigo.Nombre} (amigo de {amigo.Amigo.Nombre})");
        //                    tieneSugerencias = true;
        //                }
        //                amigoDeAmigo = amigoDeAmigo.siguiente;
        //            }
        //            amigo = amigo.siguiente;
        //        }

        //        if (!tieneSugerencias) Console.WriteLine("No hay sugerencias disponibles.");
        //    }


        //}
    }
}