import { DatePipe } from '@angular/common';
import { Component, Input } from '@angular/core';
import { NbCardModule, NbTooltipModule, NbUserModule } from '@nebular/theme';
import { NewWeatherEventAlert } from 'pages/weather-event-page/models';
import { IconCardComponent } from 'shared/components';

@Component({
  selector: 'skylight-weather-event-alert-window',
  standalone: true,
  imports: [
    NbCardModule,
    NbTooltipModule,
    NbUserModule,
    DatePipe,
    IconCardComponent
  ],
  templateUrl: './weather-event-alert-window.component.html',
  styleUrl: './weather-event-alert-window.component.scss'
})
export class WeatherEventAlertWindowComponent {
  @Input() public alert!: NewWeatherEventAlert;

  public get senderPicture(): string {
    switch (this.alert.source.toUpperCase()) {
      case 'NATIONAL WEATHER SERVICE': return "https://upload.wikimedia.org/wikipedia/commons/f/ff/US-NationalWeatherService-Logo.svg";
      default: return '';
    }
  }
}
