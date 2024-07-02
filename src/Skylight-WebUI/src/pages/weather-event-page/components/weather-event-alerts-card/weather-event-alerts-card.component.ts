import { Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { NbWindowComponent, NbWindowService } from '@nebular/theme';
import { environment } from 'environments/environment';
import {
  WeatherEventAlertButtonComponent,
  WeatherEventAlertWindowComponent,
} from 'pages/weather-event-page/components';
import {
  WeatherAlertAddedEvent,
  WeatherAlertsRefreshedEvent,
} from 'pages/weather-event-page/events';
import { NewWeatherEventAlert, WeatherAlertLevel } from 'pages/weather-event-page/models';
import { WeatherEventService } from 'pages/weather-event-page/services';
import { InfoCardComponent } from 'shared/components';
import { ContextMenu } from 'shared/models';
import { ParenthesesWrapPipe } from 'shared/pipes';
import { EventBusService } from 'shared/services';
import { WeatherEventHubConnectionService } from 'web/connections';

@Component({
  selector: 'skylight-weather-event-alerts-card',
  standalone: true,
  imports: [InfoCardComponent, WeatherEventAlertButtonComponent, WeatherEventAlertWindowComponent],
  templateUrl: './weather-event-alerts-card.component.html',
  styleUrl: './weather-event-alerts-card.component.scss',
})
export class WeatherEventAlertsCardComponent implements OnInit {
  @Input({ required: true })
  public weatherEventId!: string;

  @ViewChild('alertWindow')
  private alertWindow!: TemplateRef<NbWindowComponent>;

  public loading: boolean = true;
  public showAdvisories: boolean = false;
  public alerts: NewWeatherEventAlert[] = [];
  public contextMenu: ContextMenu = new ContextMenu(`${WeatherEventAlertsCardComponent}Menu`, [
    {
      item: {
        title: 'Toggle Advisories',
      },
      action: () => {
        this.showAdvisories = !this.showAdvisories;
      },
    },
  ]);

  constructor(
    private readonly eventBus: EventBusService,
    private readonly service: WeatherEventService,
    private readonly weatherEventHub: WeatherEventHubConnectionService,
    private readonly windowService: NbWindowService,
    private readonly parenthesesWrapPipe: ParenthesesWrapPipe,
  ) {}

  public get alertCount(): number {
    return this.alerts.filter((x) => this.canDisplayAlert(x)).length;
  }

  public ngOnInit(): void {
    if (environment.enableAutoNwsApiCalls) {
      this.getWeatherAlerts();
    } else {
      this.loading = false;
      console.log('Call to fetch Weather Alerts blocked by environment configuration.');
    }

    this.weatherEventHub.newWeatherAlerts.subscribe((x) => {
      this.alerts = x.newWeatherEventAlerts.map((a) => NewWeatherEventAlert.fromHub(a));
    });
  }

  public canDisplayAlert(alert: NewWeatherEventAlert): boolean {
    let output: boolean = true;

    output = alert.level !== WeatherAlertLevel.Advisory || this.showAdvisories;

    return output;
  }

  public getWeatherAlerts(): void {
    this.alerts = [];
    this.loading = true;

    this.eventBus.emit(new WeatherAlertsRefreshedEvent());

    this.service.getWeatherAlerts(this.weatherEventId).subscribe({
      next: (result) => {
        this.alerts = result;
        this.loading = false;

        for (const alert of result) {
          this.eventBus.emit(new WeatherAlertAddedEvent(alert));
        }
      },
      error: () => {
        console.error(`Failed to fetch Weather Alerts for Weather Event ID ${this.weatherEventId}`);
        this.loading = false;
      },
    });
  }

  public openWeatherAlert(alert: NewWeatherEventAlert): void {
    this.windowService.open(this.alertWindow, {
      title: `${alert.name.toUpperCase()} ${this.parenthesesWrapPipe.transform(alert.code)}`,
      context: alert,
      buttons: {
        minimize: true,
        maximize: false,
        fullScreen: false,
        close: true,
      },
    });
  }
}
