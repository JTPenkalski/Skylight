import { Component, Input } from '@angular/core';
import { WeatherEventPageCardContainerComponent, WeatherEventPageSummaryCardComponent } from './components';
import { WeatherEventService } from './services';
import { NbCardModule, NbSpinnerModule } from '@nebular/theme';

@Component({
  selector: 'skylight-weather-event-page',
  standalone: true,
  imports: [
    NbCardModule,
    NbSpinnerModule,
    WeatherEventPageCardContainerComponent,
    WeatherEventPageSummaryCardComponent
  ],
  templateUrl: './weather-event-page.component.html',
  styleUrl: './weather-event-page.component.scss'
})
export class WeatherEventPageComponent {
  @Input() public id!: string;

  constructor(private readonly service: WeatherEventService) { }

  public requestTrack(track: boolean): void {
    if (track) {
      this.service
        .trackWeatherEvent(this.id, '472e9768-f238-49d5-8948-b1bca50e7bb9')
        .subscribe();
    }
  }
}
