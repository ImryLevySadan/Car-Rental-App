import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cars } from '../models/cars';
import { NgRedux } from 'ng2-redux';
import { Action } from '../redux/action';
import { ActionsType } from '../redux/action-type';
import { Store } from '../redux/store';
import { Search } from '../models/search';
import { Types } from '../models/types';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  public constructor(private httpclient: HttpClient, private redux: NgRedux<Store>) { }

  public getAllSearchedCars(search: Search): void {
    let observable = this.httpclient.post<Search[]>("http://localhost:64635/api/cars/search", search)
    observable.subscribe(searchedCars => {
       const action: Action = {type: ActionsType.GetAllSerchedCars, payload: searchedCars}; 
       this.redux.dispatch(action); //Dispatch send the data to the reducer 
    });
  }

  public GetChosenCar(carid: number): void {
    let observable = this.httpclient.get<Cars>("http://localhost:64635/api/cars/" + carid)
    observable.subscribe(chosenCar => {
       const action: Action = {type: ActionsType.GetChosenCar, payload: chosenCar}; 
       this.redux.dispatch(action); //Dispatch send the data to the reducer 
    });
  }

  public getAllCarManufacturers () : void {
    let observable = this.httpclient.get<Types[]>("http://localhost:64635/api/carManufacturers");
    observable.subscribe(manufacturers => {
      const action: Action = {type: ActionsType.GetAllCarManufacturers, payload: manufacturers}; 
       this.redux.dispatch(action); //Dispatch send the data to the reducer 
    });
  }

  public GetCarTypesByManufacture (manufacture: string) : void {
    let observable = this.httpclient.get<Types[]>("http://localhost:64635/api/TypesByManufacture/" + manufacture);
    observable.subscribe(carTypes => {
      const action: Action = {type: ActionsType.GetCarTypesByManufacture, payload: carTypes}; 
       this.redux.dispatch(action); //Dispatch send the data to the reducer 
    });
  }
}
