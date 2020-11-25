﻿using System;
namespace ExamProgramming
{
    // this class stores administrative staff members (3 in total)
    public class Staff : Personel
    {
        public Staff(int id, string firstName, string lastName, DateTime joinedOn, string role) : base  (id, firstName, lastName, joinedOn)
        {
            Role = role;
        }
        public string Role { get; set; } 
    }
}
