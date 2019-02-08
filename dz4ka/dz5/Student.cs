using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz5
{
    struct Student
    {

        public string FullName { get; set; }
        public string GroupName { get; set; }
        public double AvgMark { get; set; }
        public int IncomePerFamilyMember { get; set; }
        public int GenderSave { get; set; }
        public int StudyFormSave { get; set; }
        public enum Gender
        {
            Male = 1,
            Female = 2
        }
        public enum StudyForm
        {
            Intramural = 1,
            Correspondence = 2
        }
    }
}