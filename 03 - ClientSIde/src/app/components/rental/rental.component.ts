import { Component, OnInit } from '@angular/core';
import { NgRedux } from 'ng2-redux';
import { Store } from 'src/app/redux/store';
import { Cars } from 'src/app/models/cars';
import { Search } from 'src/app/models/search';
import { CarsService } from 'src/app/services/cars.service';
import { RentedCars } from 'src/app/models/RentedCars';
import { Users } from 'src/app/models/users';
import { Unsubscribe } from 'redux';

@Component({
  selector: 'app-rental',
  templateUrl: './rental.component.html',
  styleUrls: ['./rental.component.css']
})
export class RentalComponent implements OnInit {
public CarForRent: Cars;
public carDates: Search = {};
public carRentalCost: number;
public CarRentalDelayCost: number;
public rentedCar: RentedCars = {};
public userDetails: Users;
public unsubscribe: Unsubscribe;




  constructor(private redux: NgRedux<Store>, private carservice: CarsService) { }

  ngOnInit() {

    // this.car = this.redux.getState().CarforRent;
    // if (this.car)
    //     this.CarForRent.typeid = this.car.typeid;
    this.CarForRent = this.redux.getState().CarforRent;
    if (this.CarForRent)
          this.carDates.typeid = this.CarForRent.typeid;
    console.log(this.CarForRent);
    this.userDetails = this.redux.getState().currentUser;
    console.log(this.userDetails);
  
  }

  public calculateRentalTotalCost () : void {
    let observable = this.carservice.calculateRentalTotalCost(this.carDates);
    observable.subscribe(carRentalCosts => {
      console.log(carRentalCosts); 
      this.carRentalCost =carRentalCosts[0]; 
      this.CarRentalDelayCost = carRentalCosts[1]});
    }

    public RentCar () : void {
      this.rentedCar.carid = this.CarForRent.id;
      this.rentedCar.userid = this.userDetails.userid;
      this.rentedCar.start = this.carDates.start;
      this.rentedCar.returndate = this.carDates.returndate;
      this.rentedCar.licenseplate = this.CarForRent.license_plate;
      this.rentedCar.fullname = this.userDetails.fullname;
      this.rentedCar.username = this.userDetails.username;
      this.rentedCar.idnumber = this.userDetails.idnumber;
      this.rentedCar.email = this.userDetails.email;
      this.rentedCar.description = this.userDetails.description;
      this.rentedCar.dailycost = this.CarForRent.dailycost;
      this.rentedCar.dailydelaycost = this.CarForRent.daily_delay_cost;
      console.log(this.rentedCar);
    // }
      
        let observable = this.carservice.AddRentedCar(this.rentedCar);
        observable.subscribe(car => alert("Your Order has completed successfuly. This is your reservation details: " +
        " User Name: "+ car.username + 
        " User Email: " + car.email + 
        " Car License Plate: " + car.licenseplate + " Total Cost: " + this.carRentalCost));
    }

}
