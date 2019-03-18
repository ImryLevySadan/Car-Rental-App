using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarIsYourHome
{
    class IsLicensePlateExistAttribute :ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || value.ToString() == "")
            {
                return ValidationResult.Success;
            }
            CarsLogic logic = new CarsLogic();
            if (logic.IsLicensePlateExist(value.ToString()))
                return ValidationResult.Success;
            return new ValidationResult("Car Type does not exist");
        }

    }
}
