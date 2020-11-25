using System;
namespace ExamProgramming
{
    // this class stores Lawyers (5 senior, 21 junior)
    public class Lawyer : Personel
    {
        public Lawyer(int id, string firstName, string lastName, DateTime dob, string seniority, string specialization, DateTime joinedOn) : base (id, firstName, lastName, joinedOn)
        {
            DOB = dob;
            // based on seniority we can destinguish between senior and junior lawyer
            // also this parameter could be set as Enum (0 = Junior, 1 = Senior)
            Seniority = seniority;
            // again place for Enum (0 = Corporate, 1 = FamilyCase, 2 = CriminalCase)
            Specialization = specialization;
            
        }
        public DateTime DOB { get; set; }
        public string Seniority { get; set; }
        public string Specialization { get; set; }
    }
}
