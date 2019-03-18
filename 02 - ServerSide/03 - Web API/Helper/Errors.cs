using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarIsYourHome
{
    public class Errors
    {
        // This property gets all the messages onto one list

        // the property also creats a new object of the list
        public List<string> errors { get; set; } = new List<string>();

        public void AddErrorsMessage (string errorMessage)
        {
            errors.Add(errorMessage);
        }

    }
}