using System;
using System.Text;

namespace ExamProgramming
{
    // usage of abstract class is not relevant here
    public class Client
    {
        public ESpecialization Specialization { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Street { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }

        public Client(int id, string name, DateTime dob, ESpecialization specialization, string street, int zip, string city)
        {
            Id = id;
            Name = name;
            DOB = dob;
            Specialization = specialization;
            Street = street;
            Zip = zip;
            City = city;
        }

        public override string ToString()
        {
            StringBuilder textOutput = new StringBuilder();
            textOutput.AppendLine($"\nClient Id: {Id}");
            textOutput.AppendLine($"Name: {Name}");
            textOutput.AppendLine($"Address: {Street}, {Zip} {City}");
            textOutput.AppendLine($"Case Type: {Specialization}");
            return textOutput.ToString();
        }
    }
}
