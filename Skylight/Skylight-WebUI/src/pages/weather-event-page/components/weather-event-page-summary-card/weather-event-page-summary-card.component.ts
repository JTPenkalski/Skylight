import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NbButtonModule, NbCardModule, NbIconModule, NbSpinnerModule, NbTooltipModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { IconCardComponent, TabContainerComponent } from 'shared/components';
import { WeatherEventSummary } from 'pages/weather-event-page/models';
import { WeatherEventService } from 'pages/weather-event-page/services';

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
    CurrencyPipe,
    DatePipe,
  ],
  templateUrl: './weather-event-page-summary-card.component.html',
  styleUrl: './weather-event-page-summary-card.component.scss'
})
export class WeatherEventPageSummaryCardComponent implements OnInit {
  @Input({ required: true }) public weatherEventId!: string;
  
  public summary!: WeatherEventSummary;
  public loading: boolean = true;
  public isTracking: boolean = false;

  constructor(private readonly service: WeatherEventService) { }

  get isActive(): boolean { return !this.summary.endDate; }

  public ngOnInit(): void {
    this.service
      .getWeatherEventSummary(this.weatherEventId)
      .subscribe({
        next: result => {
          this.summary = result;
          this.loading = false;
        },
        error: () => {
          console.error(`Failed to fetch Weather Event ID ${this.weatherEventId}`);
          this.loading = false
        }
      });
  }

  public toggleTracking(): void {
    this.isTracking = !this.isTracking;

    if (this.isTracking) {
      this.service
        .trackWeatherEvent(this.weatherEventId, '472e9768-f238-49d5-8948-b1bca50e7bb9')
        .subscribe();
    }
  }
}
