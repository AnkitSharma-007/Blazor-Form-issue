using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorCourseDemo.Models
{
    public class User
    {
        [Required]
        [MinLength(3, ErrorMessage = " The Name must have atlest three characters.")]
        public string Name { get; set; }
        [Required]
        [Range(18, 100, ErrorMessage = " The age must be between 18-100 yrs.")]
        public int Age { get; set; }
        [Required]
        [UserNameValidation]
        public string UserName { get; set; }
    }
}
