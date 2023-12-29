using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    internal class Utils
    {
        // bool canNoné dùng cho phần Update All Fields, Nếu canNone = true thì các field nhập vào có thể trống 

        // Overloading for integer datatype
        public static void InputData(out int data, string attribute, int upperBoundary, int lowerBoundary, bool canNone)
        {
            Console.Write("\tEnter " + attribute + " : ");
            while (true)
            {
                string dataString = Console.ReadLine()!;
                if (canNone && string.IsNullOrEmpty(dataString))
                {
                    data = lowerBoundary - 1;
                    break;
                }
                if (!int.TryParse(dataString, out data) || data < lowerBoundary || data > upperBoundary)
                {
                    Console.Write("\t" + attribute + $" must be integer number from {lowerBoundary} to {upperBoundary}, retry : ");
                }
                else break;
            };
        }

        //Overloading for float datatype
        public static void InputData(out float data, string attribute, float upperBoundary, float lowerBoundary, bool canNone)
        {
            Console.Write("\tEnter " + attribute + " : ");
            do
            {
                string dataString = Console.ReadLine()!.Replace(',', '.');
                if (canNone && string.IsNullOrEmpty(dataString))
                {
                    data = lowerBoundary - 1;
                    break;
                }
                if (!float.TryParse(dataString, out data) || data < lowerBoundary || data > upperBoundary)
                    Console.Write("\t" + attribute + $" must be float number from {lowerBoundary} to {upperBoundary}, retry : ");
                else break;
            } while (true);
        }

        //Overloading for string datatype
        public static void InputData(out string data, string attribute, int boundary, bool canNone)
        {
            Console.Write("\tEnter " + attribute + " : ");
            while (true)
            {
                data = Console.ReadLine()!;
                if (canNone && string.IsNullOrEmpty(data)) break;
                data = data.Trim();
                if (string.IsNullOrWhiteSpace(data))
                    Console.Write("\t" + attribute + " must not be null or white space, retry : ");
                else if (data.Length > boundary)
                    Console.Write("\tNumber of characters of " + attribute + " must be less than " + boundary + ", retry : ");
                else break;
            };
        }

        //Overloading for DateTime datatype
        public static void InputData(out DateTime date, string attribute, DateTime upperBoundary, DateTime lowerBoundary, bool canNone)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            Console.Write($"\tEnter {attribute} after from {Constant.BirthDateFormat} : ");
            while (true)
            {
                string? dateString = Console.ReadLine();
                if (canNone && string.IsNullOrEmpty(dateString))
                {
                    date = new();
                    break;
                }
                bool isCorrectFormat = DateTime.TryParseExact(dateString, Constant.BirthDateFormat, provider, DateTimeStyles.None, out date);
                if (!isCorrectFormat)
                    Console.Write($"\t{attribute} + must be valid date and in format {Constant.BirthDateFormat}, try again : ");
                else if (date.CompareTo(upperBoundary) > 0 || date.CompareTo(lowerBoundary) < 0)
                    Console.Write("\t" + attribute + " must be after " + lowerBoundary.Day + " - " + lowerBoundary.Month + " - " + lowerBoundary.Year + " and before " + upperBoundary.Day + " - " + upperBoundary.Month + " - " + upperBoundary.Year + ", retry : ");
                else break;
            };

        }

        //Overloading for Code especially
        public static void InputData(out string data, string attribute, int boundary, List<Student> students, bool canNone)
        {
            Console.Write("\tEnter " + attribute + " : ");
            while (true)
            {
                data = Console.ReadLine()!;
                if (canNone && string.IsNullOrEmpty(data)) break;
                data = data.Replace(" ", "");

                if (data.Length != boundary)
                {
                    Console.Write("\t" + attribute + " must have exactly " + boundary + " characters (skip whitespaces), retry : ");
                    continue;
                }
                if (!CheckStringHasOnlyLetterOrDigit(data))
                {
                    Console.Write("\t" + attribute + " must have only letter or digit, retry : ");
                    continue;
                }
                string dataString = data;
                bool isDuplicate = students.Any(s => s.Code.ToLower().Equals(dataString.ToLower()));
                if (isDuplicate)
                    Console.Write("\t" + attribute + " is duplicate, retry : ");
                else break;
            }
        }

        //Overloading for inputting positive integer number 
        public static void InputData(out int id, string attribute)
        {
            Console.Write(" +) Enter " + attribute + " : ");
            do
            {
                string idString = Console.ReadLine()!;
                if (!int.TryParse(idString, out id) || id <= 0)
                    Console.Write(" !) " + attribute + " must be positive integer number, retry : ");
                else break;
            } while (true);
        }

        public static Student? FindStudent(int id, List<Student> students)
        {
            Student? student = students.FirstOrDefault(s => s.Id == id);
            if(student == null)
            {
                Console.WriteLine("\t!) There is no student has Id = " + id);
            }
            return student;
        }

        public static AcademicPerformance AssignAcademicAbility(float score)
        {
            return score switch
            {
                >= 9 => AcademicPerformance.Excellent,
                >= 7.5f => AcademicPerformance.VeryGood,
                >= 6.5f => AcademicPerformance.Good,
                >= 5 => AcademicPerformance.Average,
                >= 3 => AcademicPerformance.BelowAverage,
                _ => AcademicPerformance.Weak,
            };
        }

        public static bool CheckStringHasOnlyLetterOrDigit(string str)
        {
            foreach (char s in str)
            {
                if (!char.IsLetterOrDigit(s))
                {
                    return false;
                }
            }
            return true;
        }

        public static Student UpdateOrCreate(List<Student> students, bool isUpdatingMode)
        {
            InputData(out string name, "Name", Constant.MaxNameCharacters, isUpdatingMode);
            InputData(out DateTime birthday, "Date of birth", DateTime.Now, new DateTime(Constant.MinYearOfBirthdate, Constant.MinMonthOfBirthdate, Constant.MinDayOfBirthdate), isUpdatingMode);
            InputData(out string address, "Address", Constant.MaxAddressCharacters, isUpdatingMode);
            InputData(out float height, "Height", Constant.MaxHeight, Constant.MinHeight, isUpdatingMode);
            InputData(out float weight, "Weight", Constant.MaxWeight, Constant.MinWeight, isUpdatingMode);
            InputData(out string code, "Code", Constant.StudentCode, students, isUpdatingMode);
            InputData(out string university, "University", Constant.MaxUniversityNameCharacters, isUpdatingMode);
            InputData(out int admissionYear, "Admission Year", DateTime.Now.Year, Constant.MinAdmissionYear, isUpdatingMode);
            InputData(out float CPA, "CPA", Constant.MaxCPA, Constant.MinCPA, isUpdatingMode);
            if (!isUpdatingMode) Person.indexId = students.Max(s => s.Id);
            return new(name, birthday, address, height, weight, code, university, admissionYear, CPA);
        }
    }
}


