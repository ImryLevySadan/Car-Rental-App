using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarIsYourHome
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class CarsApiController : ApiController
    {

        private CarsLogic carslogic = new CarsLogic();

        //Cars section - authorization: Manager

        [HttpGet]
        [Route("cars")]
        public HttpResponseMessage GetAllCars ()
        {
            try
            {
              
                List<CarsModel> allCars = carslogic.GetAllCars();
                return Request.CreateResponse(HttpStatusCode.OK, allCars);
            }

            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }

        }

        [HttpGet]
        [Route("cars/{id}")]
        public HttpResponseMessage GetCarById (int id)
        {
            try
            {   
                CarsModel car = carslogic.GetCarById(id);
                return Request.CreateResponse(HttpStatusCode.OK, car);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
            
        }

        [HttpPost]
        [Route("cars")]
        public HttpResponseMessage AddCarToCarList ([FromBody] CarsModel car)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Errors errors = ErrorsHelper.GetErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }

                CarsModel newCar = carslogic.AddCarToCarList(car);
                return Request.CreateResponse(HttpStatusCode.Created, newCar);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
           
        }

        [HttpPut]
        [Route("cars/{id}")]
        public HttpResponseMessage UpdateCarInCarList(int id, [FromBody] CarsModel car)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Errors errors = ErrorsHelper.GetErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }
                car.id = id;
                CarsModel updatedCar = carslogic.UpdateCarInCarList(car);
                return Request.CreateResponse(HttpStatusCode.OK, updatedCar);
            }

            catch (Exception ex)

            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
        }
            

        [HttpDelete]
        [Route("cars/{id}")]
        public HttpResponseMessage DeleteCarFromCarList (int id)
        {
            try
            {
                
                carslogic.DeleteCarFromCarList(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }

            
        }

        //CarTypes section - authorization: Manager

        [HttpGet]
        [Route("cartypes")]
        public HttpResponseMessage GetAllCarTypes()
        {
            try
            {
                List<CarTypeModel> allCars = carslogic.GetAllCarTypes();
                return Request.CreateResponse(HttpStatusCode.OK, allCars);
            }

            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
           
        }

        [HttpGet]
        [Route("carManufacturers")]
        public HttpResponseMessage GetAllCarManufacturers()
        {
            try
            {
                List<CarTypeModel> allCarsManufactuers = carslogic.GetAllCarManufacturers();
                return Request.CreateResponse(HttpStatusCode.OK, allCarsManufactuers);
            }

            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }

        }

        [HttpGet]
        [Route("cartypes/{id}")]
        public HttpResponseMessage GetCarTypesById(int id)
        {
            try
            {
                CarTypeModel car = carslogic.GetCarTypesById(id);
                return Request.CreateResponse(HttpStatusCode.OK, car);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
            
        }

        
        [HttpPost]
        [Route("cartypes")]
        public HttpResponseMessage AddCarType([FromBody] CarTypeModel car)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Errors errors = ErrorsHelper.GetErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }
                CarTypeModel newCAr = carslogic.AddCarType(car);
                return Request.CreateResponse(HttpStatusCode.Created, newCAr);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
            
        }

        [HttpGet]
        [Route("TypesByManufacture/{manufacture}")]
        public HttpResponseMessage GetCarTypesByManufacture(string manufacture)
        {
            try
            {
                List<CarTypeModel> car = carslogic.GetCarTypesByManufacture(manufacture);
                return Request.CreateResponse(HttpStatusCode.OK, car);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }

        }

        [HttpPut]
        [Route("cartypes/{id}")]
        public HttpResponseMessage UpdateCarType(int id, [FromBody] CarTypeModel car)
        {
            if (!ModelState.IsValid)
            {
                Errors errors = ErrorsHelper.GetErrors(ModelState);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
            car.id = id;
            CarTypeModel updatedCar = carslogic.UpdateCarType(car);
            return Request.CreateResponse(HttpStatusCode.OK, updatedCar);
        }

        [HttpDelete]
        [Route("cartypes/{id}")]
        public HttpResponseMessage DeleteCarType(int id)
        {
            try
            {
              
                carslogic.DeleteCarType(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
            
        }

        //Rented Car section - authorization: manager and employee

        [HttpGet]
        [Route("RentedCars")]
        public HttpResponseMessage GetAllRentedCars()
        {
            try
            {
                List<RentedCarsModel> allCars = carslogic.GetAllRentedCars();
                return Request.CreateResponse(HttpStatusCode.OK, allCars);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
            
        }

        [HttpGet]
        [Route("RentedCars/{id}")]
        public HttpResponseMessage GetRentedCarById(int id)
        {
            try
            {
                
                RentedCarsModel car = carslogic.GetRentedCarById(id);
                return Request.CreateResponse(HttpStatusCode.OK, car);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
            
        }

        [HttpPost]
        [Route("returnedCar")]
        public HttpResponseMessage GetRentedCarByLicensePlate([FromBody] RentedCarsModel RentalDetails)
        {
            try
            {
                RentedCarsModel car = carslogic.GetRentedCarByLicensePlate(RentalDetails);
                return Request.CreateResponse(HttpStatusCode.OK, car);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }

        }

        [HttpPost]
        [Route("RentedCars")]
        public HttpResponseMessage AddRentedCar([FromBody] RentedCarsModel car)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Errors errors = ErrorsHelper.GetErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }
                RentedCarsModel newCAr = carslogic.AddRentedCar(car);
                return Request.CreateResponse(HttpStatusCode.Created, newCAr);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
           
        }

        [HttpPut]
        [Route("RentedCars/{id}")]
        public HttpResponseMessage updateRentedCar(int id, [FromBody] RentedCarsModel car)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Errors errors = ErrorsHelper.GetErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }
                car.id = id;
                RentedCarsModel updatedCar = carslogic.UpdateRentedCarById(car);
                return Request.CreateResponse(HttpStatusCode.OK, updatedCar);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
           
        }

        [HttpPut]
        [Route("ReturnedRentedCar/{id}")]
        public HttpResponseMessage updateReturnedCar(int id, [FromBody] RentedCarsModel car)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Errors errors = ErrorsHelper.GetErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }
                car.id = id;
                RentedCarsModel updatedCar = carslogic.updateReturnedCar(car);
                return Request.CreateResponse(HttpStatusCode.OK, updatedCar);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }

        }

        [HttpDelete]
        [Route("RentedCars/{id}")]
        public HttpResponseMessage DeleteRentedCar(int id)
        {
            try
            {
              
                carslogic.DeletRentedCarById(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
            
        }

       
        
        //Search and calculation function section - authorization: All users

        [HttpPost]
        [Route("cars/search")]
        public HttpResponseMessage GetCarsByClientChoise([FromBody] SearchedCarsModel searchedCar)
        {
            try
            {
                List<SearchedCarsModel> cars = carslogic.GetCarsByCLientChoise(searchedCar);
                return Request.CreateResponse(HttpStatusCode.OK, cars);
            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
           
        }

        [HttpPost]
        [Route("cars/cost")]
        public HttpResponseMessage CalculateRentCost ([FromBody] SearchedCarsModel car)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Errors errors = ErrorsHelper.GetErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }
                car.typeid = car.typeid;
                decimal[] RentalCosts = carslogic.CalculateRentCost(car);
                return Request.CreateResponse(HttpStatusCode.OK, RentalCosts);

            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
          }

        [HttpPost]
        [Route("Rental/cost")]
        public HttpResponseMessage CalculateRentalFinalCost([FromBody] RentedCarsModel car)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Errors errors = ErrorsHelper.GetErrors(ModelState);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }
                decimal[] RentalCosts = carslogic.CalculateRentalFinalCost(car);
                return Request.CreateResponse(HttpStatusCode.OK, RentalCosts);

            }
            catch (Exception ex)
            {

                Errors error = ErrorsHelper.GetErrors(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
        }


    }
}
