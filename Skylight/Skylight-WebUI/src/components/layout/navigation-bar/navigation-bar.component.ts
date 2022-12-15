import { Component } from '@angular/core';

@Component({
  selector: 'skylight-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent {
  readonly navigationLinks: NavigationLink[] = [
    { name: 'Dashboard', tooltip: 'View your dashboard' },
    { name: 'Experiences', tooltip: 'Browse all weather experiences' },
    { name: 'Search', tooltip: 'Search weather events, storm trackers, and more' }
  ];

}

interface NavigationLink {
  readonly name: string;
  readonly tooltip: string;
}
