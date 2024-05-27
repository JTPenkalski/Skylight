import { Component, TemplateRef, ViewChild } from '@angular/core';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NbActionsModule, NbButtonModule, NbCardModule, NbIconModule, NbSpinnerModule, NbWindowService } from '@nebular/theme';
import { NewWeatherEventAlert } from 'pages/weather-event-page/models';
import { WeatherEventAlertButtonComponent, WeatherEventAlertWindowComponent, WeatherEventAlertsCardComponent } from '..';
import { ParenthesesWrapPipe } from 'shared/pipes';

@Component({
  selector: 'skylight-weather-event-page-card-container',
  standalone: true,
  imports: [
    NbActionsModule,
    NbButtonModule,
    NbCardModule,
    NbEvaIconsModule,
    NbIconModule,
    NbSpinnerModule,
    WeatherEventAlertButtonComponent,
    WeatherEventAlertsCardComponent,
    WeatherEventAlertWindowComponent
  ],
  providers: [
    ParenthesesWrapPipe
  ],
  templateUrl: './weather-event-page-card-container.component.html',
  styleUrl: './weather-event-page-card-container.component.scss'
})
export class WeatherEventPageCardContainerComponent {
  @ViewChild('alertWindow') private alertWindow!: TemplateRef<any>;

  constructor(
    private readonly windowService: NbWindowService,
    private readonly parenthesesWrapPipe: ParenthesesWrapPipe
  ) { }

  public onAlertSelected(alert: NewWeatherEventAlert): void {
    this.windowService.open(this.alertWindow, {
      title: `${alert.name.toUpperCase()} ${this.parenthesesWrapPipe.transform(alert.code)}`,
      context: alert,
      buttons: {
        minimize: true,
        maximize: false,
        fullScreen: false,
        close: true,
      }
    });
  }
}
