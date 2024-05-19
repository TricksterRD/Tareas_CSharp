using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Basica_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese su nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su edad");
            int edad = int.Parse(Console.ReadLine());

            if (edad >= 18) Console.WriteLine("Usted es mayor de edad");
            else Console.WriteLine("Usted es menor de edad");

            for (int i = 1; i <= 10; i++) { Console.WriteLine(i); };

            Console.ReadLine();
        }
    }
}
