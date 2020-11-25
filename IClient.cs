using System;
using System.Collections.Generic;

namespace ExamProgramming
{
    public interface IClient
    {
        string AddNewClient(int id, string name, DateTime dob, ESpecialization specialization, string street, int zip, string city);
        List<Client> ListClients(List<Client> clients);

    }
}
