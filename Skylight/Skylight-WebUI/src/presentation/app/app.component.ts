import { Component, Inject } from '@angular/core';

import { ROUTE_NAMES_CONFIG_TOKEN, RouteNamesConfiguration } from 'presentation/injection';
import { INavigationLink } from './types/navigation-link';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public readonly navigationLinks: INavigationLink[] = [
    { name: 'Dashboard', tooltip: 'View your dashboard' },
    { name: 'Track', tooltip: 'Manage your tracked weather' },
    { name: 'Forecast', tooltip: 'See your upcoming forecast' }
  ];

  constructor(@Inject(ROUTE_NAMES_CONFIG_TOKEN) public readonly routesConfig: RouteNamesConfiguration) { }
}
