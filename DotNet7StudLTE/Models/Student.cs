using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DotNet7StudLTE.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string Surname { get; set; } = string.Empty;

        [Display(Name = "Birth Date")]
        [Required]
        public DateTime Birthday { get; set; }

        
        public Department? Department { get; set; }

        [Display(Name = "Department")]
        [Required]
        public int DepartmentID { get; set; }

        [Display(Name = "Department")]
        public string DepartmentName { get; set; } = string.Empty;

    }
}
