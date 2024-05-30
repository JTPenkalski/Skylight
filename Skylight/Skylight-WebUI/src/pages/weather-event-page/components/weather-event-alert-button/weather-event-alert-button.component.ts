import { DatePipe } from '@angular/common';
import { Component, Input } from '@angular/core';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NbButtonModule, NbIconModule } from '@nebular/theme';
import { WeatherAlertLevel, NewWeatherEventAlert } from 'pages/weather-event-page/models';

@Component({
  selector: 'skylight-weather-event-alert-button',
  standalone: true,
  imports: [
    NbButtonModule,
    NbEvaIconsModule,
    NbIconModule,
    DatePipe
  ],
  templateUrl: './weather-event-alert-button.component.html',
  styleUrl: './weather-event-alert-button.component.scss'
})
export class WeatherEventAlertButtonComponent {
  @Input({ required: true }) public alert!: NewWeatherEventAlert;

  public get status(): string {
    switch (this.alert.level) {
      case WeatherAlertLevel.Warning: return "danger";
      case WeatherAlertLevel.Watch: return "warning";
      default: return "info";
    }
  }

  public get icon(): string {
    switch (this.alert.level) {
      case WeatherAlertLevel.Warning: return "alert-triangle";
      case WeatherAlertLevel.Watch: return "alert-circle";
      case WeatherAlertLevel.Advisory: return "info";
      default: return "question-mark-circle";
    }
  }
}
