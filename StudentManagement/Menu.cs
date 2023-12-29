using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    internal class Menu
    {
        public static void MainMenu()
        {
            Console.WriteLine("\t\t\t+------------------------------------------MENU--------------------------------------------+");
            Console.WriteLine("\t\t\t|  1 : Create Students                                                                     |");
            Console.WriteLine("\t\t\t|  2 : Read Student                                                                        |");
            Console.WriteLine("\t\t\t|  3 : Update each field of Student                                                        |");
            Console.WriteLine("\t\t\t|  4 : Update all fields of Student                                                        |");
            Console.WriteLine("\t\t\t|  5 : Delete Student                                                                      |");
            Console.WriteLine("\t\t\t|  6 : Show rate of students divided by academic performance, listed by descending order   |");
            Console.WriteLine("\t\t\t|  7 : Show rate of students divided by CPA, listed by descending order                    |");
            Console.WriteLine("\t\t\t|  8 : Show students information when academic performance is given                        |");
            Console.WriteLine("\t\t\t|  0 : Exit and Save                                                                       |");
            Console.WriteLine("\t\t\t+------------------------------------------------------------------------------------------+");
        }

        public static void UpdatingMenu()
        {
            Console.WriteLine("\t\t\t+----------------------------------+");
            Console.WriteLine("\t\t\t|  1 : Update field by field       |");
            Console.WriteLine("\t\t\t|  2 : Update all fields           |");
            Console.WriteLine("\t\t\t|  0 : Exit                        |");
            Console.WriteLine("\t\t\t+----------------------------------+");
        }

        public static void FieldMenu()
        {
            Console.WriteLine("\t\t\t+---------------------------------------------------------------------------------+");
            Console.WriteLine("\t\t\t|  1 : Name       2 : Birthdate       3 : Address         4 : Height              |");
            Console.WriteLine("\t\t\t|  5 : Weight     6 : Code            7 : University      8 : Admission Year      |");
            Console.WriteLine("\t\t\t|  9 : CPA        0 : Exit                                                        |");
            Console.WriteLine("\t\t\t+---------------------------------------------------------------------------------+");
        }

        public static void AcademicPerformanceMenu()
        {
            Console.WriteLine("\t\t\t+--------------------------+");
            Console.WriteLine("\t\t\t|  1 : Excellent           |");
            Console.WriteLine("\t\t\t|  2 : Very Good           |");
            Console.WriteLine("\t\t\t|  3 : Good                |");
            Console.WriteLine("\t\t\t|  4 : Average             |");
            Console.WriteLine("\t\t\t|  5 : Bellow Average      |");
            Console.WriteLine("\t\t\t|  6 : Weak                |");
            Console.WriteLine("\t\t\t|  0 : Exit                |");
            Console.WriteLine("\t\t\t+--------------------------+");
        }
    }
}
