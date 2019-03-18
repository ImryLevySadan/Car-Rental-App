using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarIsYourHome
{
    class StatuscontentAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           
            if (value == null || value.ToString() == "")
                return ValidationResult.Success;

            Regex regexStatus1 = new Regex("Ready");
            Regex regexStatus2 = new Regex("In Repair");

            if (regexStatus1.IsMatch(value.ToString()) || regexStatus2.IsMatch(value.ToString()))
            
                return ValidationResult.Success;
            return new ValidationResult("Car Status has to be: 1.Ready or 2. In repair");
            
        }
    }
}
