using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3_CSharp
{
    class Program
    {
        // Clase Estudiante
        class Estudiante
        {
            public string Nombre { get; set; }
            public double Calificacion { get; set; }

            public Estudiante(string nombre, double calificacion)
            {
                Nombre = nombre;
                Calificacion = calificacion;
            }

            public override string ToString()
            {
                return $"Nombre: {Nombre}, Calificación: {Calificacion}";
            }
        }

        // Funciones para manejar la lista de estudiantes
        static void ManejarEstudiantes()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            string opcion;
            do
            {
                Console.WriteLine("\nGestión de Estudiantes");
                Console.WriteLine("1. Agregar Estudiante");
                Console.WriteLine("2. Eliminar Estudiante");
                Console.WriteLine("3. Mostrar Estudiantes");
                Console.WriteLine("4. Salir");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre del estudiante: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Calificación del estudiante: ");
                        double calificacion = double.Parse(Console.ReadLine());
                        estudiantes.Add(new Estudiante(nombre, calificacion));
                        break;
                    case "2":
                        Console.Write("Nombre del estudiante a eliminar: ");
                        nombre = Console.ReadLine();
                        estudiantes.RemoveAll(e => e.Nombre == nombre);
                        break;
                    case "3":
                        Console.WriteLine("\nLista de Estudiantes:");
                        estudiantes.ForEach(e => Console.WriteLine(e));
                        break;
                }
            } while (opcion != "4");
        }

        // Funciones para manejar la cola de atención al cliente
        static void ManejarClientes()
        {
            Queue<string> clientes = new Queue<string>();
            string opcion;
            do
            {
                Console.WriteLine("\nGestión de Clientes");
                Console.WriteLine("1. Agregar Cliente");
                Console.WriteLine("2. Atender Cliente");
                Console.WriteLine("3. Mostrar Clientes en Cola");
                Console.WriteLine("4. Salir");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre del cliente: ");
                        string cliente = Console.ReadLine();
                        clientes.Enqueue(cliente);
                        break;
                    case "2":
                        if (clientes.Count > 0)
                        {
                            Console.WriteLine($"Atendiendo a {clientes.Dequeue()}");
                        }
                        else
                        {
                            Console.WriteLine("No hay clientes en la cola.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("\nClientes en Cola:");
                        foreach (var c in clientes)
                        {
                            Console.WriteLine(c);
                        }
                        break;
                }
            } while (opcion != "4");
        }

        // Funciones para manejar la pila de tareas pendientes
        static void ManejarTareas()
        {
            Stack<string> tareas = new Stack<string>();
            string opcion;
            do
            {
                Console.WriteLine("\nGestión de Tareas");
                Console.WriteLine("1. Agregar Tarea");
                Console.WriteLine("2. Completar Tarea");
                Console.WriteLine("3. Mostrar Tareas Pendientes");
                Console.WriteLine("4. Salir");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Descripción de la tarea: ");
                        string tarea = Console.ReadLine();
                        tareas.Push(tarea);
                        break;
                    case "2":
                        if (tareas.Count > 0)
                        {
                            Console.WriteLine($"Tarea completada: {tareas.Pop()}");
                        }
                        else
                        {
                            Console.WriteLine("No hay tareas pendientes.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("\nTareas Pendientes:");
                        foreach (var t in tareas)
                        {
                            Console.WriteLine(t);
                        }
                        break;
                }
            } while (opcion != "4");
        }

        static void Main(string[] args)
        {
            string opcion;
            do
            {
                Console.WriteLine("\nMenu Principal");
                Console.WriteLine("1. Gestionar Estudiantes");
                Console.WriteLine("2. Gestionar Clientes");
                Console.WriteLine("3. Gestionar Tareas");
                Console.WriteLine("4. Salir");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ManejarEstudiantes();
                        break;
                    case "2":
                        ManejarClientes();
                        break;
                    case "3":
                        ManejarTareas();
                        break;
                }
            } while (opcion != "4");
        }
    }
}
