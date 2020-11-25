using System;
namespace ExamProgramming
{
    public class Case
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public ESpecialization CaseType { get; set; }
        public DateTime StartDate { get; set; }
        public int TotalCharges { get; set; }
        public int LawyerId { get; set; }

        public Case(int id, int customerId, ESpecialization caseType, DateTime startDate, int totalCharges, int lawyerId)
        {
            Id = id;
            CustomerId = customerId;
            CaseType = caseType;
            StartDate = startDate;
            TotalCharges = totalCharges;
            LawyerId = lawyerId;
        }
    }
}
