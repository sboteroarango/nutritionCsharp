using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
namespace C_
{
    class Program
    {
        public static void displayMenuNutricionista()
        {
            Console.WriteLine("que desea hacer: ");
            Console.WriteLine("1. calcular cuantos gramos de proteína y calorias ha comido hoy ");
            Console.WriteLine("2. ver los gramos de proteína y calorias de cada alimento");
            Console.WriteLine("3. ver la clasificación proteíca de los alimentos");
            Console.WriteLine("4. salir ");
        }

        public static void displayMenuPrincipal()
        {
            Console.WriteLine("que desea hacer: \n1. jugar al juego Personas Que Comen y Hacen Ejercicio\n2. llamar a su nutricionista ");
        }

        public static void displayMenuJuego()
        {
            Console.WriteLine("que desea hacer: \n1. dar de comer a una persona\n2. que una persona haga ejercicio\n3. ver los nutrientes en cada persona\n4. salir");
        }
        
        public static string[] cargarArchivo(string path)
        {
            string[] lines = File.ReadAllLines(path);
            return lines;
        }
        public static void mostrarCaracteristicasDelAlimento(List<Alimento> lista)
        {
            foreach (Alimento alimento in lista)
            {
                Console.WriteLine($"{alimento.Nombre}: {alimento.Gramos_de_proteina} gramos de proteina, {alimento.Calorias} calorias\n");   
            }
        }
        public static void displayDeAlimentos(List<Alimento> lista)
        {
            for (int i = 1; i <= lista.Count; i++)
            {
                Console.WriteLine($"{i}. {lista[i-1].Nombre}");
            }

        }
        public static void displayDePersonas(List<Persona> listaPersonas)
        {
            for (int i = 1; i <= listaPersonas.Count; i++)
            {
                Console.WriteLine($"{i}. {listaPersonas[i-1].Nombre}");
            }

        }

        public static void calcularNutrientesDia(List<Alimento> lista,Persona person)
        {
            int gramosDeProteinaDelDia = 0;
            int caloriasDelDia = 0;
            int respuesta = 0;
            do
            {
                Console.WriteLine("seleccione los alimentos que comió: ");
                displayDeAlimentos(lista);
                Console.WriteLine($"{lista.Count+1}. terminar");
                respuesta = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if(respuesta<lista.Count+1)
                {
                Console.WriteLine($"cuantas unidades de {lista[respuesta-1].Nombre} comio: ");
                int unidades = Convert.ToInt16(Console.ReadLine());
                gramosDeProteinaDelDia += (lista[respuesta-1].Gramos_de_proteina)*unidades;
                caloriasDelDia += (lista[respuesta-1].Calorias)*unidades;
                
                };
                
                
            } while (respuesta < lista.Count+1);
            Console.WriteLine($"{person.Nombre}, ha comido {gramosDeProteinaDelDia} gramos de proteina y {caloriasDelDia} calorias\n");
    
        }

        public static List<Alimento> pasarArrayHaciaListaDeAlimento(string[] lista)
        {
            List<Alimento> listaDeAlimentos = new List<Alimento>();
            foreach (string line in lista)
            {
                string[] listaCreada = line.Split(',');
                Alimento alimento = new Alimento(listaCreada[0],Convert.ToInt32(listaCreada[1]),Convert.ToInt32(listaCreada[2]));
                listaDeAlimentos.Add(alimento);
            }
            return listaDeAlimentos;

        }
        public static void darDeComerPersona(List<Persona> listaPersonas,List<Alimento> listaDeAlimentos)
        {
            Console.WriteLine("a que persona quiere dar de comer: ");
            displayDePersonas(listaPersonas);
            int optPersona = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("que alimento quiere darle a comer: ");
            displayDeAlimentos(listaDeAlimentos);
            int optAlimento = Convert.ToInt16(Console.ReadLine());
            listaPersonas[optPersona-1].comer(listaDeAlimentos[optAlimento-1]);
        }
        public static void hacerEjercicioPersona(List<Persona> listaPersonas)
        {
            Console.WriteLine("a que persona quiere poner a hacer ejercicio: ");
            displayDePersonas(listaPersonas);
            int optPersona = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("cuántas horas quiere que haga ejercicio: ");
            int optHoras = Convert.ToInt16(Console.ReadLine());
            listaPersonas[optPersona-1].hacerEjercicio(optHoras);

        }
        public static void mostrarNutrientesPersonas(List<Persona> listaPersonas)
        {
            for (int i = 1; i <= listaPersonas.Count; i++)
            {
                Console.WriteLine($"{i}. {listaPersonas[i-1].Nombre}: {listaPersonas[i-1].ProteinaPersona} gramos de proteina, {listaPersonas[i-1].CaloriasPersona} calorias");
            }

        }

        public static List<Persona> agregarPersonasLista()
        {
            Console.WriteLine("cuantas personas desea agregar al juego:");
            int numeroDePersonas = Convert.ToInt32(Console.ReadLine());
            List<Persona> listaPersonas = new List<Persona>();
            for (int i = 0; i < numeroDePersonas; i++)
            {
                Console.WriteLine($"cúal es el nombre de la persona {i+1}");
                listaPersonas.Add(new Persona(Console.ReadLine()));
            }
            return listaPersonas;
        }
        public static void mostrarClasificacionProteica(List<Alimento> listaAlimentos)
        {
            Console.WriteLine("alimentos con altos niveles de proteína:");
            foreach (Alimento alimento in listaAlimentos)
            {
                if(alimento.Gramos_de_proteina >= 5)
                {
                    Console.WriteLine(alimento.Nombre);
                }   
            }
            Console.WriteLine("alimentos con bajos niveles de proteína:");
            foreach (Alimento alimento in listaAlimentos)
            {
                if(alimento.Gramos_de_proteina < 5)
                {
                    Console.WriteLine(alimento.Nombre);
                }   
            }
        }

        static void Main(string[] args)
        {
            
            string[] lista = cargarArchivo("alimentos.txt");
            List<Alimento> listaDeAlimentos = pasarArrayHaciaListaDeAlimento(lista);
            displayMenuPrincipal();
            string respuestaUsuario = Console.ReadLine();
            if(respuestaUsuario == "1")
            {
                List<Persona> listaPersonas = agregarPersonasLista(); 
                int opt = 0;
                do
                {
                    displayMenuJuego();
                    opt = Convert.ToInt16(Console.ReadLine());
                    switch(opt)
                    {
                        case 1:
                        darDeComerPersona(listaPersonas,listaDeAlimentos);
                        break;
                        case 2:
                        hacerEjercicioPersona(listaPersonas);
                        break;
                        case 3:
                        mostrarNutrientesPersonas(listaPersonas);
                        break;
                        default:
                        break;
                    }
                } while (opt != 4);
                }

            if(respuestaUsuario == "2")
            {
            Console.WriteLine("ingrese su nombre: ");
            Persona usuario = new Persona(Console.ReadLine());
            int respuesta;
            do
            {
                displayMenuNutricionista();
                respuesta = Convert.ToInt16(Console.ReadLine());
                switch (respuesta)
            {
                case 1:
                    calcularNutrientesDia(listaDeAlimentos,usuario);
                    break;
                case 2:
                    mostrarCaracteristicasDelAlimento(listaDeAlimentos);
                    break;
                case 3:
                    mostrarClasificacionProteica(listaDeAlimentos);
                    break;
                
                default:
                    break;
            }
                
            } while (respuesta != 4);
            Console.WriteLine($"Hasta luego {usuario.Nombre}");
            }
        }
    }
}
