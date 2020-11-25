using System;
using System.Collections.Generic;

namespace ExamProgramming
{
    public interface ICase
    {
        List<Case> ListCases(List<Case> cases);
        string AddNewCase(int id, int customerId, ESpecialization caseType, DateTime startDate, int totalCharges, int lawyerId);
    }
}
