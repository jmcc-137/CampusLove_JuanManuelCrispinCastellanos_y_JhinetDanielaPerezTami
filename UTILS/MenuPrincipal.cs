using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusLove_JuanManuelCrispinCastellanos_y_JhinetDanielaPerezTami.UTILS
{
    public class MenuPrincipal
    {


        public void MostrarMenuPrincipal()
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
                Console.WriteLine("| 1. Ver cuenta                             |");
                Console.WriteLine("| 2. Ver perfiles y dar Like o Dislike      |");
                Console.WriteLine("| 3. Editar Cuenta                          |");
                Console.WriteLine("| 4. Añadir Informacion Personal            |");
                Console.WriteLine("| 5. Ir a Matches                           |");
                Console.WriteLine("| 6. Ver estadísticas del sistema           |");
                Console.WriteLine("| 7. Eliminar Cuenta                        |");
                Console.WriteLine("| 8. Salir                                  |");
                Console.WriteLine("============================================");
                Console.Write("Seleccione una opcion: ");

                string input = Console.ReadLine() ?? "";
                
                if (int.TryParse(input, out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            //VER CUENTA
                            pausa();
                            break;

                        case 2:
                            //VER PERFILES
                            pausa();
                            break;

                        case 3:
                            //EDITAR CUENTA
                            pausa();
                            break;

                        case 4:
                            //AÑADIR INFORMACION PERSONAL
                            pausa();
                            break;

                        case 5:
                            //IR A MATCHES
                            pausa();
                            break;

                        case 6:
                            //VER ESTADISTICAS
                            pausa();
                            break;

                        case 7:
                            //ELIMINAR CUENTA
                            pausa();
                            break;
                            
                        case 8:
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

