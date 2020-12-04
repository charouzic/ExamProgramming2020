using System;
using System.Text;

namespace ExamProgramming
{
    public class Case
    {

        public int Id { get; set; }
        public int ClientId { get; set; }
        public ESpecialization CaseType { get; set; }
        public DateTime StartDate { get; set; }
        public int TotalCharges { get; set; }
        public int LawyerId { get; set; }

        public Case(int id, int clientId, ESpecialization caseType, DateTime startDate, int totalCharges, int lawyerId)
        {
            Id = id;
            ClientId = clientId;
            CaseType = caseType;
            StartDate = startDate;
            TotalCharges = totalCharges;
            LawyerId = lawyerId;
        }

        public override string ToString()
        {
            StringBuilder textOutput = new StringBuilder();
            textOutput.AppendLine($"\nId: {Id}");
            textOutput.AppendLine($"Client Id: {ClientId}");
            textOutput.AppendLine($"Case Type: {CaseType}");
            textOutput.AppendLine($"Start Date: {StartDate}");
            textOutput.AppendLine($"Total Charges: {TotalCharges}");
            textOutput.AppendLine($"Lawyer Id: {LawyerId}");
            return textOutput.ToString();
        }
    }
}
