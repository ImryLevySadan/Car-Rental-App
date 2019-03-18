using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarIsYourHome
{
    class IsCarIdExistAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToString() == null || value.ToString() == "")
            {
                return ValidationResult.Success;
            }
            CarsLogic logic = new CarsLogic();
            if (logic.IsCarIdExist(int.Parse(value.ToString())))
                return ValidationResult.Success;
            return new ValidationResult("Car Id does not exist");
        }

    }
}
