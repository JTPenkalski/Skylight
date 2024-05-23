import { Component, OnInit } from '@angular/core';
import { WeatherEventPageSummaryCardComponent } from './components';
import { WeatherEventSummary } from './models';
import { WeatherEventService } from './services';
import { NbCardModule, NbSpinnerModule } from '@nebular/theme';

@Component({
  selector: 'skylight-weather-event-page',
  standalone: true,
  imports: [
    NbCardModule,
    NbSpinnerModule,
    WeatherEventPageSummaryCardComponent
  ],
  templateUrl: './weather-event-page.component.html',
  styleUrl: './weather-event-page.component.scss'
})
export class WeatherEventPageComponent implements OnInit {
  public summary!: WeatherEventSummary;

  constructor(private readonly service: WeatherEventService) { }

  public ngOnInit(): void {
    this.service
      .getWeatherEventSummary('8513237d-1a5a-45bd-9d63-1b83d633ea11')
      .subscribe(result => this.summary = result);
  }
}
