using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StudentManagement
{
    internal class Functionality
    {
        public static void Create(List<Student> students)
        {
            Console.WriteLine("\t\t\tEnter information of student for creating : ");
            Student student = Utils.UpdateOrCreate(students, false);
            students.Add(student);
            Console.WriteLine("\t  => Create successfully, information of student that has just been added : ");
            Console.WriteLine(student.ToString());
        }

        public static void Read(List<Student> students)
        {
            Utils.InputData(out int id, "Id Of Student To Read");
            Student? student = Utils.FindStudent(id, students);
            if (student == null) return;
            Console.WriteLine("  => Read successfully, student has Id = " + id + " : ");
            Console.WriteLine(student?.ToString());
        }

        public static void UpdateAllFields(List<Student> students)
        {
            Utils.InputData(out int id, "Id Of Student To Update");
            Student? student = Utils.FindStudent(id, students);
            if (student == null) return;
            Console.WriteLine("\t\t+) Information of student to update : ");
            Console.WriteLine(student.ToString());
            Console.WriteLine("\t+) Please input information to update, type \"enter\" for attribute that you do not want to update : ");

            Student updatedStudent = Utils.UpdateOrCreate(students, true); 

            student.Name = string.IsNullOrWhiteSpace(updatedStudent.Name) ? student.Name : updatedStudent.Name;
            student.Birthdate = updatedStudent.Birthdate == new DateTime() ? student.Birthdate : updatedStudent.Birthdate;
            student.Address = string.IsNullOrWhiteSpace(updatedStudent.Address) ? student.Address : updatedStudent.Address;
            student.Height = updatedStudent.Height < Constant.MinHeight ? student.Height : updatedStudent.Height; // canNone = true nên giá trị height được gán là MinHeight - 1 , sẽ nhỏ hơn MinHeight nên giá trị giữ nguyên
            student.Weight = updatedStudent.Weight < Constant.MinWeight ? student.Weight : updatedStudent.Weight;
            student.Code = string.IsNullOrWhiteSpace(updatedStudent.Code) ? student.Code : updatedStudent.Code;
            student.University = string.IsNullOrWhiteSpace(updatedStudent.University) ? student.University : updatedStudent.University;
            student.AdmissionYear = updatedStudent.AdmissionYear < Constant.MinAdmissionYear ? student.AdmissionYear : updatedStudent.AdmissionYear;
            student.CPA = updatedStudent.CPA < Constant.MinCPA ? student.CPA : updatedStudent.CPA;
            student.AcademicAbility = Utils.AssignAcademicAbility(student.CPA);
            Console.WriteLine("  => Update successfully, information of student after being updated : ");
            Console.WriteLine(student.ToString());
        }

        public static void UpdateEachField(List<Student> students)
        {
            Utils.InputData(out int id, "Id Of Student To Update");

            Student? student = Utils.FindStudent(id, students);
            if (student == null) return;
            Console.WriteLine("\t\t+) Information of student to update : ");
            Console.WriteLine(student.ToString());
            Menu.FieldMenu();
            Utils.InputData(out int choice, "Field", 9, 0, false);
            switch (choice)
            {
                case 1:
                    Utils.InputData(out string name, "Name", Constant.MaxNameCharacters, false);
                    student.Name = name;
                    break;
                case 2:
                    Utils.InputData(out DateTime birthday, "Date of birth", DateTime.Now, new DateTime(Constant.MinYearOfBirthdate, Constant.MinMonthOfBirthdate, Constant.MinDayOfBirthdate), false);
                    student.Birthdate = birthday;
                    break;
                case 3:
                    Utils.InputData(out string address, "Address", Constant.MaxAddressCharacters, false);
                    student.Address = address;
                    break;
                case 4:
                    Utils.InputData(out float height, "Height", Constant.MaxHeight, Constant.MinHeight, false);
                    student.Height = height;
                    break;
                case 5:
                    Utils.InputData(out float weight, "Weight", Constant.MaxWeight, Constant.MinWeight, false);
                    student.Weight = weight;
                    break;
                case 6:
                    Utils.InputData(out string code, "Code", Constant.StudentCode, students, false);
                    student.Code = code;
                    break;
                case 7:
                    Utils.InputData(out string university, "University", Constant.MaxUniversityNameCharacters, false);
                    student.University = university!;
                    break;
                case 8:
                    Utils.InputData(out int admissionYear, "Admission Year", DateTime.Now.Year, Constant.MinAdmissionYear, false);
                    student.AdmissionYear = admissionYear;
                    break;
                case 9:
                    Utils.InputData(out float CPA, "Cumulate Grade Point Average", Constant.MaxCPA, Constant.MinCPA, false);
                    student.CPA = CPA;
                    break;
                case 0:
                    return;
            }
            Console.WriteLine("  => Update successfully, information of student after being updated : ");
            Console.WriteLine(student.ToString());


        }

        public static void Delete(List<Student> students)
        {
            Utils.InputData(out int id, "Id of student to delete");
            Student? student = Utils.FindStudent(id, students);
            if (student == null) return;
            students.Remove(student);
            Console.WriteLine("  => Delete successfully student has Id = " + id);
        }

        public static void ShowAcademicPerformanceDescending(List<Student> students)
        {
            Console.WriteLine("\t  => Academic Performance are sorted by percentage of student to descending order : ");
            var groupedStudent = students.GroupBy(x => x.AcademicAbility).OrderByDescending(group => group.Count()); ;
            foreach (var student in groupedStudent)
            {
                Console.WriteLine("\t\t\t\t|  {0,-15} | {1,10}  |", student.Key, Math.Round((float)student.Count() * 100 / students.Count, 3) + " %");
            }
        }

        public static void ShowAverageScoreDescending(List<Student> students)
        {
            Console.WriteLine("\t  => CPA are sorted by percentage of student to descending order : ");
            var groupedStudents = students.GroupBy(student => student.CPA).OrderByDescending(group => group.Count());
            foreach (var student in groupedStudents)
            {
                Console.WriteLine("\t\t\t\t|  {0,-8} | {1,8}  |", Math.Round(student.Key, 2), Math.Round((float)student.Count() / students.Count * 100, 3) + " %");
            }
        }

        public static void ShowStudentInfoByAcademicPerformance(List<Student> students)
        {
            Menu.AcademicPerformanceMenu();
            Utils.InputData(out int academicPerformance, "Academic Performance", 6, 0, false);
            if (academicPerformance == 0) return;
            AcademicPerformance academicAbility = (AcademicPerformance)academicPerformance;
            var st = students.FindAll(student => student.AcademicAbility == academicAbility);
            if (!st.Any())
            {
                Console.WriteLine("\t  * There is no student has " + academicAbility + " performance");
                return;
            }
            Console.WriteLine("\t  => List of student has " + academicAbility + " performance : ");
            foreach (Student s in st)
            {
                Console.WriteLine("\t    ----------------------------");
                Console.WriteLine(s.ToString());
            }
        }

    }
}
