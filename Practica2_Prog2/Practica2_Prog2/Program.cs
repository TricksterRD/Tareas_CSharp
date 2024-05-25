using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_Prog2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio 1

            Console.WriteLine("Ejercicio 1: Clases y Objetos");
            Console.WriteLine("");
            Console.WriteLine("");
            Libro libro1 = new Libro();
            libro1.Titulo = "Cien años de Soledad";
            libro1.Autor = "Gabriel García Marquez";
            libro1.Paginas = 417;
            libro1.MostrarInformacion();

            //Ejercicio 2

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Ejercicio 2: Herencia");
            Console.WriteLine("");
            Console.WriteLine("");
            Estudiante estudiante1 = new Estudiante();
            estudiante1.Nombre = "Yael";
            estudiante1.Edad = 20;
            estudiante1.Grado = "Ingeniería";
            estudiante1.MostrarInformacionEstudiante();

            //Ejercicio 3

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Ejercicio 3: Polimorfismo y Encapsulamiento");
            Console.WriteLine("");
            Console.WriteLine("");

            List<InstrumentoMusical> intrumentos = new List<InstrumentoMusical>()
            {
                new Guitarra(),
                new Piano()
            };

            foreach (var instrumento in intrumentos)
            {
                instrumento.Tocar();
            }

            Console.ReadLine();
        }

        public class Libro
        {
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public int Paginas { get; set; }

            public void MostrarInformacion()
            {
                Console.WriteLine($"Título: {Titulo}");
                Console.WriteLine($"Autor: {Autor}");
                Console.WriteLine($"Páginas: {Paginas}");
            }
        }

        public class Estudiante : Persona
        {
            public string Grado { get; set; }

            public void MostrarInformacionEstudiante()
            {
                Console.WriteLine($"Nombre: {Nombre}");
                Console.WriteLine($"Edad: {Edad}");
                Console.WriteLine($"Grado: {Grado}");
            }
        }
        public class Persona
        {
            public string Nombre  { get; set; }
            public int Edad { get; set; }
        }

        public class InstrumentoMusical
        {
            public virtual void Tocar()
            {
                Console.WriteLine("El intrumento está siendo tocado.");
            }
        }

        public class Guitarra : InstrumentoMusical
        {
            public override void Tocar()
            {
                Console.WriteLine("La Guitarra está siendo sonando.");
            }
        }

        public class Piano : InstrumentoMusical
        {
            public override void Tocar()
            {
                Console.WriteLine("El Piano está siendo sonando.");
            }
        }
    }
}