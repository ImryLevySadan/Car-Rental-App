import { Component, OnInit, OnDestroy } from '@angular/core';
import { Credentials } from 'src/app/models/credentials';
import { LoginService } from 'src/app/services/login.service';
import { Router } from '@angular/router';
import { Users } from 'src/app/models/users';
import { NgRedux } from 'ng2-redux';
import { Store } from 'src/app/redux/store';
import { Unsubscribe } from 'redux';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent {
  
  public credentials = new Credentials ();
  public user: Users = {};
  public unsubscribe: Unsubscribe;
  public isExist: boolean = false;
 
  constructor(private loginservice: LoginService, private router: Router, private redux:NgRedux<Store>) {}

  // public logIn (): void {
  //   this.unsubscribe = this.redux.subscribe(() => {
  //     if(this.redux.getState().IsLoogedIn){
  //      this.user = this.redux.getState().currentUser;
  //      console.log(this.user);
  //      switch (this.user.description) {
  //        case "Manager":  
  //        this.router.navigate(["manager"]);
  //        break;
  //        case "Employee":  
  //        this.router.navigate(["returning-car"]);
  //        break;
  //        case "Client":  
  //        this.router.navigate(["search"]);
  //        break;
  //      }
  //     }
  //     else {
  //       alert ("User Name or Password doesn't exist");
  //       this.credentials = { username: "", password: ""}
  //       console.log(this.credentials);
  //       this.router.navigate(["login"]);


  //     }
  //   });
  //   this.loginservice.IsExist(this.credentials);
    
  // }
  // public ngOnDestroy(): void {
  //   this.unsubscribe();
  // }

}

