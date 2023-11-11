using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Formvalid
{
    public class DateAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {


            if (value is DateTime dateOfBirth)
            {
                var age = CalculateAge(dateOfBirth);

                if (age < 18)
                {

                    return new ValidationResult($"Age must be at least 18 years.");

                }

            }

            return ValidationResult.Success;
        }


        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.Date)
            {
                age--;
            }

            return age;
        }

    }
}