using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.UTILS
{
    public class MenuPrincipal
    {
        static void Main(string[] args)
        {
            Console.Title = "Campus Love - Sistema de Emparejamiento";
            MostrarMenuPrincipal();
        }

        static void MostrarMenuPrincipal()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("============================================");
                Console.WriteLine("| Campus Love - Sistema de Emparejamiento  |");
                Console.WriteLine("============================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("| 1. Registrarse como nuevo usuario         |");
                Console.WriteLine("| 2. Ver perfiles y dar Like o Dislike      |");
                Console.WriteLine("| 3. Ver mis coincidencias (matches)        |");
                Console.WriteLine("| 4. Ver estadísticas del sistema           |");
                Console.WriteLine("| 5. Salir                                  |");
                Console.WriteLine("============================================");
                Console.Write("Seleccione una opcion: "); // ← Faltaba el ;

                string input = Console.ReadLine() ?? "";
                
                if (int.TryParse(input, out int opcion)) // ← Se declara 'opcion' aquí
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Función de registro no implementada aún.");
                            pausa();
                            break;

                        case 2:
                            Console.WriteLine("Función de mostrar perfiles no implementada aún.");
                            pausa();
                            break;

                        case 3:
                            Console.WriteLine("Función de ver matches no implementada aún.");
                            pausa();
                            break;

                        case 4:
                            Console.WriteLine("Función de estadísticas no implementada aún.");
                            pausa();
                            break;

                        case 5:
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

