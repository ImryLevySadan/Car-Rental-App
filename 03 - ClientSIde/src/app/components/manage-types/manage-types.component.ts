import { Component, OnInit } from '@angular/core';
import { Types } from 'src/app/models/types';
import { CarsService } from 'src/app/services/cars.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manage-types',
  templateUrl: './manage-types.component.html',
  styleUrls: ['./manage-types.component.css']
})
export class ManageTypesComponent {

  public car  = new Types();
  public addcar: boolean = false;

  public constructor(private carservice: CarsService, private router: Router) { }

  public addType(): void {
    this.carservice.AddCar(this.car);
    this.router.navigate(["/cars"]);
  }

  public ShowAddCarForm(): void {
      this.addcar = true;
  }

}
