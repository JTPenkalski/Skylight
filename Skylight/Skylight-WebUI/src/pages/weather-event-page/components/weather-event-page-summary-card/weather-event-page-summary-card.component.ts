import { Component, Input } from '@angular/core';
import { NbButtonModule, NbCardModule, NbIconModule, NbSpinnerModule, NbTooltipModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { DatePipe } from '@angular/common';
import { IconCardComponent, TabContainerComponent } from 'shared/components';
import { WeatherEventSummary } from 'pages/weather-event-page/models';

@Component({
  selector: 'skylight-weather-event-page-summary-card',
  standalone: true,
  imports: [
    NbButtonModule,
    NbCardModule,
    NbEvaIconsModule,
    NbIconModule,
    NbSpinnerModule,
    NbTooltipModule,
    TabContainerComponent,
    IconCardComponent,
    DatePipe,
  ],
  templateUrl: './weather-event-page-summary-card.component.html',
  styleUrl: './weather-event-page-summary-card.component.scss'
})
export class WeatherEventPageSummaryCardComponent {
  @Input({required: true}) public summary!: WeatherEventSummary;

  get isActive(): boolean { return !this.summary.endDate; }
}
