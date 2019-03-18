import { Component, OnInit, OnDestroy } from '@angular/core';
import { Cars } from 'src/app/models/cars';
import { CarsService } from 'src/app/services/cars.service';
import { Router } from '@angular/router';
import { Unsubscribe } from 'redux';

@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css']
})
export class AddCarComponent {
  
  public car  = new Cars();

  public constructor(private carservice: CarsService, private router: Router) { }

  public addCar(): void {
    this.carservice.AddCar(this.car);
    this.router.navigate(["/cars"]);
  }

 




}
