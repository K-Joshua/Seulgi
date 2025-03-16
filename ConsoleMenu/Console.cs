using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu_
{
    public class Console_Design
    {
        public static void Main_Menu ()
        {
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|                 Welcome to SEULGI                  |");
            Console.WriteLine("|    Please Fill Out Your Information as Requested   |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|   Name _________________________________________   |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|   Birthday __________________  Age _______         |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|   Adress _____________________                     |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|                  Surname Signature: ______________ |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("+----------------------------------------------------+\n\n");
        }

        public static void Name()
        {
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|              Please Input Your Name                |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("+----------------------------------------------------+");
        }

        public static void Birthday()
        {
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|             Please Input Your Birthday             |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("+----------------------------------------------------+");
            Console.Write("Year: ");
        }

        public static void date()
        {
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|           Please Input Your Current Date           |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("+----------------------------------------------------+");
            Console.Write("Year: ");
        }

        public static void Month()
        {
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|         Please Input Number Between 1 - 12         |");
            Console.WriteLine("|                   For Your Month                   |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|   1. January                                       |");
            Console.WriteLine("|   2. Febuary                                       |");
            Console.WriteLine("|   3. March                                         |");
            Console.WriteLine("|   4. Apri                                          |");
            Console.WriteLine("|   5. May                                           |");
            Console.WriteLine("|   6. June                                          |");
            Console.WriteLine("|   7. July                                          |");
            Console.WriteLine("|   8. August                                        |");
            Console.WriteLine("|   9. September                                     |");
            Console.WriteLine("|   10. October                                      |");
            Console.WriteLine("|   11. November                                     |");
            Console.WriteLine("|   12. December                                     |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("+----------------------------------------------------+");
            Console.Write("Month: ");
        }


        public static void Adress()
        {
            Console.WriteLine("+----------------------------------------------------+");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|             Please Input Your Adress               |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("+----------------------------------------------------+");
            Console.Write("Country: ");
        }
        //country
        //City
        //Barangay
        //Street
        //House Number
    }
}
