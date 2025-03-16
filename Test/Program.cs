using System;
using Microsoft.Data.SqlClient;
using ConsoleMenu_;
using LibraryBasicInfo;

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
                int CurrentDay = 0, CurrentMonth = 0, CurrentYear = 0;
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
                Console_Design.Birthday();
                Year = int.Parse(Console.ReadLine() ?? "0");
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
                Console_Design.date();
                CurrentYear = int.Parse(Console.ReadLine() ?? "0");
                do
                {
                    Console.Write("Day: ");
                    CurrentDay = int.Parse(Console.ReadLine() ?? "0");
                } while (Day < 1 || Day > 31);
                do
                {
                    Console.Clear();
                    Console_Design.Month();
                    CurrentMonth = int.Parse(Console.ReadLine() ?? "0");
                } while (Month < 1 || Month > 12);
                //--------------------------------------------------------------------------------------------------------------------
                Console.Clear();
                Console.WriteLine("+----------------------------------------------------+");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("|                 Welcome to SEULGI                  |");
                Console.WriteLine("|    Please Fill Out Your Information as Requested   |");
                Console.WriteLine("|                                                    |");
                Console.WriteLine("+----------------------------------------------------+\n");
                Console.WriteLine($"   Name: {info.LastName}, {info.FirstName} {info.MiddleInitial}.   ");

                if (Month >= 10 && Month <= 12)
                {
                    Console.WriteLine($"   Birthday: {Month}/{Day}/{Year}   Age: {BasicInfo.AgeCalculation(CurrentDay, CurrentMonth, CurrentYear, Age, Month, Year, Day)}         ");
                }
                else
                {
                    Console.WriteLine($"   Birthday: 0{Month}/{Day}/{Year}   Age: {BasicInfo.AgeCalculation(CurrentDay, CurrentMonth, CurrentYear, Age, Month, Year, Day)}         ");
                }
                Console.WriteLine("                                                    ");
                Console.WriteLine($"   Adress: {info.HouseNumber}, {info.Street}, {info.Barangay}, {info.City}, {info.Country}                      \n\n");
                Console.WriteLine($"                  Surname Signature: {info.LastName} \n");
                Console.WriteLine("+----------------------------------------------------+\n\n");
                // --------------------------------------------------------------------------------------------------------------------
                DateTime _bday = new DateTime(Year, Month, Day);
                DateTime _rdate = new DateTime(CurrentYear, CurrentMonth, CurrentDay);
                DateTime _cdate = DateTime.Now;
                Console.WriteLine("Do you want to save this data? (Y)");
                ConsoleKeyInfo Save = new ConsoleKeyInfo();
                ConsoleKeyInfo See = new ConsoleKeyInfo();
                ConsoleKeyInfo Delete = new ConsoleKeyInfo();
                ConsoleKeyInfo _tryagain = new ConsoleKeyInfo();
                Save = Console.ReadKey();
                if (Save.KeyChar == 'y' || Save.Key == ConsoleKey.Y)
                {
                string connectionString = "Server=localhost\\sqlexpress;Database=seulgi;Integrated Security=True;TrustServerCertificate=True;";


                using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string insert = "INSERT INTO info (FirstName, LastName, MiddleName, Registration_Date, Birthday, Age, Country, City, Barangay, Street, HouseNumber ) VALUES (@FirstName, @LastName, @MiddleName, @Registration_Date, @Birthday, @Age, @Country, @City, @Barangay, @Street, @HouseNumber)";

                        using (SqlCommand command = new SqlCommand(insert, connection))
                        {
                            command.Parameters.AddWithValue("@FirstName", info.FirstName);
                            command.Parameters.AddWithValue("@MiddleName", info.MiddleName);
                            command.Parameters.AddWithValue("@LastName", info.LastName);
                            command.Parameters.AddWithValue("@Registration_Date", _cdate);
                            command.Parameters.AddWithValue("@Birthday", _bday);
                            command.Parameters.AddWithValue("@Age", BasicInfo.AgeCalculation(CurrentDay, CurrentMonth, CurrentYear, Age, Month, Year, Day));
                            command.Parameters.AddWithValue("@Country", info.Country);
                            command.Parameters.AddWithValue("@City", info.City);
                            command.Parameters.AddWithValue("@Barangay", info.Barangay);
                            command.Parameters.AddWithValue("@Street", info.Street);
                            command.Parameters.AddWithValue("@HouseNumber", info.HouseNumber);

                            command.ExecuteNonQuery();
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Data saved successfully\n\n");
                    Console.WriteLine("Do you want to see the data? (Y)");
                    See = Console.ReadKey();
                if (See.Key == ConsoleKey.Y || See.KeyChar == 'y')
                {
                    Console.Clear();
                    string select = "SELECT * FROM info";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(select, connection))
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("ID\tFirstName\tLastName\tMiddleName\tRegDate\t\tBirthday\tAge\tCountry\tCity\tBarangay\tStreet\tHouseNumber");
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

                            //read row data~
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["ID"]}\t{reader["FirstName"]}\t{reader["LastName"]}\t{reader["MiddleName"]}\t{reader["Registration_Date"]}\t{reader["Birthday"]}\t{reader["Age"]}\t{reader["Country"]}\t{reader["City"]}\t{reader["Barangay"]}\t{reader["Street"]}\t{reader["HouseNumber"],-5}");
                            }
                        }
                    }
                }
                        Console.WriteLine("\n\nDo you want to delete the data? (Y)");
                        Delete = Console.ReadKey();
                        if (Delete.Key == ConsoleKey.Y || Delete.KeyChar == 'y')
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the ID of the data you want to delete: ");
                            int ID = int.Parse(Console.ReadLine() ?? "0");
                            string delete = "DELETE FROM info WHERE ID = @ID";
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                using (SqlCommand command = new SqlCommand(delete, connection))
                                {
                                    command.Parameters.AddWithValue("@ID", ID);
                                    command.ExecuteNonQuery();
                                }
                            }
                            Console.Clear();
                            Console.WriteLine("Data deleted successfully\n\n");
                        Console.WriteLine("~~           Press Anything To Proceed              ~~");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Data not saved\n\n");
                Console.WriteLine("~~           Press Anything To Proceed              ~~");
                Console.ReadKey();
            }
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
