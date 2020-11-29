using System;
using System.Text;

namespace ExamProgramming
{
    // this class can be used to store receptionists (1 in total)
    public abstract class Employee
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinedOn { get; set; }

        public Employee(int id, string firstName, string lastName, DateTime joinedOn)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            JoinedOn = joinedOn;
        }

        public override string ToString()
        {
            StringBuilder textOutput = new StringBuilder();
            textOutput.AppendLine($"\nId: {Id}");
            textOutput.AppendLine($"Name: {FirstName} {LastName}");
            textOutput.AppendLine($"Joined on: {JoinedOn}");
            return textOutput.ToString();
        }
    }
}
