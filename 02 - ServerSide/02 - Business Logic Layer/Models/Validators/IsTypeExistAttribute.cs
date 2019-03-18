using System.ComponentModel.DataAnnotations;


namespace CarIsYourHome
{
    class IsTypeExistAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToString() == null || value.ToString() == "")
            
                return ValidationResult.Success;
            
            CarsLogic logic  = new CarsLogic();
            if (logic.IsTypeIdExist(int.Parse(value.ToString())))
                return ValidationResult.Success;
            return new ValidationResult("Car Type does not exist");
        }
    }
}
