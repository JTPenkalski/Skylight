import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NbActionsModule, NbCardModule, NbContextMenuModule, NbMenuItem, NbMenuService, NbSpinnerModule, NbTooltipModule } from '@nebular/theme';
import { filter } from 'rxjs/operators';
import { WeatherEventHubConnectionService } from 'web/connections';
import { environment } from 'environments/environment';
import { NewWeatherEventAlert, WeatherAlertLevel } from 'pages/weather-event-page/models';
import { WeatherEventService } from 'pages/weather-event-page/services';
import { WeatherEventAlertButtonComponent } from '..';
import { ContextMenu } from 'shared/models';

@Component({
  selector: 'skylight-weather-event-alerts-card',
  standalone: true,
  imports: [
    NbActionsModule,
    NbCardModule,
    NbContextMenuModule,
    NbSpinnerModule,
    NbTooltipModule,
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
  public moreMenu: ContextMenu = new ContextMenu(
    'skylight-weather-event-alerts-card-more-menu',
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
    private readonly service: WeatherEventService,
    private readonly weatherEventHub: WeatherEventHubConnectionService,
    private readonly menuService: NbMenuService
  ) { }

  public get alertCount(): number {
    return this.alerts
      .filter(x => this.canDisplayAlert(x))
      .length;
  }

  public ngOnInit(): void {
    if (environment.enableAutoNwsApiCalls) {
      this.onRefresh();
    } else {
      this.loading = false;
      console.log('Call to fetch Weather Alerts blocked by environment configuration.');
    }

    this.weatherEventHub.newWeatherAlerts.subscribe(x => {
      this.alerts = x.newWeatherEventAlerts.map(a => NewWeatherEventAlert.fromHub(a));
    });

    this.menuService.onItemClick()
      .subscribe(x => this.moreMenu.handle(x));
  }

  public canDisplayAlert(alert: NewWeatherEventAlert): boolean {
    let output: boolean = true;

    output = alert.level !== WeatherAlertLevel.Advisory || this.showAdvisories;

    return output;
  }

  public onRefresh(): void {
    this.alerts = [];
    this.loading = true;

    this.service
      .fetchWeatherAlerts(this.weatherEventId)
      .subscribe({
        next: result => {
          this.alerts = result;
          this.loading = false;
        },
        error: () => {
          console.error(`Failed to fetch Weather Alerts for Weather Event ID ${this.weatherEventId}`);
          this.loading = false
        }
      });
  }

  public onClick(alert: NewWeatherEventAlert): void {
    this.alertSelected.emit(alert);
  }
}
