using System;
using System.ComponentModel.DataAnnotations;


namespace CarIsYourHome
{
    public class UserModel
    {
        public int? userid { get; set; }

       // [Required(ErrorMessage ="Don't Forget full name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Characters are not allowed.")]
        public string fullname { get; set; }

      //  [Required]
        public string username { get; set; }

        //[Required (ErrorMessage = "Id number is missing...")]
        [MaxLength(9, ErrorMessage = "Id must has 9 charachters max...")]
        [MinLength(8, ErrorMessage = "Id must has 8 charachters min...")]
        [IsIsraeliIdValid(ErrorMessage = "ID number is not valid by Israeli rules")]
        public string idnumber { get; set; }

        
        public Nullable<System.DateTime> birthdate { get; set; }

       // [Required(ErrorMessage = "Forgot to enter gender?")]
        [IsGenderExist(ErrorMessage = "Gender can be only male, female and no gender")]
        public string gender { get; set; }

        //[Required(ErrorMessage = "Email address is missing...")]
        [EmailAddress(ErrorMessage = "Email must be in AAAAA@BBB.CCC format")]
        public string email { get; set; }

        //[Required(ErrorMessage = "Password address is missing...")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,20}$", 
            ErrorMessage = "The password must include at least one number, one lowercase char and one UPPERcase char")]
        public string password { get; set; }

       // [Required(ErrorMessage = "User Description is missing...")]
        [DescriptionExist(ErrorMessage = "User description does not fit the format")]
        public string description { get; set; }
    }
}
