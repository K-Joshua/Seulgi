using System;
using Microsoft.Data.SqlClient;
using ConsoleMenu_;
using LibraryBasicInfo;
using LinqUsingDbContext;

class Program
{   
    public static void Main(string [] args)
    {
        bool TryAgain = false;
        BasicInfo info = new BasicInfo();
        while (!TryAgain)
        {
            try
            {
                int Day = 0, Month = 0, Year = 0;
                int Age = 0;
                Console.Clear();
                //--------------------------------------------------------------------------------------------------------------------
                Console_Design.Main_Menu();
                Console.WriteLine("~~           Press Anything To Start              ~~");
                Console.ReadKey();
                Console.Clear();
                //--------------------------------------------------------------------------------------------------------------------
                Console_Design.Name();
                Console.Write("First Name: ");
                info.FirstName = Console.ReadLine();
                Console.Write("Middle Name: ");
                info.MiddleName = Console.ReadLine();
                Console.Write("Last Name: ");
                info.LastName = Console.ReadLine();
                Console.Clear();
                //--------------------------------------------------------------------------------------------------------------------
                while (!TryAgain)
                {
                    Console.Clear();
                    do
                    {
                        Console_Design.Birthday();
                        Year = int.Parse(Console.ReadLine() ?? "0");
                    } while (Year < 1850 || Year > 2025);
                    do
                    {
                        Console.Write("Day: ");
                        Day = int.Parse(Console.ReadLine() ?? "0");
                    } while (Day < 1 || Day > 31);
                    Console.Clear();
                    do
                    {
                        Console.Clear();
                        Console_Design.Month();
                        Month = int.Parse(Console.ReadLine() ?? "0");
                    } while (Month < 1 || Month > 12);
                    if (Month == 2 && BasicInfo.IsLeapYear(Year) && Day > 29)
                    {
                        Console.WriteLine("\n\nYour February is A Leap Year, Limit 29, Try Again");
                        Console.ReadKey();
                    }
                    else if (Month == 2 && !BasicInfo.IsLeapYear(Year) && Day >28)
                    {
                        Console.WriteLine("\n\nError, February Only Has 28 days 'IF NOT LEAP YEAR' Try Again ");
                        Console.ReadKey();
                    }
                    else { break; }
                }
                //--------------------------------------------------------------------------------------------------------------------
                Console.Clear();
                Console_Design.Adress();
                info.Country = Console.ReadLine();
                Console.Write("City: ");
                info.City = Console.ReadLine();
                Console.Write("Barangay: ");
                info.Barangay = Console.ReadLine();
                Console.Write("Street: ");
                info.Street = Console.ReadLine();
                Console.Write("House Number: ");
                info.HouseNumber = int.Parse(Console.ReadLine() ?? "0");
                Console.Clear();
                //--------------------------------------------------------------------------------------------------------------------
                DateTime _cdate = DateTime.Now;

                int CurrentYear = _cdate.Year;
                int CurrentMonth = _cdate.Month; // Adds leading zero if needed
                int CurrentDay = _cdate.Day;

                //--------------------------------------------------------------------------------------------------------------------
                Console.Clear();
                Console.WriteLine("+----------------------------------------------------+");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|                 Welcome to SEULGI                  |");
                Console.WriteLine("|    Please Fill Out Your Information as Requested   |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("+----------------------------------------------------+\n");
                Console.WriteLine($"   Name: {info.LastName}, {info.FirstName} {info.MiddleInitial}.   ");
                info.age = BasicInfo.AgeCalculation(CurrentDay, CurrentMonth, CurrentYear, Month, Year, Day);
                Console.WriteLine("                                                    ");
                Console.WriteLine($"   Adress: {info.HouseNumber}, {info.Street}, {info.Barangay}, {info.City}, {info.Country}                      \n\n");
                Console.WriteLine($"                  Surname Signature: {info.LastName} \n");
                Console.WriteLine("+----------------------------------------------------+\n\n");
                // --------------------------------------------------------------------------------------------------------------------
                DateTime _bday = new DateTime(Year, Month, Day);
                DateTime _rdate = new DateTime(CurrentYear, CurrentMonth, CurrentDay);
                info.Birthday = _bday;
                info.Registration_Date = _rdate;
                // --------------------------------------------------------------------------------------------------------------------
                Console.WriteLine("Do you want to save this data? (Y)");
                ConsoleKeyInfo Save = new ConsoleKeyInfo();
                ConsoleKeyInfo See = new ConsoleKeyInfo();
                ConsoleKeyInfo Delete = new ConsoleKeyInfo();
                    Save = Console.ReadKey();
                    if (Save.KeyChar == 'y' || Save.Key == ConsoleKey.Y)
                    {
                        using (var context = new AppDbContext())
                        {
                            context.Info.Add(info);
                            context.SaveChanges();
                        }

                        Console.WriteLine("\nData saved successfully!");
                    }

                Console.WriteLine("\nSee all data? (Y/N): ");
                var seeKey = Console.ReadKey();
                Console.WriteLine();

                if (seeKey.Key == ConsoleKey.Y || seeKey.KeyChar == 'y')
                {
                    Console.Clear();
                    using (var context = new AppDbContext())
                    {
                        var allData = context.Info.ToList();

                        Console.WriteLine("ID\tFirst\tLast\tMiddle\tRegDate\t\tBirthday\tAge\tCountry\tCity\tBarangay\tStreet\tHouse#");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------");

                        foreach (var item in allData)
                        {
                            Console.WriteLine($"{item.ID}\t{item.FirstName}\t{item.LastName}\t{item.MiddleName}\t{item.Registration_Date:yyyy-MM-dd}\t{item.Birthday:yyyy-MM-dd}\t{item.age}\t{item.Country}\t{item.City}\t{item.Barangay}\t{item.Street}\t{item.HouseNumber}");
                        }
                    }
                }

                Console.WriteLine("\nDelete a record? (Y/N): ");
                var deleteKey = Console.ReadKey();
                Console.WriteLine();

                if (deleteKey.Key == ConsoleKey.Y || deleteKey.KeyChar == 'y')
                {
                    Console.Write("Enter ID to delete: ");
                    int id = int.Parse(Console.ReadLine());

                    using (var context = new AppDbContext())
                    {
                        var record = context.Info.FirstOrDefault(x => x.ID == id);
                        if (record != null)
                        {
                            context.Info.Remove(record);
                            context.SaveChanges();
                            Console.WriteLine("Data deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Record not found.");
                        }
                    }
                }

                Console.WriteLine("\n~~ Press any key to continue ~~");
                Console.ReadKey();

                ConsoleKeyInfo _tryagain = new ConsoleKeyInfo();

                Console.Clear();
                Console.WriteLine("Do you want to try again? (N)");
                _tryagain = Console.ReadKey();
                if (_tryagain.Key == ConsoleKey.N || _tryagain.KeyChar == 'n')
                {
                    TryAgain = true;
                }
                Console.Clear();
                Console.WriteLine("~~           Thank You Come Again              ~~");
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Do you want to try again? (N)");
                ConsoleKeyInfo _tryagain = new ConsoleKeyInfo();
                _tryagain = Console.ReadKey();
                if (_tryagain.Key == ConsoleKey.N || _tryagain.KeyChar == 'n')
                {
                    TryAgain = true;
                }
                Console.Clear();
                Console.WriteLine("~~           Thank You Come Again              ~~");
            }
        }
    }
}