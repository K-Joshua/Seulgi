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


        public static int AgeCalculation(int current_day, int current_month, int current_year, int age_year, int Month, int Year, int Day)
        {
            age_year = current_year - Year;

            if (Month > current_month || (Month == current_month && Day > current_day))
            {
                age_year--;
            }

            return age_year;
        }
    }
}
