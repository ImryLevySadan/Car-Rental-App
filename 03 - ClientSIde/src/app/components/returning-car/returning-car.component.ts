import { Component, OnInit } from '@angular/core';
import { RentedCars } from 'src/app/models/RentedCars';
import { CarsService } from 'src/app/services/cars.service';
import { Search } from 'src/app/models/search';

@Component({
  selector: 'app-returning-car',
  templateUrl: './returning-car.component.html',
  styleUrls: ['./returning-car.component.css']
})
export class ReturningCarComponent {

  public RentalDetails = new RentedCars ();
  public RentedCar: RentedCars;
  public dateSearch: RentedCars;
  public carRentalCost: number;
  public CarRentalDelayCost: number;
  public TotalRentalCost: number;

  constructor(private carservice: CarsService) { }

  public SearchRentedCar (){ 
    console.log(this.RentalDetails.licenseplate);
    if (this.RentalDetails.licenseplate){ 
    let observable = this.carservice.SearchRentedCar(this.RentalDetails);
    observable.subscribe(car => {this.RentedCar = car; console.log(this.RentedCar)});
  }
  }

  public CalculateRentalCost () {
    let observable = this.carservice.CalculateActualRentalCost(this.RentedCar);
    observable.subscribe(rentalcosts => {
      console.log(this.carRentalCost);
      this.carRentalCost =rentalcosts[0]; 
      this.CarRentalDelayCost = rentalcosts[1]
      this.TotalRentalCost = this.carRentalCost + this.CarRentalDelayCost;
      console.log(this.TotalRentalCost);
    });

    };
    
    public updateActualReturnDate() {
       console.log(this.RentedCar);
      let observable = this.carservice.updateRentedCar(this.RentedCar);
      observable.subscribe(returnedCar => console.log(returnedCar));
    }
  
  
}  


