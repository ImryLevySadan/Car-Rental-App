import { Component, OnInit, DoCheck } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements DoCheck {

  constructor( private router: Router) { }
  public inHomePage :boolean = true;
  
  
  public ngDoCheck(): void {
   let url = "http://localhost:4200" + this.router.url;
   console.log(url);
   if (url != "http://localhost:4200/home") {
        console.log(this.inHomePage);
       this.inHomePage = false;
  }
  else {
    this.inHomePage = true;
  }
  }

}
