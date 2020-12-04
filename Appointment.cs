using System;
using System.Text;

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

        public override string ToString()
        {
            StringBuilder textOutput = new StringBuilder();
            textOutput.AppendLine($"\nId: {Id}");
            textOutput.AppendLine($"Client ID: {ClientId}");
            textOutput.AppendLine($"Time: {DateTime}");
            textOutput.AppendLine($"Meeting Room: {MeetingRoom}");
            return textOutput.ToString();
        }
    }
}
