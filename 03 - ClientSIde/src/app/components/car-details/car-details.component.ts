import { Component, OnInit, OnDestroy, DoCheck } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Cars } from 'src/app/models/cars';
import { CarsService } from 'src/app/services/cars.service';
import { Unsubscribe } from 'redux';
import { NgRedux } from 'ng2-redux';
import { Store } from 'src/app/redux/store';
import { SearchService } from 'src/app/services/search.service';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})
export class CarDetailsComponent implements OnInit, OnDestroy, DoCheck {
  
  public car: Cars;
  public isLoggedIn: boolean;
  public unsubscribe: Unsubscribe;
  public userDescription: string = "";


  public constructor(private activatedroute: ActivatedRoute, private searchService: SearchService, private carsService: CarsService, public redux: NgRedux<Store>, private router: Router) { }

  public ngOnInit()  {

    let carid = +this.activatedroute.snapshot.params.id;
    console.log(carid);
    if (isNaN(carid))
      {carid = 0;}
    this.unsubscribe = this.redux.subscribe(() => { //Listening to change in store 
    this.car = this.redux.getState().CarforRent;
    console.log(this.car)

      })
    this.searchService.GetChosenCar(carid);
  }
  public ngDoCheck(): void {
    if (this.redux.getState().currentUser.description)
    this.userDescription = this.redux.getState().currentUser.description;
    console.log(this.userDescription);
  }
  public RentCar() : void {
   
    this.isLoggedIn = this.redux.getState().IsLoogedIn;
    if (!this.isLoggedIn)
        this.router.navigate(["/login"]);
    this.router.navigate(["/rental"]);    
  }
public UpdateCar () : void {
  this.router.navigate(["update-car"]);
}
  public DeleteCar () : void {
    console.log(this.car.id);
    this.carsService.DeleteCar(this.car.id);
    this.router.navigate(["/cars"]);
  }
  ngOnDestroy(): void {this.unsubscribe() }


}
