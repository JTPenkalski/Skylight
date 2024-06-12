import { Component, Input, OnInit } from '@angular/core';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { NbButtonModule, NbCardModule, NbIconModule, NbSpinnerModule, NbTooltipModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { IconCardComponent, TabContainerComponent } from 'shared/components';
import { EventBusService, User, UserService } from 'shared/services';
import { ParticipantAddedEvent, ParticipantRemovedEvent } from 'pages/weather-event-page/events';
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
  
  public user?: User;
  public summary!: WeatherEventSummary;
  public loading: boolean = true;
  public isTracking: boolean = false;

  constructor(
    private readonly userService: UserService,
    private readonly service: WeatherEventService,
    private readonly eventBus: EventBusService
  ) { }

  get isActive(): boolean { return !this.summary.endDate; }

  public ngOnInit(): void {
    this.userService.currentUserChanged
      .subscribe(result => this.user = result);

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
    if (!this.user) return;

    const stormTrackerId = this.user.stormTrackerId;

    if (this.isTracking) {
      this.service
        .untrackWeatherEvent(this.weatherEventId, stormTrackerId)
        .subscribe(result => {
          if (result) {
            this.isTracking = false;

            this.eventBus.emit(new ParticipantRemovedEvent(stormTrackerId))
          }
        });
    } else {
      this.service
        .trackWeatherEvent(this.weatherEventId, stormTrackerId)
        .subscribe(result => {
          if (result) {
            this.isTracking = true;

            this.eventBus.emit(new ParticipantAddedEvent(stormTrackerId))
          }
        });
    }
  }
}
