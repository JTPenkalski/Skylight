import { Component } from '@angular/core';

import { INavigationLink } from './types/navigation-link';
import { WeatherEvent } from 'presentation/models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public readonly navigationLinks: INavigationLink[] = [
    { name: 'Dashboard', tooltip: 'View your dashboard' },
    { name: 'Track', tooltip: 'Manage your tracked weather' },
    { name: 'Forecast', tooltip: 'See your upcoming forecast' },
    { name: 'Radar', tooltip: 'Observe current radar readings' }
  ];

  public title: string = 'Skylight';
  public temp: WeatherEvent = new WeatherEvent();

  constructor() { }
}
