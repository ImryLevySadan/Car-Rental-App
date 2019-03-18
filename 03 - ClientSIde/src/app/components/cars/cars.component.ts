import { Component, OnInit, OnDestroy } from '@angular/core';
import { Cars } from 'src/app/models/cars';
import { CarsService } from 'src/app/services/cars.service';
import { NgRedux } from 'ng2-redux';
import { Store } from 'src/app/redux/store';
import { Unsubscribe } from 'redux';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit, OnDestroy {

  public cars: Cars[];
  //Unlike the HTTP subscrive, the redex observable need active unsubscribe 
  // action, in order to stop listening (resource considerations)
  //Every Redux Subscribe need to unsubscribe after data recieved
  public unsubscribe: Unsubscribe;
  
  constructor(private carsService: CarsService, private redux: NgRedux<Store>) { }

  public ngOnInit(): void {
    this.unsubscribe = this.redux.subscribe(() => { //Listening to change in store 
      this.cars = this.redux.getState().cars;
    });
      this.carsService.getAllCars();  }
        
      public ngOnDestroy(): void {
          this.unsubscribe();
      }
}
