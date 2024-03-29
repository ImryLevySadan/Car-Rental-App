import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule} from "@angular/router";
import { CarsComponent } from '../components/cars/cars.component';
import { ContactComponent } from '../components/contact/contact.component';
import { LoginComponent } from '../components/login/login.component';
import { Page404Component } from '../components/page404/page404.component';
import { SearchComponent } from '../components/search/search.component';
import { CarDetailsComponent } from '../components/car-details/car-details.component';
import { AddCarComponent } from '../components/add-car/add-car.component';
import { LoginGuardService } from '../services/login-guard.service';
import { SignupComponent } from '../components/signup/signup.component';
import { SearchResultComponent } from '../components/search-result/search-result.component';
import { RentalComponent } from '../components/rental/rental.component';
import { ReturningCarComponent } from '../components/returning-car/returning-car.component';
import { LayoutComponent } from '../components/layout/layout.component';
import { ManagerComponent } from '../components/manager/manager.component';
import { ManageUsersComponent } from '../components/manage-users/manage-users.component';
import { ManageTypesComponent } from '../components/manage-types/manage-types.component';
import { ManageListComponent } from '../components/manage-list/manage-list.component';
import { ManageRentalComponent } from '../components/manage-rental/manage-rental.component';
import { UpdateCarComponent } from '../components/update-car/update-car.component';


const routes: Routes = [
  {path: "signup", component: SignupComponent},
  {path: "update-car", canActivate: [LoginGuardService], component: UpdateCarComponent},
  {path: "home", component: LayoutComponent},
  {path: "search", component: SearchComponent},
  {path: "manager", component: ManagerComponent},
  {path: "manage-users", component: ManageUsersComponent},
  {path: "manage-types", component: ManageTypesComponent},
  {path: "manage-list", component: ManageListComponent},
  {path: "manage-rental", component: ManageRentalComponent},
  {path: "returning-car", canActivate: [LoginGuardService], component: ReturningCarComponent},
  {path: "search-result", component: SearchResultComponent},
  {path: "cars", component: CarsComponent},
  {path: "car-details/:id", component: CarDetailsComponent},
  {path: "rental", component: RentalComponent},
  {path: "add-car", canActivate: [LoginGuardService], component: AddCarComponent},
  {path: "contact", component: ContactComponent} ,
  {path: "login", component: LoginComponent},
  {path: "", redirectTo: "home", pathMatch: "full"},
  {path: "**", component: Page404Component}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule, RouterModule.forRoot(routes)
  ]
})
export class RoutingModule { }
