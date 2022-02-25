using System;
using System.ComponentModel.DataAnnotations;

public class GTZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((int)value < (int)1)
                return new ValidationResult("Calories must be greater than 0");
            return ValidationResult.Success;
        }
    }