using System;
namespace ExamProgramming
{
    public class Receptionist : Employee
    {
        public Receptionist(int id, string firstName, string lastName, DateTime joinedOn) : base (id, firstName, lastName, joinedOn)
        {
        }
    }
}
