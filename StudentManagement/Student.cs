using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentManagement
{
    [Serializable]
    internal class Student : Person
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("university")]
        public string University { get; set; }
        [JsonPropertyName("admissionYear")]
        public int AdmissionYear { get; set; }
        [JsonPropertyName("cpa")]
        public float CPA { get; set; }        
        [JsonPropertyName("academicAbility")]
        public AcademicPerformance AcademicAbility { get; set; }

        [JsonConstructor]
        public Student(string name, DateTime birthday, string address, float height, float weight, string code, string university, int admissionYear, float cumulateGradePointAverage) : base(name, birthday, address, height, weight)
        {
            Code = code;
            University = university; 
            AdmissionYear = admissionYear; 
            CPA = cumulateGradePointAverage;
            AcademicAbility = Utils.AssignAcademicAbility(CPA);
        }

        public override string? ToString()
        {
            return base.ToString() + "\n\t\t" + "Code : " + Code + "\n\t\t" + "University : " + University + "\n\t\t" + "Admission Year : " + AdmissionYear + "\n\t\t" + "CPA : " + CPA + "\n\t\t" + "Academic Performance : " + AcademicAbility;
        }
    }
}
