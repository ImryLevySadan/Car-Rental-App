import { Component, OnInit } from '@angular/core';
import { Cars } from 'src/app/models/cars';
import { CarsService } from 'src/app/services/cars.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manage-list',
  templateUrl: './manage-list.component.html',
  styleUrls: ['./manage-list.component.css']
})
export class ManageListComponent {
  
  public car  = new Cars();
  public addcar: boolean = false;

  public constructor(private carservice: CarsService, private router: Router) { }

  public addCar(): void {
    this.carservice.AddCar(this.car);
    this.router.navigate(["/cars"]);
  }

  public ShowAddCarForm(): void {
      this.addcar = true;
  }

}
