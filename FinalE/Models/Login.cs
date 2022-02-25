using System;
using System.ComponentModel.DataAnnotations;

namespace FinalE.Models
{ 

    public class Login
    {
        [Required(ErrorMessage = "Please enter a valid email")]
        [EmailAddress]
        public string LoginEmail {get;set;}

        [Required(ErrorMessage = "Please enter a valid password")]
        [DataType(DataType.Password)]
        public string LoginPassword {get;set;}

    }
}