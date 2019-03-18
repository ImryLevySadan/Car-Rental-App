import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgRedux } from 'ng2-redux';
import { Store } from '../redux/store';
import { Users } from '../models/users';
import { Action } from '../redux/action';
import { ActionsType } from '../redux/action-type';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  public constructor(private http: HttpClient, private redux: NgRedux<Store>) { }

  public getAllUsers (): void {
      let observable = this.http.get<Users[]>("http://localhost:64635/api/users");
      observable.subscribe(users => {
        const action: Action = {type: ActionsType.GetAllUsers, payload: users};
        this.redux.dispatch(action);
      });
    }
      public addUser (user: Users): void {
        let observable = this.http.post<Users>("http://localhost:64635/api/users", user);
        observable.subscribe(user => {
          console.log(user);
          const action:Action = {type: ActionsType.AddUser, payload: user};
          this.redux.dispatch(action);
        })
      }

  
}
