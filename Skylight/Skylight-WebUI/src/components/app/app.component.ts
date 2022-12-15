import { Component } from '@angular/core';
import { WEATHER_EXPERIENCE } from '../../forms/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public formTemplate: string = WEATHER_EXPERIENCE;

  constructor() { }

  title = 'Skylight';
}
