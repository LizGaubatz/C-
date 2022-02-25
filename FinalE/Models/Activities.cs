using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalE.Models
{
    public class Activities
    {
        [Key]
        public int ActivityId {get;set;}
        [Required]
        public string Title {get;set;}
        [Required]
        public string Description {get;set;}
        [Required]
        [DataType(DataType.Time)]
        public DateTime ActivityTime {get;set;}
        [Required]
        [PastDate]
        [DataType(DataType.Date)]
        public DateTime ActivityDate {get;set;}
        [Required]
        public int Duration {get;set;}
        [Required]
        public string DurationUnit {get;set;}
        public int UserId {get;set;}
        public User Coordinator {get;set;}
        public List<Participants> Participants {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }

    public class PastDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is DateTime)
            {
                DateTime date = (DateTime)value;
                if(date < DateTime.Now)
                {
                    return new ValidationResult("Date cannot be in the past");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Please enter a valid Date & Time");
            }
        }
    }

}