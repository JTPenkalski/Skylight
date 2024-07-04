import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { NbCardModule, NbSpinnerModule } from '@nebular/theme';
import { WeatherEventHubConnectionService } from 'web/connections';
import {
  WeatherEventPageCardContainerComponent,
  WeatherEventPageSummaryCardComponent,
} from './components';

@Component({
  selector: 'skylight-weather-event-page',
  standalone: true,
  imports: [
    NbCardModule,
    NbSpinnerModule,
    WeatherEventPageCardContainerComponent,
    WeatherEventPageSummaryCardComponent,
  ],
  templateUrl: './weather-event-page.component.html',
  styleUrl: './weather-event-page.component.scss',
})
export class WeatherEventPageComponent implements OnInit, OnDestroy {
  @Input()
  public id?: string;

  constructor(private readonly weatherEventHubConnection: WeatherEventHubConnectionService) {}

  public ngOnInit(): void {
    if (this.id) {
      this.weatherEventHubConnection.connect();
    }
  }

  public ngOnDestroy(): void {
    this.weatherEventHubConnection.disconnect();
  }
}
