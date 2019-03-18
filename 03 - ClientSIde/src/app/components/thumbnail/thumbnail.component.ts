import { Component, Input, Output } from '@angular/core';
import { EventEmitter } from '@angular/core';


@Component({
  selector: 'app-thumbnail',
  templateUrl: './thumbnail.component.html',
  styleUrls: ['./thumbnail.component.css']
})
export class ThumbnailComponent {
  @Input("imageName")
  public imageName: string;
  
  @Input("width")
  public imageWidth: number;

  @Input("height")
  public imageHeight: number;

  @Output()
  public mouseEnter: EventEmitter<string> = new EventEmitter<string>();

  @Output()
  public mouseLeave: EventEmitter<undefined> = new EventEmitter<undefined>();
  
  constructor() { }

  public imageMouseEnter() : void {
    this.mouseEnter.emit(this.imageName); // Rasing an event

  }

  public imageMouseLeave(): void {
    this.mouseLeave.emit() // Rasing an event
  }

}
