import { Component, OnInit, OnDestroy, DoCheck } from '@angular/core';
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
export class CarsComponent implements OnInit, DoCheck, OnDestroy {

  public cars: Cars[];
  public userDescription: string = "";
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
 
      
      public ngDoCheck(): void {
        if (this.redux.getState().currentUser.description)
        this.userDescription = this.redux.getState().currentUser.description;
        console.log(this.userDescription);
      }
      public ngOnDestroy(): void {
          this.unsubscribe();
      }
}
