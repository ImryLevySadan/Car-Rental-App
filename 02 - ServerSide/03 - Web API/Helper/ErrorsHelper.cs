using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace CarIsYourHome
{
    static class ErrorsHelper
    {
        // This class handle the exception messages
        // It uses the Errors class, in the same folder as this one

        // This function return a differnt value for DEBUG mode and release mode
        // The function deals only with Exceptions, not validations
        public static Errors GetErrors (Exception ex)
        {
            Errors errors = new Errors();
#if DEBUG
            errors.AddErrorsMessage(GetMostInnerException(ex));
#else
            errors.AddErrorsMessage("An error occured, please try again");
#endif
            return errors;
        }

        // This function return errors message for validation errors only
        // The function runs on the each property in the model class, an checks for validation wrrors.
        public static Errors GetErrors(ModelStateDictionary modelState)
        {
            Errors errors = new Errors();
            foreach (var prop in modelState.Values)  // values = the illegal value properties
            {
                foreach (var err in prop.Errors) // err = single data annotation error (for each property)
                {
                    errors.AddErrorsMessage(err.ErrorMessage);
                }
            }
            return errors;
        }

        // This recourse function finds the most inner Execption
        private static string GetMostInnerException (Exception ex)
        {
            if (ex.InnerException == null )
            
                return ex.Message;
            
            return GetMostInnerException(ex.InnerException);
        }


    }
}