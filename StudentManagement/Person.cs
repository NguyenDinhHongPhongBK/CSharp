using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentManagement
{
    internal class Person
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("birthday")]
        public DateTime Birthdate { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("height")]
        public float Height { get; set; }
        [JsonPropertyName("weight")]
        public float Weight { get; set; }

        public static int indexId = 0;

        [JsonConstructor]
        public Person(string name, DateTime birthdate, string address, float height, float weight)
        {
            Id = GenerateId();
            Name = name;
            Birthdate = birthdate;
            Address = address;
            Height = height;
            Weight = weight;
        }

        private static int GenerateId()
        {
            return ++indexId;
        }

        public override string? ToString()
        {
            return "\t\t" + "Id : " + Id + "\n\t\t" + "Name : " + Name + "\n\t\t" + "Birthday: " + Birthdate.Day + " - " + Birthdate.Month + " - " + Birthdate.Year
                    + "\n\t\t" + "Address : " + Address + "\n\t\t" + "Height : " + Height + " cm" + "\n\t\t" + "Weight : " + Weight + " kg";
        }
    }
}
