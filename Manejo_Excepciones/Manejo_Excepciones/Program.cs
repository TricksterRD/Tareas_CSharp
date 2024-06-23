using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_Excepciones
{
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException(string message) : base(message)
        {
        }
    }

    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string message) : base(message)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool validInputs = false;

            while (!validInputs)
            {
                try
                {
                    Console.Write("Ingrese su nombre de usuario: ");
                    string username = Console.ReadLine();

                    Console.Write("Ingrese su contraseña: ");
                    string password = Console.ReadLine();

                    if (string.IsNullOrEmpty(username))
                    {
                        throw new InvalidUsernameException("El nombre de usuario no debe estar vacío.");
                    }

                    if (password.Length < 8)
                    {
                        throw new InvalidPasswordException("La contraseña debe tener al menos 8 caracteres.");
                    }

                    Console.WriteLine("Nombre de usuario y contraseña válidos.");
                    validInputs = true;
                }
                catch (InvalidUsernameException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (InvalidPasswordException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("El proceso de validación ha finalizado.");
                }
            }
            Console.ReadLine();
        }
    }
}
