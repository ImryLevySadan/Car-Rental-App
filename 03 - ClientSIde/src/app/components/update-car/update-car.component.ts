import { Component, OnInit } from '@angular/core';
import { Cars } from 'src/app/models/cars';
import { Router } from '@angular/router';
import { CarsService } from 'src/app/services/cars.service';
import { NgRedux } from 'ng2-redux';
import { Store } from 'src/app/redux/store';

@Component({
  selector: 'app-update-car',
  templateUrl: './update-car.component.html',
  styleUrls: ['./update-car.component.css']
})
export class UpdateCarComponent implements OnInit{

  public car: Cars;

  public constructor(private carservice: CarsService, private router: Router, private redux: NgRedux<Store>) { }

  public ngOnInit()  {
    this.car = this.redux.getState().CarforRent;
  }
  
  public UpdateCar(): void {
    this.carservice.updateCar(this.car);
    this.router.navigate(["/cars"]);
  }

}
