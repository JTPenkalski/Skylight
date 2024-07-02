import { Component, Input } from '@angular/core';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import {
  NbActionsModule,
  NbButtonModule,
  NbCardModule,
  NbIconModule,
  NbSpinnerModule,
} from '@nebular/theme';
import {
  WeatherEventAlertsCardComponent,
  WeatherEventLocationsCardComponent,
} from 'pages/weather-event-page/components';
import { ParenthesesWrapPipe } from 'shared/pipes';
import { WeatherEventParticipantsCardComponent } from '../weather-event-participants-card/weather-event-participants-card.component';

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
    WeatherEventAlertsCardComponent,
    WeatherEventLocationsCardComponent,
    WeatherEventParticipantsCardComponent,
  ],
  providers: [ParenthesesWrapPipe],
  templateUrl: './weather-event-page-card-container.component.html',
  styleUrl: './weather-event-page-card-container.component.scss',
})
export class WeatherEventPageCardContainerComponent {
  @Input({ required: true })
  public weatherEventId!: string;
}
