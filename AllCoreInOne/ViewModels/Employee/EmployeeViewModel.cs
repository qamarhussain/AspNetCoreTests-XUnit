using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllCoreInOne.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Department")]
        public Guid DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
}
