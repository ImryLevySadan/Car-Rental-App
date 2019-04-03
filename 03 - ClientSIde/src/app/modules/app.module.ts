import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { LayoutComponent } from '../components/layout/layout.component';
import { MenuComponent } from '../components/menu/menu.component';
import { CarsComponent } from '../components/cars/cars.component';
import { LoginComponent } from '../components/login/login.component';
import { ContactComponent } from '../components/contact/contact.component';
import { RouterModule } from '@angular/router';
import { RoutingModule } from './routing.module';
import {HttpClientModule} from '@angular/common/http';
import { Page404Component } from '../components/page404/page404.component';
import { SearchComponent } from '../components/search/search.component';
import { ThumbnailComponent } from '../components/thumbnail/thumbnail.component';
import { CarDetailsComponent } from '../components/car-details/car-details.component';
import { AddCarComponent } from '../components/add-car/add-car.component'
import { FormsModule} from '@angular/forms';
import {NgRedux, NgReduxModule} from "ng2-redux";
import { Store } from '../redux/store';
import { Reducer } from '../redux/reducer';
import { SignupComponent } from '../components/signup/signup.component';
import { SearchResultComponent } from '../components/search-result/search-result.component';
import { RentalComponent } from '../components/rental/rental.component';
import { ReturningCarComponent } from '../components/returning-car/returning-car.component';
import { ManagerComponent } from '../components/manager/manager.component';
import { ManageUsersComponent } from '../components/manage-users/manage-users.component';
import { ManageTypesComponent } from '../components/manage-types/manage-types.component';
import { ManageListComponent } from '../components/manage-list/manage-list.component';
import { ManageRentalComponent } from '../components/manage-rental/manage-rental.component';
import { DeleteCarComponent } from '../components/delete-car/delete-car.component';
import { UpdateCarComponent } from '../components/update-car/update-car.component';


@NgModule({
  declarations: [ LayoutComponent, MenuComponent, CarsComponent, LoginComponent, ContactComponent, Page404Component, SearchComponent, ThumbnailComponent, CarDetailsComponent, AddCarComponent, SignupComponent, SearchResultComponent, RentalComponent, ReturningCarComponent, ManagerComponent, ManageUsersComponent, ManageTypesComponent, ManageListComponent, ManageRentalComponent, DeleteCarComponent, UpdateCarComponent],
  imports: [
    BrowserModule,
    RouterModule, 
    RoutingModule,
    HttpClientModule,
    FormsModule,
    NgReduxModule
  ],
  providers: [],
  bootstrap: [LayoutComponent]
})
export class AppModule { 

public constructor(redux: NgRedux<Store>) {
  redux.configureStore(Reducer.reduce, new Store());
}
}
