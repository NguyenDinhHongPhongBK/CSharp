using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class Constant
    {
        public const int MaxNameCharacters = 100;
        public const int MinYearOfBirthdate = 1900;
        public const int MinMonthOfBirthdate = 1;
        public const int MinDayOfBirthdate = 1;
        public const string BirthDateFormat = "dd/MM/yyyy";
        public const int MaxAddressCharacters = 300;
        public const float MinHeight = 50.0f;
        public const float MaxHeight = 300.0f;
        public const float MinWeight = 5.0f;
        public const float MaxWeight = 1000.0f;
        public const int StudentCode = 10;
        public const int MaxUniversityNameCharacters = 200;
        public const int MinAdmissionYear = 1900;
        public const float MinCPA = 0.0f;
        public const float MaxCPA = 10.0f;
        public const string Filename = "students.json";
    }
}
