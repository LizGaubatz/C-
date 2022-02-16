using System;
using System.ComponentModel.DataAnnotations;

namespace DojoSurvey.Models
{
    public class Survey
    {
        [Required(ErrorMessage=" Name is required...")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long...")]
        public string Name {get;set;}

        [Required(ErrorMessage=" Select atleast one option for location...")]
        public string Location {get; set;}

        [Required(ErrorMessage=" Select atleast one option for favorite language...")]
        public string Language {get;set;}
        
        [MinLength(20, ErrorMessage = "Comments are optional, but if comments are entered it must be 20 characters long...")]
        public string Comments {get;set;}
    }
}