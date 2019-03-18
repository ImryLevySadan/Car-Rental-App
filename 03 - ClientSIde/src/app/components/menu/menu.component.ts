import { Component, OnInit, DoCheck, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Action } from 'src/app/redux/action';
import { ActionsType } from 'src/app/redux/action-type';
import { NgRedux } from 'ng2-redux';
import { Store } from 'src/app/redux/store';
import { Users } from 'src/app/models/users';
import { Unsubscribe } from 'redux';
import { Credentials } from 'src/app/models/credentials';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements DoCheck, OnDestroy  {

  public constructor (private redux: NgRedux<Store>, private router: Router, private loginservice: LoginService) {}
  public isLoggedIn : boolean = false; 
  public credentials = new Credentials ();
  public user: Users;
  public description?: string = "Client";
  public unsubscribe: Unsubscribe;
  
    public logIn (): void {
        this.unsubscribe = this.redux.subscribe(() => {
        if(this.redux.getState().IsLoogedIn){
         this.user = this.redux.getState().currentUser;
         console.log(this.user);
        }
     
      });
      console.log(this.credentials);
      this.loginservice.IsExist(this.credentials);
      
    }

    public logOut(): void {
      console.log(this.user);
      this.unsubscribe = this.redux.subscribe(() => {  
        this.credentials = { username: "", password: ""} 
        this.isLoggedIn = false;
        });
     this.loginservice.LogOut();
   
    }

    
    public ngDoCheck(): void {
      if (this.redux.getState().IsLoogedIn)
      {
      this.isLoggedIn = this.redux.getState().IsLoogedIn;
      console.log(this.isLoggedIn);
    }
      this.user = this.redux.getState().currentUser;
      if (this.redux.getState().currentUser.description)
      this.description = this.redux.getState().currentUser.description;
      else (this.description = "Client");
      console.log(this.description);
    }

    ngOnDestroy(): void {
      console.log(this.unsubscribe);
      if (this.unsubscribe) {
      console.log("Subscribe!", this.unsubscribe);
      this.unsubscribe();  }

      }
}
