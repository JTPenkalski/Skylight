import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { WeatherEventHubConnectionService } from 'web/connections';
import { environment } from 'environments/environment';
import { InfoCardComponent } from 'shared/components';
import { ContextMenu } from 'shared/models';
import { EventBusService } from 'shared/services';
import { WeatherEventAlertButtonComponent } from 'pages/weather-event-page/components';
import { WeatherAlertAddedEvent, WeatherAlertsRefreshedEvent } from 'pages/weather-event-page/events';
import { NewWeatherEventAlert, WeatherAlertLevel } from 'pages/weather-event-page/models';
import { WeatherEventService } from 'pages/weather-event-page/services';

@Component({
  selector: 'skylight-weather-event-alerts-card',
  standalone: true,
  imports: [
    InfoCardComponent,
    WeatherEventAlertButtonComponent
  ],
  templateUrl: './weather-event-alerts-card.component.html',
  styleUrl: './weather-event-alerts-card.component.scss'
})
export class WeatherEventAlertsCardComponent implements OnInit {
  @Input({ required: true }) public weatherEventId!: string;
  @Output() public alertSelected: EventEmitter<NewWeatherEventAlert> = new EventEmitter<NewWeatherEventAlert>();

  public loading: boolean = true;
  public showAdvisories: boolean = false;
  public alerts: NewWeatherEventAlert[] = [];
  public contextMenu: ContextMenu = new ContextMenu(
    `${WeatherEventAlertsCardComponent}Menu`,
    [
      {
        item: {
          title: 'Toggle Advisories'
        },
        action: () => this.showAdvisories = !this.showAdvisories
      }
    ]
  )

  constructor(
    private readonly eventBus: EventBusService,
    private readonly service: WeatherEventService,
    private readonly weatherEventHub: WeatherEventHubConnectionService
  ) { }

  public get alertCount(): number {
    return this.alerts
      .filter(x => this.canDisplayAlert(x))
      .length;
  }

  public ngOnInit(): void {
    if (environment.enableAutoNwsApiCalls) {
      this.fetchWeatherAlerts();
    } else {
      this.loading = false;
      console.log('Call to fetch Weather Alerts blocked by environment configuration.');
    }

    this.weatherEventHub.newWeatherAlerts.subscribe(x => {
      this.alerts = x.newWeatherEventAlerts.map(a => NewWeatherEventAlert.fromHub(a));
    });
  }

  public canDisplayAlert(alert: NewWeatherEventAlert): boolean {
    let output: boolean = true;

    output = alert.level !== WeatherAlertLevel.Advisory || this.showAdvisories;

    return output;
  }

  public fetchWeatherAlerts(): void {
    this.alerts = [];
    this.loading = true;

    this.eventBus.emit(new WeatherAlertsRefreshedEvent());

    this.service
      .fetchWeatherAlerts(this.weatherEventId)
      .subscribe({
        next: result => {
          this.alerts = result;
          this.loading = false;

          result.forEach(x => this.eventBus.emit(new WeatherAlertAddedEvent(x)));
        },
        error: () => {
          console.error(`Failed to fetch Weather Alerts for Weather Event ID ${this.weatherEventId}`);
          this.loading = false
        }
      });
  }

  public openWeatherAlert(alert: NewWeatherEventAlert): void {
    this.alertSelected.emit(alert);
  }
}
