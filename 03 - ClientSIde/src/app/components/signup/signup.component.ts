import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/services/users.service';
import { Users } from 'src/app/models/users';
import { Router } from '@angular/router';


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent  {

  public user = new Users();

  constructor(private userService: UsersService, private router: Router ) { }

  public AddUser(): void {
      if (this.IsUserIdValid(this.user.idnumber)) {
        this.userService.addUser(this.user);
        this.router.navigate(["/rental"]);
      }
      else {
        alert ("invalid Id number, ReCheck")
      }
      
  }
  public IsUserIdValid (idnumber : string): boolean
  {
      var mone = 0;
      let incNum;
      for ( let i  = 0; i < 9; i++)
      {
          incNum = +idnumber[i];
          incNum *= (i % 2) + 1;
          if (incNum > 9)
              incNum -= 9;
          mone += incNum;
      }
      if (mone % 10 == 0)
          return true;
      else
          return false;
  }
}
