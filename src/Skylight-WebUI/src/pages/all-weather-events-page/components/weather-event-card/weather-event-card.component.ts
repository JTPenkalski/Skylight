import { CurrencyPipe, DatePipe } from '@angular/common';
import {
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import {
  NbBadgeModule,
  NbButtonModule,
  NbCardModule,
  NbIconModule,
} from '@nebular/theme';
import { WeatherEventSummary } from 'pages/all-weather-events-page/models';
import { IconCardComponent } from 'shared/components';

@Component({
  selector: 'skylight-weather-event-card',
  standalone: true,
  imports: [
    NbBadgeModule,
    NbButtonModule,
    NbCardModule,
    NbEvaIconsModule,
    NbIconModule,
    IconCardComponent,
    CurrencyPipe,
    DatePipe,
  ],
  templateUrl: './weather-event-card.component.html',
  styleUrl: './weather-event-card.component.scss',
})
export class WeatherEventCardComponent {
  @Input({ required: true })
  public summary!: WeatherEventSummary;

  @Output()
  public navigated: EventEmitter<string> =
    new EventEmitter<string>();

  public get isActive(): boolean {
    return !this.summary.endDate;
  }

  public navigate(): void {
    this.navigated.emit(this.summary.id);
  }
}
