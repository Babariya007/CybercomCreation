using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCorePractice.Models
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }
        [Required, MaxLength(10)]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }
        public List<IFormFile> Photo { get; set; }
    }
}
