using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CPRG102.Final.Roland.UI.HRData
{
    public partial class Employee
    {
        public int Id { get; set; }
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public string FullName 
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
