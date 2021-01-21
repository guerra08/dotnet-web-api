using System;
using System.ComponentModel.DataAnnotations;

namespace DotnetWebApi.Models
{
    public class Student
    {
        public long Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime? BirthDate { get; set; }
        [Required]
        [StringLength(9)]
        public string Code { get; set; }

    }
}
