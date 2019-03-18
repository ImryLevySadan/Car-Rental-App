import { Component, OnInit, OnDestroy } from '@angular/core';
import { Unsubscribe } from 'redux';
import { NgRedux } from 'ng2-redux';
import { Store } from 'src/app/redux/store';
import { Search } from 'src/app/models/search';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.css']
})
export class SearchResultComponent implements OnInit, OnDestroy {
  

  public unsubscribe: Unsubscribe;
  public searchedCars: Search []; 
  constructor(private redux: NgRedux<Store>) { }

  ngOnInit() {
    this.unsubscribe = this.redux.subscribe(() => {
            this.searchedCars = this.redux.getState().searchedCars;     
            console.log(this.searchedCars);

        });
    
  }

  ngOnDestroy(): void {this.unsubscribe(); }
}
