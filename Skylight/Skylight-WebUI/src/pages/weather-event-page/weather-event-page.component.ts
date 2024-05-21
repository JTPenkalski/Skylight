import { Component } from '@angular/core';
import { WeatherEventPageTitleCardComponent } from './';

@Component({
  selector: 'skylight-weather-event-page',
  standalone: true,
  imports: [
    WeatherEventPageTitleCardComponent
  ],
  templateUrl: './weather-event-page.component.html',
  styleUrl: './weather-event-page.component.scss'
})
export class WeatherEventPageComponent {
  
}
