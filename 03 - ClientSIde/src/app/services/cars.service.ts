import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cars } from '../models/cars';
import { NgRedux } from 'ng2-redux';
import { Store } from '../redux/store';
import { ActionsType } from '../redux/action-type';
import { Action } from '../redux/action';
import { Search } from '../models/search';
import { RentedCars } from '../models/RentedCars';

@Injectable({
  providedIn: 'root'
})
export class CarsService {

  public constructor(private httpclient: HttpClient, private redux: NgRedux<Store>) { }

  public getAllCars(): void {
    let observable = this.httpclient.get<Cars[]>("http://localhost:64635/api/cars");
    observable.subscribe(cars => {
      const action: Action = {type: ActionsType.GetAllCars, payload: cars}; 
       this.redux.dispatch(action); //Dispatch send the data to the reducer 
    });
  }
  public getOneCarDetails(id: number): void {
    let observable =  this.httpclient.get<Cars>("http://localhost:64635/api/cars/" + id);
    observable.subscribe(car => {
      const action: Action = {type: ActionsType.GetOneCar, payload: car};
      this.redux.dispatch(action);
    })

  }
  public AddCar(car: Cars): void {
  let observable =  this.httpclient.post<Cars>("http://localhost:64635/api/cars", car);
  observable.subscribe(car => {
    const action: Action = {type: ActionsType.AddCar, payload: car};
    this.redux.dispatch(action);
  });
  }

  public calculateRentalTotalCost (carDate: Search) : Observable<number[]> {
    return (this.httpclient.post<number[]>("http://localhost:64635/api/cars/cost", carDate));
  }
  public CalculateActualRentalCost (RentalDetails: RentedCars) : Observable<number[]> {
    return (this.httpclient.post<number[]>("http://localhost:64635/api/Rental/cost", RentalDetails));
  
  }

  public SearchRentedCar (RentalDetails: RentedCars): Observable<RentedCars>{
    console.log(RentalDetails);
    return this.httpclient.post<RentedCars>("http://localhost:64635/api/returnedCar", RentalDetails)
  }
  public AddRentedCar (rentedCar: RentedCars): Observable<RentedCars> {
    return this.httpclient.post<RentedCars>("http://localhost:64635/api/RentedCars" , rentedCar);    
        }
        public updateRentedCar (rentedCar: RentedCars): Observable<RentedCars> {
          console.log(rentedCar);
          return this.httpclient.put<RentedCars>("http://localhost:64635/api/ReturnedRentedCar/" + rentedCar.id, rentedCar );    
              }
}
