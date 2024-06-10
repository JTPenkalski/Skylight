import { Component, Input, OnInit } from '@angular/core';
import { WeatherEventHubConnectionService } from 'web/connections';
import { environment } from 'environments/environment';
import { InfoCardComponent } from 'shared/components';
import { EventBusService } from 'shared/services';
import { WeatherEventAlertButtonComponent } from 'pages/weather-event-page/components';
import { WeatherEventLocation } from 'pages/weather-event-page/models';
import { WeatherAlertAddedEvent } from 'pages/weather-event-page/events';
import { WeatherEventService } from 'pages/weather-event-page/services';

@Component({
  selector: 'skylight-weather-event-locations-card',
  standalone: true,
  imports: [
    InfoCardComponent,
    WeatherEventAlertButtonComponent
  ],
  templateUrl: './weather-event-locations-card.component.html',
  styleUrl: './weather-event-locations-card.component.scss'
})
export class WeatherEventLocationsCardComponent implements OnInit {
  @Input({ required: true }) public weatherEventId!: string;

  public loading: boolean = true;
  public locations: WeatherEventLocation[] = [];

  constructor(
    private readonly eventBus: EventBusService,
    private readonly service: WeatherEventService,
    private readonly weatherEventHub: WeatherEventHubConnectionService
  ) { }

  public get locationCount(): number {
    return this.locations.length;
  }

  public ngOnInit(): void {
    if (environment.enableAutoNwsApiCalls) {
      this.fetchLocations();
    } else {
      this.loading = false;
      console.log('Call to fetch Locations blocked by environment configuration.');
    }

    this.eventBus.handle(WeatherAlertAddedEvent)
      .subscribe(x => this.locations.push(new WeatherEventLocation(x.alert.sender)));

    // this.weatherEventHub.newWeatherAlerts.subscribe(x => {
    //   this.alerts = x.newWeatherEventAlerts.map(a => NewWeatherEventAlert.fromHub(a));
    // });
  }

  public fetchLocations(): void {
    this.locations = [];
    this.loading = true;

    // this.service
    //   .fetchWeatherAlerts(this.weatherEventId)
    //   .subscribe({
    //     next: result => {
    //       this.alerts = result;
    //       this.loading = false;
    //     },
    //     error: () => {
    //       console.error(`Failed to fetch Locations for Weather Event ID ${this.weatherEventId}`);
    //       this.loading = false
    //     }
    //   });
  }
}

