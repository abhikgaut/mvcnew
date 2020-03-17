using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcnew.Models
{
    public class customDOJ:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime D = Convert.ToDateTime(value);
            DateTime TD = DateTime.Now;
            int age = (int)(TD.Subtract(D).TotalDays / 365);
            if (D > TD)
                return new ValidationResult("date cannot be greater than today age");
            else if (age < 21 || age > 58)
                return new ValidationResult("age must be between 21-58");
            else
                return ValidationResult.Success ;
        }
    }
   
}