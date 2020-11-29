using System;
using System.Collections.Generic;

namespace ExamProgramming
{
    public interface IAppointment
    {
        void AddAppointment();
        void ListAppointment(List<Appointment> appointments);
    }
}