using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarIsYourHome
{
    class IsIsraeliIdValidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || value.ToString() == "")
            {
                return ValidationResult.Success;
            }
            UsersLogic logic = new UsersLogic();
            if (logic.IsUserIdValid(value.ToString()))
                return ValidationResult.Success;
            return new ValidationResult("Id Number is Ileagal");
        }


    }

}

