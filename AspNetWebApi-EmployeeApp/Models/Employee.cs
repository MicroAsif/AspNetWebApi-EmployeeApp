using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetWebApi_EmployeeApp.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public int Sallary { get; set; }

        [Required]
        [ForeignKey("Department")]
        public  int DepertmentId { get; set; }
        public Department Department { get; set; }
    }
}