import { Store } from "./store";
import { Action } from "./action";
import { ActionsType } from "./action-type";

export class Reducer {


    public static reduce (oldStore: Store, action: Action) : Store {
        //Functional programming: The function does not change the date.
        //Therefore, oldStore will never be changed. 
        //Also, Everttime the function gets the same data - she will return the same value
        //Exemple - funtion that return the Power of given number
        //Exemp[le - Functionl programming function will never return Random number 
        
        let newStore: Store = {... oldStore}; //Spread operator - Creating a new object
        switch (action.type) {
            case ActionsType.GetAllCars:
                    newStore.cars = action.payload;
                    break;
            case ActionsType.GetOneCar:
                    newStore.car = action.payload;
                    break;
            case ActionsType.AddCar:
                    newStore.cars.push(action.payload);
                    break;
            case ActionsType.UpdateCar:
                    newStore.cars = action.payload;
                    break;        
            case ActionsType.Login:
                    newStore.IsLoogedIn = true;
                    newStore.currentUser = action.payload;
                    break;
            case ActionsType.Logout:                    
                    newStore.IsLoogedIn = false;
                    newStore.currentUser = {description: "Client"};
                    break;
             case ActionsType.AddUser:
                    newStore.users.push(action.payload);
                    break;
              case ActionsType.GetOneUser: 
                    newStore.users = action.payload;
                    break;
                case ActionsType.GetAllSerchedCars: 
                    newStore.searchedCars = action.payload;
                    break;
                case ActionsType.GetChosenCar: 
                    newStore.CarforRent = action.payload;
                    break;
                case ActionsType.GetAllCarTypes:
                      newStore.CarTypes = action.payload;
                      break;
                case ActionsType.GetAllCarManufacturers:
                      newStore.manufacturers = action.payload;
                      break;
                case ActionsType.GetCarTypesByManufacture:
                      newStore.CarTypes = action.payload;
                      break;
                 case ActionsType.DeleteCar:
                      newStore.cars = action.payload;
                      break;



        }


        return newStore;

        



    }
}