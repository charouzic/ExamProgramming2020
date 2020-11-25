using System;
using System.Collections.Generic;
using System.IO;

namespace ExamProgramming
{
    // this class will make the code to run and will be run from Program.cs
    public class Processor
    {
        // instantiating the list for clients
        List<Client> Clients = new List<Client>();
        List<Appointment> Appointments = new List<Appointment>();
        List<Case> Cases = new List<Case>();
        List<Employee> Staffs = new List<Employee>();


        public void instantiateLawyers(List<Employee> staffs, string path, string fileName)
        {
            string fullPath = $"{path}{fileName}";
            Console.WriteLine(fullPath);
            string[] lines = File.ReadAllLines(fullPath);


            for (int i = 2; i < lines.Length; ++i)
            {
                //Console.WriteLine(i);
                string[] line = lines[i].Split(';');


                int l_id = int.Parse(line[0]);
                string l_fName = line[1];
                string l_lName = line[2];
                DateTime l_dob = DateTime.ParseExact(line[3], "dd-MM-yyyy", null);


                int l_seniority = int.Parse(line[4]);
                int l_specialization = int.Parse(line[5]);
                DateTime l_joinedOn = DateTime.ParseExact(line[6], "dd-MM-yyyy", null);

                // if block because of enumerators
                // TODO: look if this can be done in nicer way
                if (l_seniority == 1)
                {
                    if (l_specialization == 0)
                    {
                        Lawyer lawyer = new Lawyer(l_id, l_fName, l_lName, l_dob, ESeniority.Junior, ESpecialization.Corporate, l_joinedOn);
                        staffs.Add(lawyer);
                    }
                    if (l_specialization == 1)
                    {
                        Lawyer lawyer = new Lawyer(l_id, l_fName, l_lName, l_dob, ESeniority.Junior, ESpecialization.FamilyCase, l_joinedOn);
                        staffs.Add(lawyer);
                    }
                    if (l_specialization == 2)
                    {
                        Lawyer lawyer = new Lawyer(l_id, l_fName, l_lName, l_dob, ESeniority.Junior, ESpecialization.CriminalCase, l_joinedOn);
                        staffs.Add(lawyer);
                    }
                }
                if (l_seniority == 2)
                {
                    if (l_specialization == 0)
                    {
                        Lawyer lawyer = new Lawyer(l_id, l_fName, l_lName, l_dob, ESeniority.Junior, ESpecialization.Corporate, l_joinedOn);
                        staffs.Add(lawyer);
                    }
                    if (l_specialization == 1)
                    {
                        Lawyer lawyer = new Lawyer(l_id, l_fName, l_lName, l_dob, ESeniority.Junior, ESpecialization.FamilyCase, l_joinedOn);
                        staffs.Add(lawyer);
                    }
                    if (l_specialization == 2)
                    {
                        Lawyer lawyer = new Lawyer(l_id, l_fName, l_lName, l_dob, ESeniority.Junior, ESpecialization.CriminalCase, l_joinedOn);
                        staffs.Add(lawyer);
                    }
                }
            }

            
            Console.WriteLine($"Data has been successfully loaded from path '{fullPath}'");

            // TODO: could be rewritten in a ToString() method
            foreach (var i in staffs)
            {
                Console.WriteLine($"Id:{i.Id}, Name:{i.FirstName} {i.LastName}, Joined on:{i.JoinedOn}\n");
            }
        }

        public void instantiateAdministrative(List<Employee> staffs, string path, string fileName)
        {

        }

        public void instantiateReceptionist(List<Employee> staffs, string path, string fileName)
        {

        }


        public void Process()
        {
            instantiateLawyers(Staffs, "/users/viki/desktop/c#/exam/data/", "lawyers.csv");
        }
    }
}
