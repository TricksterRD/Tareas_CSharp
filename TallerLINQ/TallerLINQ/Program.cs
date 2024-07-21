using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TallerLINQ
{
    internal class Program
    {
        [Table(Name = "Estudiandes")]
        public class Estudiante
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int Id { get; set; }

            [Column]
            public string Nombre { get; set; }

            [Column]
            public int Edad { get; set; }
        }

        static void Main(string[] args)
        {
            // Parte 1: Introducción a LINQ
            Console.WriteLine("");
            Console.WriteLine("Parte 1: Introducción a LINQ");
            Console.WriteLine("");

            List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var numerosPares = from numero in numeros
                               where numero % 2 == 0
                               select numero;

            var numerosImpares = from numero in numeros
                                 where numero % 2 != 0
                                 select numero;

            var numerosMayoresASeis = from numero in numeros
                                      where numero > 6
                                      select numero;

            Console.WriteLine("Números Pares:");
            foreach (var numero in numerosPares)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine("");

            Console.WriteLine("Números Impares:");
            foreach (var numero in numerosImpares)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine("");

            Console.WriteLine("Números Mayores a Seis:");
            foreach (var numero in numerosMayoresASeis)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine("");

            // Parte 2: Consultas a Colecciones
            Console.WriteLine("");
            Console.WriteLine("Parte 2: Consultas a Colecciones");
            Console.WriteLine("");

            List<Estudiante> estudiantes = new List<Estudiante>
            {
                new Estudiante { Id = 1, Nombre = "Yael", Edad = 20 },
                new Estudiante { Id = 2, Nombre = "Carlos", Edad = 22 },
                new Estudiante { Id = 3, Nombre = "José", Edad = 19 },
                new Estudiante { Id = 4, Nombre = "Gabriela", Edad = 18 },
                new Estudiante { Id = 5, Nombre = "Miguel", Edad = 25 },
                new Estudiante { Id = 6, Nombre = "María", Edad = 23 },
                new Estudiante { Id = 7, Nombre = "Julia", Edad = 27 }
            };

            // Filtrado de Datos
            var estudiantesMayoresDe20 = from estudiante in estudiantes
                                         where estudiante.Edad >= 20
                                         select estudiante;

            var estudiantesMenoresDe20 = from estudiante in estudiantes
                                         where estudiante.Edad < 20
                                         select estudiante;

            Console.WriteLine("Estudiantes Mayores de 20 Años:");
            foreach (var estudiante in estudiantesMayoresDe20)
            {
                Console.WriteLine(estudiante.Nombre);
            }
            Console.WriteLine("");

            Console.WriteLine("Estudiantes Menores de 20 Años:");
            foreach (var estudiante in estudiantesMenoresDe20)
            {
                Console.WriteLine(estudiante.Nombre);
            }
            Console.WriteLine("");

            // Ordenamiento de Datos
            var estudiantesOrdenadosPorEdad = from estudiante in estudiantes
                                              orderby estudiante.Edad
                                              select estudiante;
            Console.WriteLine("Estudiantes Ordenados por Edad:");
            foreach (var estudiante in estudiantesOrdenadosPorEdad)
            {
                Console.WriteLine(estudiante.Nombre);
            }

            Console.WriteLine("");

            var estudiantesOrdenadosPorId = from estudiante in estudiantes
                                            orderby estudiante.Id
                                            select estudiante;
            Console.WriteLine("Estudiantes Ordenados por Id:");
            foreach (var estudiante in estudiantesOrdenadosPorId)
            {
                Console.WriteLine(estudiante.Nombre);
            }

            Console.WriteLine("");

            // Proyección de Datos
            var nombresEstudiantes = from estudiante in estudiantes
                                     select estudiante.Nombre;
            Console.WriteLine("Nombres de los Estudiantes:");
            foreach (var nombre in nombresEstudiantes)
            {
                Console.WriteLine(nombre);
            }

            Console.WriteLine("");

            var IdEstudiantes = from estudiante in estudiantes
                                select estudiante.Id;
            Console.WriteLine("Id de los Estudiantes:");
            foreach (var Id in IdEstudiantes)
            {
                Console.WriteLine(Id);
            }

            Console.WriteLine("");

            // Parte 3: LINQ to SQL
            Console.WriteLine("");
            Console.WriteLine("Parte 3: LINQ to SQL");
            Console.WriteLine("");
            try
            {
                // Configurar la conexión a la base de datos
                string EscuelaDBConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EscuelaDB;Integrated Security=True";
                DataContext db = new DataContext(EscuelaDBConnectionString);

                // Consulta LINQ to SQL para obtener estudiantes mayores de 22 años
                var estudiantesMayoresDe22 = from estudiante in db.GetTable<Estudiandes>()
                                             where estudiante.Edad > 22
                                             select estudiante;

                Console.WriteLine("Estudiantes Mayores de 22 Años (LINQ to SQL):");
                foreach (var estudiante in estudiantesMayoresDe22)
                {
                    Console.WriteLine(estudiante.Nombre);
                }

                Console.WriteLine("");

                // Consulta LINQ to SQL para ordenar estudiantes menores de 25 años
                var OrdenarEstudiantesMenores25 = from estudiante in db.GetTable<Estudiandes>()
                                                  where estudiante.Edad < 25
                                                  select estudiante;

                Console.WriteLine("Estudiantes Menores de 25 Años (LINQ to SQL):");
                foreach (var estudiante in OrdenarEstudiantesMenores25)
                {
                    Console.WriteLine(estudiante.Nombre);
                }

                Console.WriteLine("");

                //Consulta LINQ to SQL para obtener estudiantes con la letra 'J'
                var ObtenerEstudiantesConLetraJ = from estudiante in db.GetTable<Estudiandes>()
                                                  where estudiante.Nombre.Contains("J")
                                                  select estudiante;

                Console.WriteLine("Estudiantes Con la letra 'J' (LINQ to SQL):");
                foreach (var estudiante in ObtenerEstudiantesConLetraJ)
                {
                    Console.WriteLine(estudiante.Nombre);
                }

                Console.WriteLine("");

                //Consulta LINQ to SQL para contar el total de estudiantes
                var TotalEstudiantes = db.GetTable<Estudiandes>().Count();
                Console.WriteLine("El total de estudiantes es: ");
                Console.WriteLine(TotalEstudiantes);

                Console.WriteLine("");

                //Consulta LINQ to SQL para obtener los estudiantes con ID menor o igual a 5
                var ObtenerEstudiantesPorIdMenorOigualA5 = from estudiante in db.GetTable<Estudiante>()
                                                           where estudiante.Id <= 5
                                                           select estudiante;

                Console.WriteLine("Estudiantes con ID menor o igual a 5 (LINQ to SQL):");
                foreach (var estudiante in ObtenerEstudiantesPorIdMenorOigualA5)
                {
                    Console.WriteLine($"ID: {estudiante.Id}, Nombre: {estudiante.Nombre}");
                }

                Console.WriteLine("");

                //Consulta LINQ to SQL para obtener los estudiantes con ID mayor o igual a 5

                var ObtenerEstudiantesPorIdMayorOigualA5 = from estudiante in db.GetTable<Estudiante>()
                                                           where estudiante.Id >= 5
                                                           select estudiante;

                Console.WriteLine("Estudiantes con ID mayor o igual a 5 (LINQ to SQL):");
                foreach (var estudiante in ObtenerEstudiantesPorIdMayorOigualA5)
                {
                    Console.WriteLine($"ID: {estudiante.Id}, Nombre: {estudiante.Nombre}");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error al intentar acceder a la base de datos: " + ex.Message);
            }

            Console.ReadLine();

        }
    }
}
