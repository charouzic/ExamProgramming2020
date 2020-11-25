using System;
namespace ExamProgramming
{
    // this class can be used to store receptionists (1 in total)
    public abstract class Employee
    {
        public Employee(int id, string firstName, string lastName, DateTime joinedOn)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            JoinedOn = joinedOn;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinedOn { get; set; }

        
    }
}
