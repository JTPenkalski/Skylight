import { Component } from '@angular/core';

@Component({
  selector: 'skylight-search-bar',
  templateUrl: './skylight-search-bar.component.html',
  styleUrls: ['./skylight-search-bar.component.scss']
})
export class SkylightSearchBarComponent {
  public value: string = '';

  constructor() { }
}
