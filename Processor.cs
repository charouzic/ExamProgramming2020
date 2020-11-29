using System;
using System.Collections.Generic;
using System.IO;

namespace ExamProgramming
{
    // this class will make the code to run and will be run from Program.cs
    public class Processor : IClient
    {
        // instantiating the list for clients
        List<Client> Clients = new List<Client>();
        List<Appointment> Appointments = new List<Appointment>();
        List<Case> Cases = new List<Case>();
        List<Employee> Staffs = new List<Employee>();

        private string lawyerUsrName = "lawyer";
        private string lawyerPwd = "Listen10";

        private string adminStaffUsrName = "administration";
        private string adminStaffPwd = "Listen20";

        private string receptionUsrName = "reception";
        private string receptionPwd = "Listen30";


        public int Login()
        {
            Console.WriteLine("Please provide your login details");

            // authenticated: 0 = no authentication, 1 = lawyer, 2 = administrative staff, 3 = receptionist
            int authenticated = 0;
            
            Console.Write("User name: ");
            string userName = Console.ReadLine();

            Console.Write("Password: ");
            string pwd = Console.ReadLine();

            if (userName == lawyerUsrName && pwd == lawyerPwd)
            {
                authenticated = 1;
            }

            if (userName == adminStaffUsrName && pwd == adminStaffPwd)
            {
                authenticated = 2;
            }

            if (userName == receptionUsrName && pwd == receptionPwd)
            {
                authenticated = 3;
            }

            return authenticated;
        }

        public void Menu(int loginAuthentication)
        {
            switch (loginAuthentication)
            {
                case 1:
                    Console.WriteLine("*** Welcome to lawyer menu ***");
                    Console.WriteLine("Here are you options");
                    Console.WriteLine("1) List all cases");
                    Console.WriteLine("2) Add a new case");
                    Console.WriteLine("3) List all appointments");
                    Console.Write("Press number of your option: ");
                    int menuOptionLawyer = int.Parse(Console.ReadLine());

                    switch (menuOptionLawyer)
                    {
                        case 1:
                            // TODO: call the method after the it's written
                            Console.WriteLine("Listing all cases");
                            break;
                        case 2:
                            // TODO: call the method after the it's written
                            Console.WriteLine("Adding a new case");
                            break;
                        case 3:
                            // TODO: call the method after the it's written
                            Console.WriteLine("Listing all appointments");
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;

                    }
                    break;

                case 2:
                    Console.WriteLine("*** Welcome to Administrative staff menu ***");
                    Console.WriteLine("Here are you options");
                    Console.WriteLine("1) List all cases");
                    Console.WriteLine("2) List all appointments");
                    Console.Write("Press number of your option: ");
                    int menuOptionAdm = int.Parse(Console.ReadLine());

                    switch (menuOptionAdm)
                    {
                        case 1:
                            // TODO: call the method after the it's written
                            Console.WriteLine("Listing all cases");
                            break;
                        case 2:
                            // TODO: call the method after the it's written
                            Console.WriteLine("Listing all appointments");
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                    break;

                case 3:
                    Console.WriteLine("*** Welcome to Receptionist staff menu ***");
                    Console.WriteLine("Here are you options");
                    Console.WriteLine("1) Register a new client");
                    Console.WriteLine("2) Add a new appointment");
                    Console.WriteLine("3) List all appointments");
                    Console.WriteLine("4) List all clients");
                    Console.Write("Press number of your option: ");
                    int menuOptionReception = int.Parse(Console.ReadLine());
                    switch (menuOptionReception)
                    {
                        case 1:
                            // TODO: call the method after the it's written
                            Console.WriteLine("Registering a new client");
                            break;
                        case 2:
                            // TODO: call the method after the it's written
                            Console.WriteLine("Adding a new appointments");
                            break;
                        case 3:
                            // TODO: call the method after the it's written
                            Console.WriteLine("Listing all appointments");
                            break;
                        case 4:
                            // TODO: call the method after the it's written
                            Console.WriteLine("Listing all clients");
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                    break;
            }
        }

        public void instantiateLawyers(List<Employee> staffs, string path, string fileName)
        {
            string lawyersFullPath = $"{path}{fileName}";
            Console.WriteLine($"Reading data from: '{lawyersFullPath}'");
            string[] lines = File.ReadAllLines(lawyersFullPath);


            for (int i = 2; i < lines.Length; ++i)
            {
                //Console.WriteLine(i);
                string[] line = lines[i].Split(';');


                int l_id = int.Parse(line[0]);
                string l_fName = line[1];
                string l_lName = line[2];
                DateTime l_dob = DateTime.ParseExact(line[3], "d-M-yyyy", null);


                int l_seniority = int.Parse(line[4]);
                int l_specialization = int.Parse(line[5]);
                DateTime l_joinedOn = DateTime.ParseExact(line[6], "d-M-yyyy", null);

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
            
            Console.WriteLine($"Data successfully loaded\n");
        }

        public void instantiateAdministrative(List<Employee> staffs, string path, string fileName)
        {
            string administrativeFullPath = $"{path}{fileName}";
            Console.WriteLine($"Reading data from: '{administrativeFullPath}'");
            string[] lines = File.ReadAllLines(administrativeFullPath);


            for (int i = 2; i < lines.Length; ++i)
            {
                //Console.WriteLine(i);
                string[] line = lines[i].Split(';');


                int a_id = int.Parse(line[0]);
                string a_fName = line[1];
                string a_lName = line[2];
                DateTime a_joinedOn = DateTime.ParseExact(line[3], "d-M-yyyy", null);
                string a_role = line[4];

                AdminStaff newAdmStaff = new AdminStaff(a_id, a_fName, a_lName, a_joinedOn, a_role);
                staffs.Add(newAdmStaff);
            }

            Console.WriteLine($"Data successfully loaded\n");
        }


        public void instantiateReceptionist(List<Employee> staffs, string path, string fileName)
        {
            string receptionistsFullPath = $"{path}{fileName}";
            Console.WriteLine($"Reading data from: '{receptionistsFullPath}'");
            string[] lines = File.ReadAllLines(receptionistsFullPath);


            for (int i = 2; i < lines.Length; ++i)
            {
                //Console.WriteLine(i);
                string[] line = lines[i].Split(';');


                int r_id = int.Parse(line[0]);
                string r_fName = line[1];
                string r_lName = line[2];
                DateTime r_joinedOn = DateTime.ParseExact(line[3], "d-M-yyyy", null);

                Receptionist newReceptionist = new Receptionist(r_id, r_fName, r_lName, r_joinedOn);
                staffs.Add(newReceptionist);
            }

            Console.WriteLine($"Data has been successfully loaded\n");
        }


        public void AddNewClient()
        {
            Console.WriteLine("Please provide following information about client");

            Console.Write("Id: ");
            int c_id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string c_name = Console.ReadLine();

            Console.Write("Date of Birth (dd-MM-yyyy, e.g.: 14-06-1997): ");
            DateTime c_dob = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", null);

            Console.Write("Street: ");
            string c_street = Console.ReadLine();

            Console.Write("ZIP code: ");
            int c_zip = int.Parse(Console.ReadLine());

            Console.Write("City: ");
            string c_city = Console.ReadLine();

            Console.Write("Type of case (0 = Corporate, 1 = FamilyCase, 2 = CriminalCase): ");
            int c_case = int.Parse(Console.ReadLine());

            switch(c_case)
            {
                case 0:
                    Client newClientCorporate = new Client(c_id, c_name, c_dob, ESpecialization.Corporate, c_street, c_zip, c_city);
                    Clients.Add(newClientCorporate);
                    Console.WriteLine($"Client '{c_name}' has been added");
                    break;
                    

                case 1:
                    Client newClientFamily = new Client(c_id, c_name, c_dob, ESpecialization.FamilyCase, c_street, c_zip, c_city);
                    Clients.Add(newClientFamily);
                    Console.WriteLine($"Client '{c_name}' has been added");
                    break;
                    

                case 2:
                    Client newClientCriminal = new Client(c_id, c_name, c_dob, ESpecialization.CriminalCase, c_street, c_zip, c_city);
                    Clients.Add(newClientCriminal);
                    Console.WriteLine($"Client '{c_name}' has been added");
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        public void ListClients(List<Client> clients)
        {
            foreach (var o in clients)
            {
                Console.WriteLine(o);
            }
        }

        public void Process()
        {
            //instantiateLawyers(Staffs, "/users/viki/desktop/c#/exam/data/", "lawyers.csv");
            //instantiateAdministrative(Staffs, "/users/viki/desktop/c#/exam/data/", "administrative.csv");
            //instantiateReceptionist(Staffs, "/users/viki/desktop/c#/exam/data/", "receptionist.csv");
            /*
            foreach (object o in Staffs)
            {
                Console.WriteLine(o);
            }
            */
            //AddNewClient();
            //ListClients(Clients);
            Menu(Login());

        }

        
    }
}
