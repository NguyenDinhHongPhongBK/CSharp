using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public static class Program
    {
        private static int Main()
        {
            List<Student> students;
            int choice;
            students = FileManipulation.ReadJsonFile(Constant.Filename);
            if(!students.Any())
            {
                Console.WriteLine("\t\t!) Can not read "+Constant.Filename);
                return 0;
            }
            
            do
            {
                Menu.MainMenu();
                Utils.InputData(out choice, "Function", 8, 0, false);
                switch (choice)
                {
                    case 0:
                        FileManipulation.SaveJsonFile(students, Constant.Filename);
                        break;
                    case 1:
                        Functionality.Create(students);
                        break;
                    case 2:
                        Functionality.Read(students);
                        break;
                    case 3:
                        Functionality.UpdateEachField(students);
                        break;
                    case 4:
                        Functionality.UpdateAllFields(students);
                        break;
                    case 5:
                        Functionality.Delete(students);
                        break;
                    case 6:
                        Functionality.ShowAcademicPerformanceDescending(students);
                        break;
                    case 7:
                        Functionality.ShowAverageScoreDescending(students);
                        break;
                    case 8:
                        Functionality.ShowStudentInfoByAcademicPerformance(students);
                        break;
                }
            } while (choice != 0);
            
            return 0;

        }


    }
}
