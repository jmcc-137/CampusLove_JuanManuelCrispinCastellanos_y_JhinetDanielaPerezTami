using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.UTILS
{
    public class MenuInicio
    {
        public void MostrarMenuInicio()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================");
                Console.WriteLine("|        Campus Love-Menu Inicio           |");
                Console.WriteLine("============================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("| 1. Ingresar cuenta                        |");
                Console.WriteLine("| 2. Crear Cuenta                           |");
                Console.WriteLine("| 3. salir                                  |");
                Console.WriteLine("============================================");
                Console.Write("Seleccione una opcion: "); // ← Faltaba el ;

                string input = Console.ReadLine() ?? "";
                
                if (int.TryParse(input, out int opcion)) // ← Se declara 'opcion' aquí
                {
                    switch (opcion)
                    {
                        case 1:
                            //ingresar
                            pausa();
                            break;

                        case 2:
                            //crear cuenta
                            pausa();
                            break;

                        case 3:
                            Console.WriteLine("Saliendo de Campus Love...");
                            pausa();
                            salir = true;
                            break;

                        default:
                            Console.WriteLine("Opción inválida.");
                            pausa();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    pausa();
                }
            }
        }

        static void pausa()
        {
            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }
    }
}