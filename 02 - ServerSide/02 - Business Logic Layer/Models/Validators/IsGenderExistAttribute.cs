using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarIsYourHome
{
    class IsGenderExistAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value == null || value.ToString() == "")
                return ValidationResult.Success;

            Regex regexStatus1 = new Regex("Male");
            Regex regexStatus2 = new Regex("Female");
            Regex regexStatus3 = new Regex("No Gender");

            if (regexStatus1.IsMatch(value.ToString()) || regexStatus2.IsMatch(value.ToString()) || regexStatus3.IsMatch(value.ToString()))

                return ValidationResult.Success;
            return new ValidationResult("User Gender must be a Male, Female or No Gender");

        }

    }
}
