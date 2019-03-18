import { Cars } from "../models/cars";
import { Users } from "../models/users";
import { Search } from "../models/search";
import { Types } from "../models/types";

export class Store {
    public cars: Cars[]; 
    public car: Cars;
    public searchedCars: Search[];
    public CarTypes: Types[]
    public manufacturers: string [];
    public users: Users[];
    public IsLoogedIn: boolean;
    public CarforRent: Cars;
    public currentUser: Users = {};
}