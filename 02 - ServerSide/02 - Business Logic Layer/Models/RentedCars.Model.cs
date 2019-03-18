using System;
using System.ComponentModel.DataAnnotations;


namespace CarIsYourHome
{
    public class RentedCarsModel :BaseLogic
    {
        public int? id { get; set; }

        [Required]
        [IsCarIdExist]
        public int carid { get; set; }

        [Required(ErrorMessage = "License plate nubmer is missing...")]
        [IsLicensePlateExist(ErrorMessage = "License plate number does not exist...")]
        public string licenseplate { get; set; }

        [Required(ErrorMessage = "Rental start date is missing...")]
        public System.DateTime start { get; set; }

        [Required(ErrorMessage = "Rental return date is missing...")]
        public System.DateTime returndate { get; set; }

        public Nullable<System.DateTime> actual_return { get; set; }

      [Required(ErrorMessage = "User ID is missing...")]
        public int? userid { get; set; }

     //   [Required(ErrorMessage = "Full name is missing...")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "your name must incluse only a-z and A_Z charachters")]
        public string fullname { get; set; }

     //   [Required(ErrorMessage = "User Name address is missing...")]
        public string username { get; set; }

       // [Required(ErrorMessage = "User Id number is missing...")]
        [MaxLength(9, ErrorMessage = "Id must has 9 charachters max...")]
        [MinLength(8, ErrorMessage = "Id must has 8 charachters min...")]
        [IsIsraeliIdValid(ErrorMessage = "ID number is not valid by Israeli rules")]
        public string idnumber { get; set; }

       // [Required(ErrorMessage = "Email address is missing...")]
        [EmailAddress(ErrorMessage = "Email must be in AAAAA@BBB.CCC format")]
        public string email { get; set; }

       // [Required(ErrorMessage = "User Description is missing...")]
        [DescriptionExist(ErrorMessage = "User description must be defined")]
        public string description { get; set; }

       // [Required(ErrorMessage = "Daily cost is missing...")]
        public decimal dailycost { get; set; }

       // [Required(ErrorMessage = "Daily delay cost is missing...")]
        public decimal dailydelaycost { get; set; }


    }
}
