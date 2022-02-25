using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginRegister.Models
{
    public class Login
    {
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "The Password field is required.")]
        [DataType(DataType.Password)] 
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters!")]
        public string Password { get; set; }
    }
}