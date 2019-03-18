import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Credentials } from '../models/credentials';
import { Observable, observable } from 'rxjs';
import { NgRedux } from 'ng2-redux';
import { Action } from '../redux/action';
import { ActionsType } from '../redux/action-type';
import { Store } from '../redux/store';
import { Users } from '../models/users';
import { isNull } from '@angular/compiler/src/output/output_ast';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient, private redux: NgRedux<Store>) { }
  

  public IsExist(credentials: Credentials) : void {
        let observable =  this.http.post<Users>("http://localhost:64635/api/users/login", credentials);
        observable.subscribe(user => {
          if (user) {
          const verificationAction: Action = {type: ActionsType.Login, payload: user};
          this.redux.dispatch(verificationAction);
          }
          else {
          const verificationAction: Action = {type: ActionsType.Logout};
          this.redux.dispatch(verificationAction);
        }
        
       });
      
    
  }
}
