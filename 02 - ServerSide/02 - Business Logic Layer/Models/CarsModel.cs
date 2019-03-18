
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CarIsYourHome
{
    //Creating a car model for the WebApi (this class is different then the original entity framework class
    public class CarsModel 
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Missing Type Id")]
        [IsTypeExist(ErrorMessage ="Car type does not exist...")]
        public int typeid { get; set; }

        [Required(ErrorMessage = "Missing Branch Id")]
        [IsBranchExist(ErrorMessage = "Branch does not exist...")]
        public int branchid { get; set; }

        [Required(ErrorMessage = "Missing license plate")]
        [MaxLength(7, ErrorMessage = "License Plate must be Exactly 7 charechters")]
        [MinLength(7, ErrorMessage = "License Plate must be Exactly 7 charechters")]
        public string license_plate { get; set; }

        [Required(ErrorMessage = "Missing mileage")]
        public decimal mileage { get; set; }

        [Required(ErrorMessage = "Missing status")]
        [Statuscontent]
        public string status { get; set; }

        public decimal? dailycost { get; set; }

        [Required(ErrorMessage = "Missing available")]
        [Availablecontent]
        public string available { get; set; }
                
        public string manufacture { get; set; }

        public string model { get; set; }

        public decimal? daily_delay_cost { get; set; }

        public int? year { get; set; }

        [TransmissionContent]
        public string transmission { get; set; }

        public string address { get; set; }

        [Range(-180, 180, ErrorMessage = "Longitude must be a number between -180 to 180")]                  
        public decimal? longitude { get; set; }

        [Range(-90, 90, ErrorMessage = "Latitude must be a number between -180 to 180")]
        public decimal? latitude { get; set; }


          }
}
