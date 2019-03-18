import { Component, OnInit, DoCheck } from '@angular/core';
import { Router } from '@angular/router';
import { Action } from 'src/app/redux/action';
import { ActionsType } from 'src/app/redux/action-type';
import { NgRedux } from 'ng2-redux';
import { Store } from 'src/app/redux/store';
import { Users } from 'src/app/models/users';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements DoCheck  {

  public constructor (private redux: NgRedux<Store>, private router: Router) {}
  public isLoggedIn : boolean; 
  public user: Users;
  public description?: string = "Client";

    public ngDoCheck(): void {
      this.isLoggedIn = this.redux.getState().IsLoogedIn;
      this.user = this.redux.getState().currentUser;
      this.description = this.redux.getState().currentUser.description;
    }

    public logOut(): void {
      const action: Action = {type: ActionsType.Logout};
      this.redux.dispatch(action); 
      this.router.navigate(["/search"]);
    }
}
