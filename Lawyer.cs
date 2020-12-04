using System;
using System.Text;

namespace ExamProgramming
{
    // this class stores Lawyers (5 senior, 21 junior)
    public class Lawyer : Employee
    {

        public DateTime DOB { get; set; }
        public ESeniority Seniority { get; set; }
        public ESpecialization Specialization { get; set; }

        public Lawyer(int id, string firstName, string lastName, DateTime dob, ESeniority seniority, ESpecialization specialization, DateTime joinedOn) : base (id, firstName, lastName, joinedOn)
        { 
            DOB = dob;
            Seniority = seniority;
            Specialization = specialization;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(base.ToString());
            str.AppendLine($"Date of Birth: {DOB}");
            str.AppendLine($"Seniority: {Seniority}");
            str.AppendLine($"Specialization: {Specialization}");
            return str.ToString();
        }
    }
}
