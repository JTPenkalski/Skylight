import { Component } from '@angular/core';

interface INavigationLink {
  readonly name: string;
  readonly tooltip: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Skylight';

  readonly navigationLinks: INavigationLink[] = [
    { name: 'Dashboard', tooltip: 'View your dashboard' },
    { name: 'Track', tooltip: 'Manage your tracked weather' },
    { name: 'Forecast', tooltip: 'See your upcoming forecast' },
    { name: 'Radar', tooltip: 'Observe current radar readings' }
  ];

  constructor() { }
}
