using System;
namespace ExamProgramming
{
    public class Appointment
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime DateTime { get; set; }
        public EMeetingRoom MeetingRoom { get; set; }

        public Appointment(int id, int clientId, DateTime dateTime, EMeetingRoom meetingRoom)
        {
            Id = id;
            ClientId = clientId;
            DateTime = dateTime;
            MeetingRoom = meetingRoom;
        }
    }
}
