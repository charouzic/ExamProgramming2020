using System;
using System.Collections.Generic;

namespace ExamProgramming
{
    public interface IAppointment
    {
        string AddAppointment(int id, int clientId, DateTime dateTime, EMeetingRoom meetingRoom);
        List<Appointment> ListAppointment(List<Appointment> appointments);
    }
}
