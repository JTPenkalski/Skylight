import { Component } from '@angular/core';

import { NavigationLink } from 'models/navigation-link';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Skylight';

  readonly navigationLinks: NavigationLink[] = [
    { name: 'Dashboard', tooltip: 'View your dashboard' },
    { name: 'Track', tooltip: 'Manage your tracked weather' },
    { name: 'Forecast', tooltip: 'See your upcoming forecast' },
    { name: 'Radar', tooltip: 'Observe current radar readings' }
  ];

  constructor() { }
}
