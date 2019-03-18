using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarIsYourHome
{
    public class SearchedCarsModel
    {
        //[IsTypeExist]
        public int? typeid { get; set; }

        public int? rentid { get; set; }

        public int? carid { get; set; }

        public string manufacture { get; set; }
        
        public string model { get; set; }

        public decimal? dailycost { get; set; }

        public decimal? dailydelaycost { get; set; }

        public int? year { get; set; }

        public string Address { get; set; }

        public string Status { get; set; }

        [Range(-180, 180, ErrorMessage = "Longitude must be a number between -180 to 180")]
        public decimal Longitude { get; set; }

        [Range(-90, 90, ErrorMessage = "Latitude must be a number between -180 to 180")]
        public decimal Latitude { get; set; }

        [TransmissionContent]
        public string transmission { get; set; }

        public System.DateTime start { get; set; }

        
        public System.DateTime returndate { get; set; }
    }
}
