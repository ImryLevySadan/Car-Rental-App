import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Cars } from 'src/app/models/cars';
import { CarsService } from 'src/app/services/cars.service';
import { Unsubscribe } from 'redux';
import { NgRedux } from 'ng2-redux';
import { Store } from 'src/app/redux/store';
import { Reducer } from 'src/app/redux/reducer';
import { SearchService } from 'src/app/services/search.service';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})
export class CarDetailsComponent implements OnInit, OnDestroy {
  
  public car: Cars;
  public isLoggedIn: boolean;
  public unsubscribe: Unsubscribe;

  public constructor(private activatedroute: ActivatedRoute, private searchService: SearchService, private carsService: CarsService, public redux: NgRedux<Store>, private router: Router) { }

  public ngOnInit()  {

    let carid = +this.activatedroute.snapshot.params.id;
    if (isNaN(carid))
      {carid = 0;}
    this.unsubscribe = this.redux.subscribe(() => { //Listening to change in store 
    this.car = this.redux.getState().CarforRent;
    console.log(this.car)

      })
    this.searchService.GetChosenCar(carid);
  }

  public RentCar() : void {
   
    this.isLoggedIn = this.redux.getState().IsLoogedIn;
    if (!this.isLoggedIn)
        this.router.navigate(["/login"]);
    this.router.navigate(["/rental"]);    
  }
  ngOnDestroy(): void {this.unsubscribe() }


}
