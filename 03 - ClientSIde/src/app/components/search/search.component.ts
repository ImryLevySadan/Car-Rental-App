import { Component, OnInit, DoCheck, OnChanges } from '@angular/core';
import { Search } from 'src/app/models/search';
import { Cars } from 'src/app/models/cars';
import { NgRedux } from 'ng2-redux';
import { Store } from 'src/app/redux/store';
import { Unsubscribe } from 'redux';
import { SearchService } from 'src/app/services/search.service';
import { Types } from 'src/app/models/types';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
    

  public searchedcar: Search = {};
  public searchedCars: Search[]
  public cars: Cars[];
  public unsubscribe: Unsubscribe;
  public Selectedtype: Types[];
  public manufactureres: string[];
  public formButtonPressed: boolean = false;
  public carForRent: boolean = false;
  // public models: string[];
  // public years: number[];

  constructor(private searchService: SearchService,  private redux: NgRedux<Store>, private router: Router) { }

  public ngOnInit(): void {
    this.unsubscribe = this.redux.subscribe(() => { //Listening to change in store 
      this.manufactureres = this.redux.getState().manufacturers;
      if (this.redux.getState().CarforRent) {
        this.carForRent = true;
      }
      })
      this.searchService.getAllCarManufacturers();  
      
    }
    

    public onChange () : void {
        this.Selectedtype = null;
    if (this.searchedcar.manufacture) {

        this.unsubscribe = this.redux.subscribe(() => { 
        this.Selectedtype = this.redux.getState().CarTypes;});
        this.searchService.GetCarTypesByManufacture(this.searchedcar.manufacture);  
      }
    }
   
    
    public findSearchedCars(): void {
      this.formButtonPressed = true;
      this.unsubscribe = this.redux.subscribe(() => { //Listening to change in store 
        this.searchedCars = this.redux.getState().searchedCars;
      })
        this.searchService.getAllSearchedCars(this.searchedcar); 
         this.router.navigate(["/search-result"]);
       }
        
        public ngOnDestroy(): void {
            this.unsubscribe();
        }
  }

