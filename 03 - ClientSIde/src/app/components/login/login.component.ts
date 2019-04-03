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

  
}

