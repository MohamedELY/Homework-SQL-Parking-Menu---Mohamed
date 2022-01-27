using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_SQL_Parking_Menu___Mohamed.Prints
{
    class Print
    {
        private static void Logo()
        {
            Console.Clear();
            Console.WriteLine("\n" +
                "██████╗░░█████╗░██████╗░██╗░░██╗██╗███╗░░██╗░██████╗░  ░██████╗██╗░░░██╗░██████╗████████╗███████╗███╗░░░███╗\n" +
                "██╔══██╗██╔══██╗██╔══██╗██║░██╔╝██║████╗░██║██╔════╝░  ██╔════╝╚██╗░██╔╝██╔════╝╚══██╔══╝██╔════╝████╗░████║\n" +
                "██████╔╝███████║██████╔╝█████═╝░██║██╔██╗██║██║░░██╗░  ╚█████╗░░╚████╔╝░╚█████╗░░░░██║░░░█████╗░░██╔████╔██║\n" +
                "██╔═══╝░██╔══██║██╔══██╗██╔═██╗░██║██║╚████║██║░░╚██╗  ░╚═══██╗░░╚██╔╝░░░╚═══██╗░░░██║░░░██╔══╝░░██║╚██╔╝██║\n" +
                "██║░░░░░██║░░██║██║░░██║██║░╚██╗██║██║░╚███║╚██████╔╝  ██████╔╝░░░██║░░░██████╔╝░░░██║░░░███████╗██║░╚═╝░██║\n" +
                "╚═╝░░░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝╚═╝╚═╝░░╚══╝░╚═════╝░  ╚═════╝░░░░╚═╝░░░╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░░░░╚═╝");
        }

        public static void Menu()
        {
            Logo();
            Console.WriteLine("\n\n\t\t\t\t\t~~~~~~~~~~~~ Menu ~~~~~~~~~~~~");
                Console.WriteLine("\t\t\t\t\t|  [1] Show                  |");
                Console.WriteLine("\t\t\t\t\t|  [2] Create                |");
                Console.WriteLine("\t\t\t\t\t|  [3] Interact              |");
                Console.WriteLine("\t\t\t\t\t|  [4] Delete                |");
                Console.WriteLine("\t\t\t\t\t|  [5] Exit                  |");
                Console.WriteLine("\t\t\t\t\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.Write("\t\t\t\t\tInput: ");
        }

        public static void MenuShow()
        {
            Logo();
            Console.WriteLine("\n\n\t\t\t\t\t~~~~~~~~~~~~ Show ~~~~~~~~~~~~");
                Console.WriteLine("\t\t\t\t\t|  [1] Cars                  |");
                Console.WriteLine("\t\t\t\t\t|  [2] Cities                |");
                Console.WriteLine("\t\t\t\t\t|  [3] Parking Houses        |");
                Console.WriteLine("\t\t\t\t\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.Write("\t\t\t\t\tInput: ");
        }

        public static void MenuShowSpot()
        {
            Logo();
            Console.WriteLine("\n\n\t\t\t\t\t~~~~~~~~~~~~ Spot ~~~~~~~~~~~~");
                Console.WriteLine("\t\t\t\t\t|  [1] Show All              |");
                Console.WriteLine("\t\t\t\t\t|  [2] Show Electric         |");
                Console.WriteLine("\t\t\t\t\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                   Console.Write("\t\t\t\t\tInput: ");
        }

    }
}
