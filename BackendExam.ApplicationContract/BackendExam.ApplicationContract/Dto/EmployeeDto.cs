﻿using BackendExam.ApplicationContract.Enums;

namespace BackendExam.ApplicationContract.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string IdentityNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public eWorkType WorkType { get; set; }
    }
}
