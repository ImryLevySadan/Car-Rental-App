import { Component, OnInit } from '@angular/core';
import { Users } from 'src/app/models/users';
import { UsersService } from 'src/app/services/users.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manage-users',
  templateUrl: './manage-users.component.html',
  styleUrls: ['./manage-users.component.css']
})
export class ManageUsersComponent  {

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
