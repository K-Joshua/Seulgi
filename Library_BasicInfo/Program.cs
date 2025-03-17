using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBasicInfo
{
    public class BasicInfo
    {
        private string _firstname { get; set; } = "Unknown";
        private string _lastname { get; set; } = "Unknown";
        private string _country { get; set; } = "Unknown";
        private string _city { get; set; } = "Unknown";
        private string _street { get; set; } = "Unknown";
        private string _barangay { get; set; } = "Unknown";


        private char? _middleInitial { get; set; }
        private string? _wholeMid { get; set; }
        public string FirstName { 
            get => _firstname; 
            set => _firstname = value; 
        } 
        public string? LastName {
            get => _lastname;
            set => _lastname = value;
        }

        public string? MiddleName
        {
            get => _wholeMid;
            set
            {   
                _wholeMid = value;
                _middleInitial = !string.IsNullOrEmpty(value) ? value[0] : null;
            }
        }

        public char? MiddleInitial
        {
            get => _middleInitial;
        }

        public string Country
        {
            get => _country;
            set => _country = value;
        }

        public string City
        {
            get => _city;
            set => _city = value;
        }

        public string Street
        {
            get => _street;
            set => _street = value;
        }

        public string Barangay
        {
            get => _barangay;
            set => _barangay = value;
        }
        public int HouseNumber { get; set; }

        public static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
        //Is it divisible by 4? and it should NOT divisible by 100, 
        //unless it is also divisible by 400 
        public static int AgeCalculation(int current_day, int current_month, int current_year, int Month, int Year, int Day)
        {
            int age_year = current_year - Year;

            if (Month > current_month || (Month == current_month && Day > current_day))
            {
                age_year--;
            }

            switch (Month)
            {
                case 1: Console.WriteLine($"   Your Birthday is in January {Day}, {Year}      Age: {age_year}"); break;
                case 2: Console.WriteLine($"   Your Birthday is in February {Day}, {Year}      Age: {age_year}"); break;
                case 3: Console.WriteLine($"   Your Birthday is in March {Day}, {Year}      Age: {age_year}"); break;
                case 4: Console.WriteLine($"   Your Birthday is in April {Day}, {Year}      Age: {age_year}"); break;
                case 5: Console.WriteLine($"   Your Birthday is in May {Day}, {Year}      Age: {age_year}"); break;
                case 6: Console.WriteLine($"   Your Birthday is in June {Day}, {Year}      Age: {age_year}"); break;
                case 7: Console.WriteLine($"   Your Birthday is in July {Day}, {Year}      Age: {age_year}"); break;
                case 8: Console.WriteLine($"   Your Birthday is in August {Day}, {Year}      Age: {age_year}"); break;
                case 9: Console.WriteLine($"   Your Birthday is in September {Day}, {Year}      Age: {age_year}"); break;
                case 10: Console.WriteLine($"   Your Birthday is in October {Day}, {Year}      Age: {age_year}"); break;
                case 11: Console.WriteLine($"   Your Birthday is in November {Day}, {Year}      Age: {age_year}"); break;
                case 12: Console.WriteLine($"   Your Birthday is in December {Day}, {Year}      Age: {age_year}"); break;
                default:
                    Console.WriteLine("Invalid month entered.");
                    return 0;
            }

            return age_year;
        }


    }
}
/*
 using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library
{
    public static class Class1
    {
        public static void AgeCalculation(int current_day, int current_month, int current_year, int age_year, int Month, int Year, int Day)
        {
             age_year = current_year - Year;

            if (Month > current_month || (Month == current_month && Day > current_day))
            {
                age_year--;
            }

            switch (Month)
            {
                case 1:
                    if (current_month < Month)
                    {
                        age_year = current_year - Year;
                    }
                    else if (current_day >= Day)
                    {
                        age_year = current_year - Year;
                        age_year = current_year - 1;
                    }
                    else
                    {
                        age_year = current_year - Year;
                    }
                    Console.WriteLine($"Your Birthday is in January {Day} {Year}");
                    Console.WriteLine($"Your Age is: {age_year}");
                    break;

                case 2:
                    if (current_month < Month)
                    {
                        age_year = current_year - Year;
                    }
                    else if (current_day >= Day)
                    {
                        age_year = current_year - Year;
                        age_year = current_year - 1;
                    }
                    else
                    {
                        age_year = current_year - Year;
                    }
                    Console.WriteLine($"Your Birthday is in February {Day} {Year}");
                    Console.WriteLine($"Your Age is: {age_year}");
                    break;

                case 3:
                    Console.WriteLine($"Your Birthday is in March {Day} {Year}");
                    Console.WriteLine($"Your Age is: {age_year}");
                    break;

                case 4:
                    Console.WriteLine($"Your Birthday is in April {Day} {Year}");
                    Console.WriteLine($"Your Age is: {age_year}");
                    break;

                case 5:
                    Console.WriteLine($"Your Birthday is in May {Day} {Year}");
                    Console.WriteLine($"Your Age is: {age_year}");
                    break;

                case 6:
                    Console.WriteLine($"Your Birthday is in June {Day} {Year}");
                    Console.WriteLine($"Your Age is: {age_year}");
                    break;

                case 7:
                    Console.WriteLine($"Your Birthday is in July {Day} {Year}");
                    Console.WriteLine($"Your Age is: {age_year}");
                    break;

                case 8:
                    Console.WriteLine($"Your Birthday is in August {Day} {Year}");
                    Console.WriteLine($"Your Age is: {age_year}");
                    break;

                case 9:
                    Console.WriteLine($"Your Birthday is in September {Day} {Year}");
                    Console.WriteLine($"Your Age is: {age_year}");
                    break;

                case 10:
                    Console.WriteLine($"Your Birthday is in October {Day} {Year}");
                    Console.WriteLine($"Your Age is: {age_year}");
                    break;

                case 11:
                    Console.WriteLine($"Your Birthday is in November {Day} {Year}");
                    Console.WriteLine($"Your Age is: {age_year}");
                    break;

                case 12:
                    Console.WriteLine($"Your Birthday is in December {Day} {Year}");
                    Console.WriteLine($"Your Age is: {age_year}");
                    break;

                default:
                    Console.WriteLine("Invalid month entered.");
                    break;
            }
        }
    }
}
 */


