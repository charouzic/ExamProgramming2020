using System;
using System.Collections.Generic;
using System.Globalization;
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

        public int appointmentCounter = 0;
        public int caseCounter = 0;
        public int clientsCounter = 0;


        public void LoginOption()
        {
            try
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
                    LoginOption();
                }

                if (userType > 3 || userType <= 0)
                {
                    Console.WriteLine("Invalid input, please choose number 1, 2 or 3");
                    LoginOption();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
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
                            LoginOption();
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
                            LoginOption();
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
                            LoginOption();
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
                        Console.WriteLine("4) Exit");
                        Console.Write("Press number of your option: ");

                        try
                        {
                            int menuOptionLawyer = int.Parse(Console.ReadLine());

                            switch (menuOptionLawyer)
                            {
                                case 1:
                                    ListCases(Cases);
                                    break;
                                case 2:
                                    AddNewCase(Staffs);
                                    break;
                                case 3:
                                    ListAppointment(Appointments);
                                    break;
                                case 4:
                                    Console.WriteLine("\nThank you for using our app. Hope to see you soon!");
                                    System.Environment.Exit(1);
                                    break;
                                default:
                                    Console.WriteLine("\nInvalid input! Press correct number 1-4");
                                    break;
                            }
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("\nInvalid input! Press correct number 1-4");
                        }

                        break;

                    case 2:
                        Console.WriteLine("\nMenu options");
                        Console.WriteLine("1) List all cases");
                        Console.WriteLine("2) List all appointments");
                        Console.WriteLine("3) Exit");
                        Console.Write("Press number of your option: ");
                        
                        try
                        {
                            int menuOptionAdm = int.Parse(Console.ReadLine());

                            switch (menuOptionAdm)
                            {
                                case 1:
                                    ListCases(Cases);
                                    break;
                                case 2:
                                    ListAppointment(Appointments);
                                    break;
                                case 3:
                                    Console.WriteLine("\nThank you for using our app. Hope to see you soon!");
                                    System.Environment.Exit(1);
                                    break;
                                default:
                                    Console.WriteLine("\nInvalid input! Press correct number 1-3");
                                    break;
                            }
                        }
                        catch(Exception)
                        {
                            Console.WriteLine("\nInvalid input! Press correct number 1-3");
                        }
                        break;

                    case 3:
                        Console.WriteLine("\nMenu options");
                        Console.WriteLine("1) Register a new client");
                        Console.WriteLine("2) Add a new appointment");
                        Console.WriteLine("3) List all appointments");
                        Console.WriteLine("4) List all clients");
                        Console.WriteLine("5) Exit");
                        Console.Write("Press number of your option: ");

                        try
                        {
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
                                case 5:
                                    Console.WriteLine("\nThank you for using our app. Hope to see you soon!");
                                    System.Environment.Exit(1);
                                    break;
                                default:
                                    Console.WriteLine("\nInvalid input! Press correct number 1-5");
                                    break;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nInvalid input! Press correct number 1-5");
                        }
                        break;
                }
            }
        }
        
        public void instantiateLawyers(List<Employee> lawyers, string path, string fileName)
        {
            try
            {
                string lawyersFullPath = $"{path}{fileName}";
                Console.WriteLine($"Reading data from: '{lawyersFullPath}'");
                string[] lines = File.ReadAllLines(lawyersFullPath);

                for (int i = 2; i < lines.Length; ++i)
                {
                    string[] line = lines[i].Split(';');

                    int l_id = int.Parse(line[0]);
                    string l_fName = line[1];
                    string l_lName = line[2];
                    DateTime l_dob = DateTime.ParseExact(line[3], "d-M-yyyy", null);

                    int l_seniority = int.Parse(line[4]);
                    int l_specialization = int.Parse(line[5]);
                    DateTime l_joinedOn = DateTime.ParseExact(line[6], "d-M-yyyy", null);

                    Lawyer lawyer = new Lawyer(l_id, l_fName, l_lName, l_dob, (ESeniority)l_seniority, (ESpecialization)l_specialization, l_joinedOn);
                    lawyers.Add(lawyer);
                }

                Console.WriteLine($"Data successfully loaded\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
        }

        public void instantiateAdministrative(List<Employee> adminstaff, string path, string fileName)
        {
            try
            {
                string administrativeFullPath = $"{path}{fileName}";
                Console.WriteLine($"Reading data from: '{administrativeFullPath}'");
                string[] lines = File.ReadAllLines(administrativeFullPath);


                for (int i = 2; i < lines.Length; ++i)
                {
                    string[] line = lines[i].Split(';');


                    int a_id = int.Parse(line[0]);
                    string a_fName = line[1];
                    string a_lName = line[2];
                    DateTime a_joinedOn = DateTime.ParseExact(line[3], "d-M-yyyy", null);
                    string a_role = line[4];

                    AdminStaff newAdmStaff = new AdminStaff(a_id, a_fName, a_lName, a_joinedOn, a_role);
                    adminstaff.Add(newAdmStaff);
                }

                Console.WriteLine($"Data successfully loaded\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
        }


        public void instantiateReceptionist(List<Employee> reception, string path, string fileName)
        {
            try
            {
                string receptionistsFullPath = $"{path}{fileName}";
                Console.WriteLine($"Reading data from: '{receptionistsFullPath}'");
                string[] lines = File.ReadAllLines(receptionistsFullPath);


                for (int i = 2; i < lines.Length; ++i)
                {
                    string[] line = lines[i].Split(';');

                    int r_id = int.Parse(line[0]);
                    string r_fName = line[1];
                    string r_lName = line[2];
                    DateTime r_joinedOn = DateTime.ParseExact(line[3], "d-M-yyyy", null);

                    Receptionist newReceptionist = new Receptionist(r_id, r_fName, r_lName, r_joinedOn);
                    reception.Add(newReceptionist);
                }

                Console.WriteLine($"Data has been successfully loaded\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
            
        }


        public void AddNewClient()
        {
            try
            {
                Console.WriteLine("\nPlease provide following information about client");

                Console.Write("Id: ");
                int c_id;
                while (!int.TryParse(Console.ReadLine(), out c_id))
                {
                    Console.WriteLine("Please Enter a valid numerical value!");
                    Console.Write("Id: ");
                }

                Console.Write("Name: ");
                string c_name = Console.ReadLine();

                Console.Write("Date of Birth (dd-MM-yyyy, e.g.: 14-06-1997): ");
                DateTime c_dob;

                while (!DateTime.TryParseExact(Console.ReadLine(), "d-M-yyyy", null, DateTimeStyles.None, out c_dob))
                {
                    Console.WriteLine("Wrong Value, try again: ");
                    Console.Write("Date of Birth (dd-MM-yyyy, e.g.: 14-06-1997): ");
                }

                Console.Write("Street: ");
                string c_street = Console.ReadLine();

                Console.Write("ZIP code: ");
                int c_zip;

                while (!int.TryParse(Console.ReadLine(), out c_zip))
                {
                    Console.WriteLine("Please Enter a valid numerical value!");
                    Console.Write("ZIP code: ");
                }

                Console.Write("City: ");
                string c_city = Console.ReadLine();


                Console.Write("Type of case (0 = Corporate, 1 = FamilyCase, 2 = CriminalCase): ");
                int c_case;

                while (!(int.TryParse(Console.ReadLine(), out c_case) && (c_case >= 0 && c_case < 3)))
                {
                    Console.WriteLine("Wrong Value, try again: ");
                    Console.WriteLine("Type of case (0 = Corporate, 1 = FamilyCase, 2 = CriminalCase): ");
                }

                Client newClient = new Client(c_id, c_name, c_dob, (ESpecialization)c_case, c_street, c_zip, c_city);
                Clients.Add(newClient);
                clientsCounter++;
                Console.WriteLine($"Client '{c_name}' has been added");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
        }


        public void ListClients(List<Client> clients)
        {
            try
            {
                if (clientsCounter == 0)
                {
                    Console.WriteLine("\nNo clients are listed yet!");
                }
                else if (clientsCounter > 0)
                {
                    foreach (var a in clients)
                    {
                        Console.WriteLine(a);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
        }


        public bool timeSlotCheck(List <Appointment> appointmentList, DateTime appointmentDate, int appointmentRoom)
        {
            try
            {
                List<int> diff = new List<int>();

                var date = appointmentDate.ToString("yyyy-MM-dd");

                foreach (var a in appointmentList)
                {

                    if (a.DateTime.ToString("yyyy-MM-dd") == date && a.MeetingRoom == (EMeetingRoom)appointmentRoom)
                    {
                        // finding out if there is a time difference between the 2 datetimes
                        int result = TimeSpan.Compare(appointmentDate.TimeOfDay, a.DateTime.TimeOfDay);
                        if (result > 0)
                        {
                            TimeSpan duration = appointmentDate - a.DateTime;
                            diff.Add(int.Parse(duration.TotalMinutes.ToString()));
                        }
                        if (result < 0)
                        {
                            TimeSpan duration = a.DateTime - appointmentDate;
                            diff.Add(int.Parse(duration.TotalMinutes.ToString()));
                        }

                        if (result == 0)
                        {
                            diff.Add(0);
                        }
                    }
                }

                // iterating through the list to see if there are any slots smaller than 60 minuntes
                foreach (int i in diff)
                {
                    if (i >= 60)
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
                return false;
            }
        }
        

        public void AddAppointment()
        {
            try
            {
                Console.WriteLine("\nPlease provide following information about the appointment");

                Console.Write("Date of an appointment (e.g. 15-12-2020 13:30): ");
                DateTime app_Doa;// = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy H:m", null);

                DateTime todaysDate = DateTime.Now;
                DateTime firstAppoint = DateTime.ParseExact("8:00", "H:m", null);
                DateTime lastAppoint = DateTime.ParseExact("17:00", "H:m", null);

                while ((!DateTime.TryParseExact(Console.ReadLine(), "d-M-yyyy H:m", null, DateTimeStyles.None, out app_Doa)) || (app_Doa.TimeOfDay < firstAppoint.TimeOfDay || app_Doa.TimeOfDay > lastAppoint.TimeOfDay || app_Doa.Date < todaysDate.Date))
                {
                    Console.WriteLine("\nWrong Value, try again");
                    Console.WriteLine("Beware of opening hours 8:00-18:00 hence last appointment is possible at 17:00");
                    Console.Write("\nDate of an appointment (e.g. 15-12-2020 13:30): ");
                }


                Console.Write("Room (Aquarium = 0, Cube = 1, Cave = 2): ");
                int app_Room;
                while (!(int.TryParse(Console.ReadLine(), out app_Room) && (app_Room >= 0 && app_Room < 3)))
                {
                    Console.WriteLine("Wrong Value, try again: ");
                    Console.WriteLine("Room (Aquarium = 0, Cube = 1, Cave = 2): ");
                }

                // returning true if there are at least 60 minutes before and after
                if (timeSlotCheck(Appointments, app_Doa, app_Room) == false)
                {
                    Console.WriteLine("Time slot if full, choose different time or meeting room.");
                    AddAppointment();
                }
                else
                {
                    Console.Write("Appointment Id: ");
                    int app_Id;

                    while (!int.TryParse(Console.ReadLine(), out app_Id))
                    {
                        Console.WriteLine("Please Enter a valid numerical value!");
                        Console.Write("Appointment Id: ");
                    }

                    Console.Write("Client Id: ");
                    int app_CId;

                    while (!int.TryParse(Console.ReadLine(), out app_CId))
                    {
                        Console.WriteLine("Please Enter a valid numerical value!");
                        Console.Write("Client Id: ");
                    }

                    Appointment newAppointmentAqua = new Appointment(app_Id, app_CId, app_Doa, (EMeetingRoom)app_Room);
                    Appointments.Add(newAppointmentAqua);
                    Console.WriteLine($"Appointment with ID {app_Id} on {app_Doa} has been added");
                    appointmentCounter++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
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


        public void AddNewCase(List<Employee> lawyers)
        {
            try
            {
                Console.WriteLine("\nPlease provide following information about the case");

                Console.Write("Case Id: ");
                int case_Id;
                while (!int.TryParse(Console.ReadLine(), out case_Id))
                {
                    Console.WriteLine("Please Enter a valid numerical value!");
                    Console.Write("Case Id: ");
                }

                Console.Write("Lawyer Id: ");
                int case_LId;

                while (!int.TryParse(Console.ReadLine(), out case_LId))
                {
                    Console.WriteLine("Please Enter a valid numerical value!");
                    Console.Write("Lawyer Id: ");
                }

                Console.Write("Customer Id: ");
                int case_CId;

                while (!int.TryParse(Console.ReadLine(), out case_CId))
                {
                    Console.WriteLine("Please Enter a valid numerical value!");
                    Console.Write("Customer Id: ");
                }


                Console.Write("Total charges (DKK): ");
                int case_Charges;

                while (!int.TryParse(Console.ReadLine(), out case_Charges))
                {
                    Console.WriteLine("Please Enter a valid numerical value!");
                    Console.Write("Total charges (DKK): ");
                }

                Console.Write("Start date: (e.g. 15-12-2020): ");
                DateTime case_Start;

                while (!DateTime.TryParseExact(Console.ReadLine(), "d-M-yyyy", null, DateTimeStyles.None, out case_Start))
                {
                    Console.WriteLine("Wrong Value, try again: ");
                    Console.Write("Start date: (e.g. 15-12-2020): ");
                }

                Console.Write("Case type (Corporate = 0, Family = 1, Criminal = 2): ");
                int case_Spe;

                // create a list of lawyers id with a specialization 
                ESpecialization case_LSpec = 0;
                foreach (Lawyer element in lawyers)
                {
                    if (element.Id == case_LId)
                    {
                        case_LSpec = element.Specialization;
                        break;
                    }
                }

                while (!(int.TryParse(Console.ReadLine(), out case_Spe) && (case_Spe >= 0 && case_Spe < 3)))
                {
                    Console.WriteLine("Wrong Value, try again: ");
                    Console.Write("Case type (Corporate = 0, Family = 1, Criminal = 2): ");
                }

                if ((ESpecialization)case_Spe == case_LSpec)
                {
                    Case newCase = new Case(case_Id, case_CId, (ESpecialization)case_Spe, case_Start, case_Charges, case_LId);
                    Cases.Add(newCase);
                    Console.WriteLine($"Case with ID {case_Id} has been added");
                    caseCounter++;
                }
                else
                {
                    Console.WriteLine($"Error: This lawyer is not specialized in {(ESpecialization)case_Spe} cases. Please try creating a case again");
                    AddNewCase(Staffs);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
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

        // method for testing purposes
        public void initAppointment()
        {
            try
            {
                string apointemnDate = "11-12-2020, 13:00";
                DateTime oApointemnDate = DateTime.ParseExact(apointemnDate, "d-M-yyyy, H:m", null);

                string apointemnDate2 = "11-12-2020, 14:00";
                DateTime oApointemnDate2 = DateTime.ParseExact(apointemnDate2, "d-M-yyyy, H:m", null);

                Appointment newDummyAppointmentAqua = new Appointment(1, 1, oApointemnDate, EMeetingRoom.Aquarium);
                Appointments.Add(newDummyAppointmentAqua);
                appointmentCounter++;

                Appointment newDummyAppointmentAqua2 = new Appointment(1, 1, oApointemnDate2, EMeetingRoom.Aquarium);
                Appointments.Add(newDummyAppointmentAqua2);
                appointmentCounter++;

                Appointment newDummyAppointmentCube = new Appointment(2, 2, oApointemnDate, EMeetingRoom.Cube);
                Appointments.Add(newDummyAppointmentCube);
                appointmentCounter++;

                Appointment newDummyAppointmentCave = new Appointment(3, 3, oApointemnDate, EMeetingRoom.Cave);
                Appointments.Add(newDummyAppointmentCave);
                appointmentCounter++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
        }

        public void Process()
        {
            try
            {
                instantiateLawyers(Staffs, "/users/viki/desktop/c#/exam_data/", "lawyers.csv");
                instantiateAdministrative(Staffs, "/users/viki/desktop/c#/exam_data/", "administrative.csv");
                instantiateReceptionist(Staffs, "/users/viki/desktop/c#/exam_data/", "receptionist.csv");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }

            initAppointment();

            try
            {
                Menu(Login());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured: {ex.Message}");
            }
        }
    }
}
