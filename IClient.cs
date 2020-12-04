using System;
using System.Collections.Generic;

namespace ExamProgramming
{
    public interface IClient
    {
        // removed the  parameters form AddNewClient() as they will be retrieved from within the method
        void AddNewClient();
        // probably just a void as it returns the clients listed
        void ListClients(List<Client> clients);
    }
}
