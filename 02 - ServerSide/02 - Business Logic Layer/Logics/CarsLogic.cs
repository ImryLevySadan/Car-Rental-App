using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace CarIsYourHome
{
    //In this Class: All function that is about The cars
    public class CarsLogic : BaseLogic
    {
        //Car List section - authorization: manager


        // This function return all Company's Cars
        public List<CarsModel> GetAllCars()
        {
            return DB.Cars_Lists.Select(car => new CarsModel
            {
                id = car.Car_ID,
                typeid = car.Type_ID,
                branchid = (int)car.Branch_ID,
                license_plate = car.License_Plate,
                mileage = car.Mileage,
                year = car.Cars_Types.Year,
                status = car.Status,
                available = car.Available,
                manufacture = car.Cars_Types.Manufacture,
                model = car.Cars_Types.Model,
                dailycost = car.Cars_Types.Daily_Cost,
                daily_delay_cost = car.Cars_Types.Daily_Delay_Cost,
                transmission = car.Cars_Types.Transmission,
                address = car.Branch.Address,
                longitude = car.Branch.Longitude,
                latitude = car.Branch.Latitude


            }).ToList();
        }

        // This function Returns One Car by provided id
        public CarsModel GetCarById(int id)
        {
            return DB.Cars_Lists.Where(car => car.Car_ID == id).Select(car => new CarsModel
            {
                id = car.Car_ID,
                typeid = car.Type_ID,
                branchid = car.Branch.Branch_ID,
                license_plate = car.License_Plate,
                mileage = car.Mileage,
                year = car.Cars_Types.Year,
                status = car.Status,
                available = car.Available,
                manufacture = car.Cars_Types.Manufacture,
                model = car.Cars_Types.Model,
                dailycost = car.Cars_Types.Daily_Cost,
                daily_delay_cost = car.Cars_Types.Daily_Delay_Cost,
                transmission = car.Cars_Types.Transmission,
                address = car.Branch.Address,
                longitude = car.Branch.Longitude,
                latitude = car.Branch.Latitude



            }).SingleOrDefault();
        }

       
        //This function add a car to the car list and return the new car object that was added to the data base
        public CarsModel AddCarToCarList(CarsModel car)
        {
            Cars_List newcar = new Cars_List
            {
                Type_ID = car.typeid,
                License_Plate = car.license_plate,
                Mileage = car.mileage,
                Status = car.status,
                Available = car.available,
                Branch_ID = car.branchid

            };

            DB.Cars_Lists.Add(newcar);
            DB.SaveChanges();

            return GetCarById(newcar.Car_ID);

        }

        //This function update a car from the Car list Table at the Data base
        public CarsModel UpdateCarInCarList(CarsModel car)
        {
            Cars_List changedcar = new Cars_List();
            changedcar.Car_ID = car.id;
            changedcar.Type_ID = car.typeid;
            changedcar.License_Plate = car.license_plate;
            changedcar.Mileage = car.mileage;
            changedcar.Status = car.status;
            changedcar.Available = car.available;
            changedcar.Branch_ID = car.branchid;
            //Attach allows to change the Entity without changing the Data Base
            // The changes will be saved only after the "save changes" meothode
            DB.Cars_Lists.Attach(changedcar);
            //Updating the Entity state to modified and save the changes
            //Modified means: "the entity is being tracked by the context and exists in the database, 
            //and some or all of its property values have been modified"
            DB.Entry(changedcar).State = EntityState.Modified;
            DB.SaveChanges();
            return GetCarById(changedcar.Car_ID);

        }

        //This function delete a car from the Car list Table at the Data base
        public void DeleteCarFromCarList(int id)
        {
            Cars_List car = new Cars_List { Car_ID = id };
            DB.Cars_Lists.Attach(car);
            if (car == null)
                return;
            DB.Cars_Lists.Remove(car);
            DB.SaveChanges();
        }

        //Car Type section  - authorization: manager

        //Their is similarity between the function in this section and in the previous one,
        // so, the documentation includes only new function
        public List<CarTypeModel> GetAllCarTypes()
        {
            return DB.Cars_Types.Select(type => new CarTypeModel
            {
                id = type.Type_ID,
                manufacture = type.Manufacture,
                model = type.Model,
                year = type.Year,
                transmission = type.Transmission,
                dailycost = type.Daily_Cost,
                dailydelaycost = type.Daily_Delay_Cost

            }).ToList();
        }

        public List<CarTypeModel> GetAllCarManufacturers()
        {
            return DB.Cars_Types.Select(type => new CarTypeModel
            {
                manufacture = type.Manufacture                

            }).Distinct().ToList();
        }


        public CarTypeModel GetCarTypesById(int id)
        {
            return DB.Cars_Types.Where(type => type.Type_ID == id).Select(type => new CarTypeModel
            {
                id = type.Type_ID,
                manufacture = type.Manufacture,
                model = type.Model,
                dailycost = type.Daily_Cost,
                dailydelaycost = type.Daily_Delay_Cost,
                year = type.Year,
                transmission = type.Transmission
            }).SingleOrDefault();

        }

        public List<CarTypeModel> GetCarTypesByManufacture(string manufacture)
        {
            return DB.Cars_Types.Where(type => type.Manufacture == manufacture).Select(type => new CarTypeModel
            {
                id = type.Type_ID,
                manufacture = type.Manufacture,
                model = type.Model,
                dailycost = type.Daily_Cost,
                dailydelaycost = type.Daily_Delay_Cost,
                year = type.Year,
                transmission = type.Transmission
            }).ToList();
        
        }
    
        public CarTypeModel AddCarType(CarTypeModel type)
        {
            Cars_Type newtype = new Cars_Type
            {
                Manufacture = type.manufacture,
                Model = type.model,
                Year = type.year,
                Transmission = type.transmission,
                Daily_Cost = type.dailycost,
                Daily_Delay_Cost = type.dailydelaycost

            };

            DB.Cars_Types.Add(newtype);
            DB.SaveChanges();
            return GetCarTypesById(newtype.Type_ID);

        }

        public CarTypeModel UpdateCarType(CarTypeModel type)
        {
            Cars_Type changedType = new Cars_Type();
            changedType.Manufacture = type.manufacture;
            changedType.Model = type.model;
            changedType.Year = type.year;
            changedType.Transmission = type.transmission;
            changedType.Daily_Cost = type.dailycost;
            changedType.Daily_Delay_Cost = type.dailydelaycost;

            DB.Cars_Types.Attach(changedType);
            DB.Entry(changedType).State = EntityState.Modified;
            DB.SaveChanges();

            return GetCarTypesById(changedType.Type_ID);
        }

        public void DeleteCarType(int id)
        {
            Cars_Type type = new Cars_Type { Type_ID = id };
            DB.Cars_Types.Attach(type);
            if (type == null)
                return;
            DB.Cars_Types.Remove(type);
            DB.SaveChanges();
        }


        //Rented Car section - authorization: manager and employee

        public List<RentedCarsModel> GetAllRentedCars()

        {
            return DB.Rented_Cars.Select(car => new RentedCarsModel
            {
                carid = car.Car_ID,
                licenseplate = car.License_Plate,
                start = car.Start,
                returndate = car.Return,
                actual_return = car.Actual_Return,
                userid = car.User_ID,
                fullname = car.User.Full_Name,
                username = car.User.User_Name,
                idnumber = car.User.ID_Number,
                email = car.User.Email,
                description = car.User.Description,
                dailycost = car.Cars_List.Cars_Types.Daily_Cost,
                dailydelaycost = car.Cars_List.Cars_Types.Daily_Delay_Cost


            }).ToList();
        }

        public RentedCarsModel GetRentedCarById(int id)
        {
            return DB.Rented_Cars.Where(car => car.Rent_ID == id).Select(car => new RentedCarsModel
            {
                carid = car.Car_ID,
                licenseplate = car.License_Plate,
                start = car.Start,
                returndate = car.Return,
                actual_return = car.Actual_Return,
                userid = car.User_ID,
                fullname = car.User.Full_Name,
                username = car.User.User_Name,
                idnumber = car.User.ID_Number,
                email = car.User.Email,
                description = car.User.Description,
                dailycost = car.Cars_List.Cars_Types.Daily_Cost,
                dailydelaycost = car.Cars_List.Cars_Types.Daily_Delay_Cost

            }).SingleOrDefault();
        }

        // This function Returns One Car by provided id
        public RentedCarsModel GetRentedCarByLicensePlate(RentedCarsModel RentalDetails)
        {
            return DB.Rented_Cars.Where(car => car.License_Plate == RentalDetails.licenseplate && car.User.ID_Number == RentalDetails.idnumber && car.Actual_Return == null).Select(car => new RentedCarsModel
            {
                id = car.Rent_ID,
                carid = car.Car_ID,
                licenseplate = car.License_Plate,
                start = car.Start,
                returndate = car.Return,
                actual_return = car.Actual_Return,
                userid = car.User_ID,
                fullname = car.User.Full_Name,
                username = car.User.User_Name,
                idnumber = car.User.ID_Number,
                email = car.User.Email,
                description = car.User.Description,
                dailycost = car.Cars_List.Cars_Types.Daily_Cost,
                dailydelaycost = car.Cars_List.Cars_Types.Daily_Delay_Cost

            }).SingleOrDefault();
        }

        public RentedCarsModel AddRentedCar(RentedCarsModel newCar)
        {
            
           Rented_Car car = new Rented_Car
            {
                Car_ID = newCar.carid,
                License_Plate = newCar.licenseplate,
                Start = newCar.start,
                Return = newCar.returndate,
                Actual_Return = newCar.actual_return,
                User_ID = newCar.userid
            };

            DB.Rented_Cars.Add(car);
            DB.SaveChanges();

            return GetRentedCarById(car.Rent_ID);

        }

        public RentedCarsModel UpdateRentedCarById(RentedCarsModel updatedCar)
        {
            Rented_Car car = new Rented_Car();
            car.Rent_ID = (int)updatedCar.id;
            car.Car_ID = updatedCar.carid;
            car.License_Plate = updatedCar.licenseplate;
            car.Start = updatedCar.start;
            car.Return = updatedCar.returndate;
            car.Actual_Return = updatedCar.actual_return;
            car.User_ID = updatedCar.userid;

            DB.Rented_Cars.Attach(car);
            DB.Entry(car).State = EntityState.Modified;
            DB.SaveChanges();

            return GetRentedCarById(car.Rent_ID);

        }

        public RentedCarsModel updateReturnedCar(RentedCarsModel updatedCar)
        {

            DateTime today = DateTime.UtcNow.Date;
            updatedCar.actual_return = today;

            Rented_Car car = new Rented_Car();
            car.Rent_ID = (int)updatedCar.id;
            car.Car_ID = updatedCar.carid;
            car.License_Plate = updatedCar.licenseplate;
            car.Start = updatedCar.start;
            car.Return = updatedCar.returndate;
            car.Actual_Return = updatedCar.actual_return;
            car.User_ID = updatedCar.userid;

            DB.Rented_Cars.Attach(car);
            DB.Entry(car).State = EntityState.Modified;
            DB.SaveChanges();

            return GetRentedCarById(car.Rent_ID);

        }


        public void DeletRentedCarById(int id)
        {
            Rented_Car car = new Rented_Car { Rent_ID = id };
            DB.Rented_Cars.Attach(car);
            if (car == null)
                return;
            DB.Rented_Cars.Remove(car);
            DB.SaveChanges();
        }

        //The search and calculation Section - authorization: All users

        //The next three function ar doing a multiparameters search
        //The first function recieve input with a general search object
        //The function checks matching by using to other functions
        // CarFit checks for each of the search parameters
        // checkCarsAvailabiltybyDates checking the dates

        public List<SearchedCarsModel> GetCarsByCLientChoise(SearchedCarsModel searchedCar)
        {
            //The Dictionary initialized only the not-null values in th searchedCar object
            // The key parameter helps us to check if the specifiec car is in the data base
            
            Dictionary<string, string> SearchParamters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(searchedCar.manufacture))
                SearchParamters.Add("Manufacture", searchedCar.manufacture);
            if (!string.IsNullOrEmpty(searchedCar.model))
                SearchParamters.Add("Model", searchedCar.model);
            if (!string.IsNullOrEmpty(searchedCar.transmission))
                SearchParamters.Add("Transmission", searchedCar.transmission);
            if (searchedCar.year != null)
                SearchParamters.Add("Year", searchedCar.year.ToString());
            if (searchedCar.start != null && searchedCar.returndate != null)
            {
                SearchParamters.Add("start", searchedCar.start.ToString());
                SearchParamters.Add("returndate", searchedCar.returndate.ToString());
            }
            //The "asEnumerable" is requires because we need to custome functions that linq does not support otherwise
            var query = DB.Rented_Cars.Select(rent => rent).AsEnumerable();
            
            //This line is a different way to do select on the result from the rental cars table
            query = query.GroupBy(rent => rent.Car_ID).Select(rent => rent.FirstOrDefault());

            //CarsFit gets one raw from the "Where" clause, and get the Dictionary list with the search paramteres
            query = query.Where(rent => FindCarsFit(rent, SearchParamters));

            if (query.Count() == 0)
                return null;
            return query.Select(car => new SearchedCarsModel
            {
                rentid = car.Rent_ID,
                carid = car.Car_ID,
                typeid = car.Cars_List.Cars_Types.Type_ID,
                manufacture = car.Cars_List.Cars_Types.Manufacture,
                model = car.Cars_List.Cars_Types.Model,
                transmission = car.Cars_List.Cars_Types.Transmission,
                year = car.Cars_List.Cars_Types.Year,
                Status = car.Cars_List.Status,
                Address = car.Cars_List.Branch.Address,
                Longitude = car.Cars_List.Branch.Longitude,
                Latitude = car.Cars_List.Branch.Latitude,
                start = car.Start,
                returndate = car.Return
            }).ToList();

        }

        public bool FindCarsFit(Rented_Car rent, Dictionary<string, string> searchparam)
        {
            //The Foreach loop go through all the search paramters
            foreach (var pararm in searchparam)
            {
                string key = pararm.Key.ToString();
                string value = pararm.Value.ToString();

                //The Kew is the name of the paramter, like "model"
                switch (key)
                {
                    case "Manufacture":
                        if (rent.Cars_List.Cars_Types.Manufacture.Trim() != value)
                            return false;
                        break;
                    case "Model":
                        if (rent.Cars_List.Cars_Types.Model.Trim() != value)
                            return false;
                        break;
                    case "Transmission":
                        if (rent.Cars_List.Cars_Types.Transmission.Trim() != value)
                            return false;
                        break;
                    case "Year":
                        if (rent.Cars_List.Cars_Types.Year != Convert.ToInt32(value))
                            return false;
                        break;
                    case "start":
                        //The dates gets another function beacause of the complexity of the date search
                        //the function gets the raw that is being checked by the previous function, and runs 
                        // the test on all the raws with the same car id
                                     
                        if (!checkCarsAvailabiltybyDates(rent, searchparam["start"], searchparam["returndate"]))
                        return false;
                        break;
                   default:
                        break;
                }


            }
            return true;

        }

        private bool checkCarsAvailabiltybyDates(Rented_Car rentToCheck, string startdate, string returndate)
        {
                       
            DateTime startRentalDate = DateTime.Parse(startdate);
            DateTime returnDate = DateTime.Parse(returndate);
            int carid = rentToCheck.Car_ID;
            if (DB.Rented_Cars.Where(rent => rent.Car_ID == carid).All(car => startRentalDate > car.Return || returnDate < car.Start))
                    return true;
            return false;
                            
        }

        //This function calculate the final price for a specifiefic Car Type
        public decimal[] CalculateRentCost(SearchedCarsModel car)
        {
            TimeSpan span = new TimeSpan();
            if (car.start != null && car.returndate != null)
                span = car.returndate - car.start;
            decimal DailyCost = 0;
            car.dailycost = DB.Cars_Types.Where(type => type.Type_ID == car.typeid).Select(type => type.Daily_Cost).SingleOrDefault();
            if (car.dailycost != null)
            {
                DailyCost = (decimal)car.dailycost;
            }
            decimal TotalCost = (decimal)span.TotalDays * DailyCost;
            decimal DailyDelayCost = 0;
            car.dailydelaycost = DB.Cars_Types.Where(type => type.Type_ID == car.typeid).Select(type => type.Daily_Delay_Cost).SingleOrDefault();

            if (car.dailydelaycost != null)
                   { DailyDelayCost = (decimal)car.dailydelaycost; }
            decimal[] TotalAndDelayCose = new decimal[2];
            TotalAndDelayCose[0] = TotalCost;
            TotalAndDelayCose[1] = DailyDelayCost;
            return TotalAndDelayCose;
        }

        public decimal[] CalculateRentalFinalCost (RentedCarsModel car)
        {
            DateTime today = DateTime.UtcNow.Date;
           
            TimeSpan InRangeSpan = new TimeSpan();
            if (car.start != null && car.returndate != null)
                InRangeSpan = car.returndate - car.start;
            decimal DailyCost = 0;
            decimal DailyDelayCost = 0;

            DailyCost = car.dailycost;
            decimal InRangeCost = (decimal)InRangeSpan.TotalDays * DailyCost;

                if (today > car.returndate)
            {

                TimeSpan DelaySpan = new TimeSpan();               
                DelaySpan = (today - car.returndate);
                DailyDelayCost = car.dailydelaycost * (decimal)DelaySpan.TotalDays;
            

            }
                
            decimal[] TotalAndDelayCost = new decimal[2];
            TotalAndDelayCost[0] = InRangeCost;
            TotalAndDelayCost[1] = DailyDelayCost;
            return TotalAndDelayCost;
        }


        // Validation Section

        public bool IsTypeIdExist(int typeid)
        {

          return DB.Cars_Types.Any(car => car.Type_ID == typeid);
        }

        public bool IsBranchExist(int branchid)
        {
            return DB.Branches.Any(car => car.Branch_ID == branchid);
        }

        public bool IsCarIdExist(int carId)

        {
            return DB.Cars_Lists.Any(car => car.Car_ID == carId);
        }

        public bool IsLicensePlateExist(string LicensePlate)

        {
            return DB.Cars_Lists.Any(car => car.License_Plate == LicensePlate);
        }





    }
}


