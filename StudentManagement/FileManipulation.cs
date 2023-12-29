using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace StudentManagement
{
    internal class FileManipulation
    {
        public static void SaveJsonFile(List<Student> students, string path)
        {
            try
            {
                var studentsString = JsonSerializer.Serialize(students, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(path, studentsString);
                Console.WriteLine("\tSave successfully to " + path);
            }
            catch (Exception)
            {
                Console.WriteLine("\tCan not save to " + path);
            }
        }

        public static List<Student> ReadJsonFile(string path)
        {
            List<Student> students = new();
            try
            {
                string json = File.ReadAllText(path);
                students = JsonConvert.DeserializeObject<List<Student>>(json) ?? students;
                Console.WriteLine("\tRead successfully from " + path);
            }
            catch (Exception)
            {
                Console.WriteLine("\tCan not read from " + path);
            }
            return students;
        }
    }
}
