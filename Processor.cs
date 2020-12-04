using System;
using System.Collections.Generic;
using System.IO;

namespace ExamProgramming
{
    // this class will make the code to run and will be run from Program.cs
    public class Processor : IClient, IAppointment, ICase
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

        public int userType { get; set; }


        public void LoginOption()
        {
            Console.WriteLine("Choose your login option. Press [1] for Lawyer, press [2] for Admin or press [3] for Receptionist.");
            Console.Write("Your choice: ");
            try
            {
                userType = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine($"\nInvalid input: choose the correct number of choice");
                Login();
            }

            if(userType > 3 || userType < 0)
            {
                Console.WriteLine("Invalid input, please choose number 1, 2 or 3");
                LoginOption();
            }
        }

        public int Login()
        {
            LoginOption();

            while (true)
            {
                Console.WriteLine("Please provide your login details");

                // authenticated: 0 = no authentication, 1 = lawyer, 2 = administrative staff, 3 = receptionist
                int authenticated = 0;

                Console.Write("User name: ");
                string userName = Console.ReadLine();

                Console.Write("Password: ");
                string pwd = Console.ReadLine();

                switch(userType)
                {
                    case 1:
                        if (userName == lawyerUsrName && pwd == lawyerPwd)
                        {
                            Console.WriteLine("\n*** Welcome to lawyer menu ***");
                            authenticated = 1;
                            return authenticated;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect login name and/or password\n");
                        }
                        break;

                    case 2:
                        if (userName == adminStaffUsrName && pwd == adminStaffPwd)
                        {
                            Console.WriteLine("\n*** Welcome to Administrative staff menu ***");
                            authenticated = 2;
                            return authenticated;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect login name and/or password\n");
                        }
                        break;

                    case 3:
                        if (userName == receptionUsrName && pwd == receptionPwd)
                        {
                            Console.WriteLine("\n*** Welcome to Receptionist staff menu ***");
                            authenticated = 3;
                            return authenticated;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect login name and/or password\n");
                        }
                        break;

                }
            }
        }

        public void Menu(int loginAuthentication)
        {
            while(true)
            {
                switch (loginAuthentication)
                {
                    case 1:
                        Console.WriteLine("\nMenu options");
                        Console.WriteLine("1) List all cases");
                        Console.WriteLine("2) Add a new case");
                        Console.WriteLine("3) List all appointments");
                        Console.Write("Press number of your option: ");
                        // TODO: try except to be added as we are working with int (otherwise the app shuts down)
                        int menuOptionLawyer = int.Parse(Console.ReadLine());

                        switch (menuOptionLawyer)
                        {
                            case 1:
                                ListCases(Cases);
                                break;
                            case 2:
                                AddNewCase();
                                break;
                            case 3:
                                ListAppointment(Appointments);
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;

                        }
                        break;

                    case 2:
                        Console.WriteLine("\nMenu options");
                        Console.WriteLine("1) List all cases");
                        Console.WriteLine("2) List all appointments");
                        Console.Write("Press number of your option: ");
                        // TODO: try except to be added as we are working with int (otherwise the app shuts down)
                        int menuOptionAdm = int.Parse(Console.ReadLine());

                        switch (menuOptionAdm)
                        {
                            case 1:
                                ListCases(Cases);
                                break;
                            case 2:
                                ListAppointment(Appointments);
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                        break;

                    case 3:
                        Console.WriteLine("\nMenu options");
                        Console.WriteLine("1) Register a new client");
                        Console.WriteLine("2) Add a new appointment");
                        Console.WriteLine("3) List all appointments");
                        Console.WriteLine("4) List all clients");
                        Console.Write("Press number of your option: ");
                        // TODO: try except to be added as we are working with int (otherwise the app shuts down)
                        int menuOptionReception = int.Parse(Console.ReadLine());
                        switch (menuOptionReception)
                        {
                            case 1:
                                AddNewClient();
                                break;
                            case 2:
                                AddAppointment();
                                break;
                            case 3:
                                ListAppointment(Appointments);
                                break;
                            case 4:
                                ListClients(Clients);
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                        break;
                }
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

                // TODO: try except to be added as we are working with int (otherwise the app shuts down)
                int l_id = int.Parse(line[0]);
                string l_fName = line[1];
                string l_lName = line[2];
                // TODO: try except to be added as we are working with DateTime (otherwise the app shuts down)
                DateTime l_dob = DateTime.ParseExact(line[3], "d-M-yyyy", null);

                // TODO: try except to be added as we are working with int (otherwise the app shuts down)
                int l_seniority = int.Parse(line[4]);
                // TODO: try except to be added as we are working with int (otherwise the app shuts down)
                int l_specialization = int.Parse(line[5]);
                // TODO: try except to be added as we are working with DateTime (otherwise the app shuts down)
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

                // TODO: try except to be added as we are working with int (otherwise the app shuts down)
                int r_id = int.Parse(line[0]);
                string r_fName = line[1];
                string r_lName = line[2];
                // TODO: try except to be added as we are working with DateTime (otherwise the app shuts down)
                DateTime r_joinedOn = DateTime.ParseExact(line[3], "d-M-yyyy", null);

                Receptionist newReceptionist = new Receptionist(r_id, r_fName, r_lName, r_joinedOn);
                staffs.Add(newReceptionist);
            }

            Console.WriteLine($"Data has been successfully loaded\n");
        }


        public void AddNewClient()
        {
            Console.WriteLine("\nPlease provide following information about client");

            Console.Write("Id: ");
            // TODO: try except to be added as we are working with int (otherwise the app shuts down)
            int c_id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string c_name = Console.ReadLine();

            Console.Write("Date of Birth (dd-MM-yyyy, e.g.: 14-06-1997): ");
            // TODO: try except to be added as we are working with DateTime (otherwise the app shuts down)
            DateTime c_dob = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", null);

            Console.Write("Street: ");
            string c_street = Console.ReadLine();

            Console.Write("ZIP code: ");
            // TODO: try except to be added as we are working with int (otherwise the app shuts down)
            int c_zip = int.Parse(Console.ReadLine());

            Console.Write("City: ");
            string c_city = Console.ReadLine();

            Console.Write("Type of case (0 = Corporate, 1 = FamilyCase, 2 = CriminalCase): ");
            // TODO: try except to be added as we are working with int (otherwise the app shuts down)
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

        public int appointmentCounter = 0;

        public void AddAppointment()
        {
            Console.WriteLine("\nPlease provide following information about the appointment");

            Console.Write("Appointment Id: ");
            // TODO: try except to be added as we are working with int (otherwise the app shuts down)
            int app_Id = int.Parse(Console.ReadLine());

            // wasnt sure how to do it, should we create enums or sth based on the client id?
            Console.Write("Client Id: ");
            // TODO: try except to be added as we are working with int (otherwise the app shuts down)
            int app_CId = int.Parse(Console.ReadLine());

            Console.Write("Date and hour of appointment (e.g. 15-12-2020, 12:30): ");
            // TODO: try except to be added as we are working with DateTime (otherwise the app shuts down)
            DateTime app_Doa = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy, HH:m", null);

            Console.Write("Room (Aquarium = 0, Cube = 1, Cave = 2): ");
            // TODO: try except to be added as we are working with int (otherwise the app shuts down)
            int app_Room = int.Parse(Console.ReadLine());

            switch (app_Room)
            {
                case 0:
                    Appointment newAppointmentAqua = new Appointment(app_Id, app_CId, app_Doa, EMeetingRoom.Aquarium);
                    Appointments.Add(newAppointmentAqua);
                    Console.WriteLine($"Appointment with ID {app_Id} on {app_Doa} has been added");
                    appointmentCounter++;
                    break;

                case 1:
                    Appointment newAppointmentCube = new Appointment(app_Id, app_CId, app_Doa, EMeetingRoom.Cube);
                    Appointments.Add(newAppointmentCube);
                    Console.WriteLine($"Appointment with ID {app_Id} on {app_Doa} has been added");
                    appointmentCounter++;
                    break;

                case 2:
                    Appointment newAppointmentCave = new Appointment(app_Id, app_CId, app_Doa, EMeetingRoom.Cave);
                    Appointments.Add(newAppointmentCave);
                    Console.WriteLine($"Appointment with ID {app_Id} on {app_Doa} has been added");
                    appointmentCounter++;
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        public void ListAppointment(List<Appointment> appointments)
        {
            if (appointmentCounter == 0)
            {
                Console.WriteLine("\nNo appointments are listed yet!");
            }
            else if (appointmentCounter > 0)
            {
                foreach (var a in appointments)
                {
                    Console.WriteLine(a);
                }
            }
        }

        public int caseCounter = 0;

        public void AddNewCase()
        {
            Console.WriteLine("\nPlease provide following information about the case");

            Console.Write("Case Id: ");
            // TODO: try except to be added as we are working with int (otherwise the app shuts down)
            int case_Id = int.Parse(Console.ReadLine());

            Console.Write("Lawyer Id: ");
            // TODO: try except to be added as we are working with int (otherwise the app shuts down)
            int case_LId = int.Parse(Console.ReadLine());

            Console.Write("Customer Id: ");
            // TODO: try except to be added as we are working with int (otherwise the app shuts down)
            int case_CId = int.Parse(Console.ReadLine());

            Console.Write("Total charges: ");
            // TODO: try except to be added as we are working with int (otherwise the app shuts down)
            int case_Charges = int.Parse(Console.ReadLine());

            Console.Write("Start date: (e.g. 15-12-2020, 12:30): ");
            // TODO: try except to be added as we are working with DateTime (otherwise the app shuts down)
            DateTime case_Start = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy, HH:m", null); ;

            Console.Write("Case type (Corporate = 0, Family = 1, Criminal = 2): ");
            // TODO: try except to be added as we are working with int (otherwise the app shuts down)
            int case_Spe = int.Parse(Console.ReadLine());


            switch (case_Spe)
            {
                case 0:
                    Case newCaseCorp = new Case(case_Id, case_CId, ESpecialization.Corporate, case_Start, case_Charges, case_LId);
                    Cases.Add(newCaseCorp);
                    Console.WriteLine($"Case with ID {case_Id} has been added");
                    caseCounter++;
                    break;

                case 1:
                    Case newCaseFam = new Case(case_Id, case_CId, ESpecialization.FamilyCase, case_Start, case_Charges, case_LId);
                    Cases.Add(newCaseFam);
                    Console.WriteLine($"Case with ID {case_Id} has been added");
                    caseCounter++;
                    break;

                case 2:
                    Case newCaseCrim = new Case(case_Id, case_CId, ESpecialization.CriminalCase, case_Start, case_Charges, case_LId);
                    Cases.Add(newCaseCrim);
                    Console.WriteLine($"Case with ID {case_Id} has been added");
                    caseCounter++;
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        public void ListCases(List<Case> cases)
        {
            if (caseCounter == 0)
            {
                Console.WriteLine("\nNo cases are listed yet!");
            }
            else if (caseCounter > 0)
            {
                foreach (var a in cases)
                {
                    Console.WriteLine(a);
                }
            }
        }

        public void initAppointment()
        {
            string apointemnDate = "11-12-2020, 13:00";
            DateTime oApointemnDate = DateTime.ParseExact(apointemnDate, "d-M-yyyy, H:m", null);

            Appointment newDummyAppointmentAqua = new Appointment(1, 1, oApointemnDate, EMeetingRoom.Aquarium);
            Appointments.Add(newDummyAppointmentAqua);
            appointmentCounter++;

            Appointment newDummyAppointmentCube = new Appointment(2, 2, oApointemnDate, EMeetingRoom.Cube);
            Appointments.Add(newDummyAppointmentCube);
            appointmentCounter++;

            Appointment newDummyAppointmentCave = new Appointment(3, 3, oApointemnDate, EMeetingRoom.Cave);
            Appointments.Add(newDummyAppointmentCave);
            appointmentCounter++;


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
            initAppointment();
            Menu(Login());

        }

        
    }
}
