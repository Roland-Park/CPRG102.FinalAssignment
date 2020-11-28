using System;
using System.Collections.Generic;

#nullable disable

namespace CPRG102.Final.Api.Data
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
