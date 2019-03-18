using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarIsYourHome
{
    public class CarTypeModel
    {
        public int? id { get; set; }

        [Required(ErrorMessage ="Manufacture is missing...")]
        public string manufacture { get; set; }

        [Required(ErrorMessage = "Model is missing...")]
        
        public string model { get; set; }

        [Required(ErrorMessage = "Daily Cost is missing...")]
        public decimal dailycost { get; set; }

        [Required(ErrorMessage = "Daily delay cost is missing...")]
        public decimal dailydelaycost { get; set; }

        [Required(ErrorMessage = "Year is missing...")]
        public int year { get; set; }

        [Required(ErrorMessage = "Transmission is missing...")]
        [TransmissionContent]
        public string transmission { get; set; }
    }
}
