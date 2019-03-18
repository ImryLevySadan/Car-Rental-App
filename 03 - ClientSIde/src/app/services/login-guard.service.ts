import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { NgRedux } from 'ng2-redux';
import { Store } from '../redux/store';


@Injectable({
  providedIn: 'root'
})
export class LoginGuardService implements CanActivate {
   
  constructor(private router: Router, private redux: NgRedux<Store>) { }

  public canActivate() : boolean {
    if (this.redux.getState().IsLoogedIn)
        return true;
    this.router.navigate(["/home"]);
    return false;

  }

}
