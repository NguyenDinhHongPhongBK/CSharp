using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    internal enum AcademicPerformance
    {
        Excellent = 1,          // CPA >= 9
        VeryGood = 2,           // 7.5 <= CPA < 9
        Good = 3,               // 6.5 <= CPA < 7.5
        Average = 4,            // 5 <= CPA < 6.5
        BelowAverage = 5,       // 3 <= CPA < 5
        Weak = 6,                // CPA < 3
    }
}
