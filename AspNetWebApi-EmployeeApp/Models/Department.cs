using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetWebApi_EmployeeApp.Models
{

    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}