import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component, Input, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import {
  NbButtonGroupModule,
  NbButtonModule,
  NbCardModule,
  NbIconModule,
  NbSpinnerModule,
  NbTooltipModule,
  NbWindowComponent,
  NbWindowRef,
  NbWindowService,
} from '@nebular/theme';
import { ParticipantAddedEvent, ParticipantRemovedEvent } from 'pages/weather-event-page/events';
import { ParticipationMethod, WeatherEventSummary } from 'pages/weather-event-page/models';
import { WeatherEventService } from 'pages/weather-event-page/services';
import { IconCardComponent, TabContainerComponent } from 'shared/components';
import { EventBusService, User, UserService } from 'shared/services';
import { WeatherEventAddTagWindowComponent } from '../weather-event-add-tag-window/weather-event-add-tag-window.component';

@Component({
  selector: 'skylight-weather-event-page-summary-card',
  standalone: true,
  imports: [
    NbButtonModule,
    NbButtonGroupModule,
    NbCardModule,
    NbEvaIconsModule,
    NbIconModule,
    NbSpinnerModule,
    NbTooltipModule,
    IconCardComponent,
    TabContainerComponent,
    WeatherEventAddTagWindowComponent,
    CurrencyPipe,
    DatePipe,
  ],
  templateUrl: './weather-event-page-summary-card.component.html',
  styleUrl: './weather-event-page-summary-card.component.scss',
})
export class WeatherEventPageSummaryCardComponent implements OnInit {
  @Input({ required: true })
  public weatherEventId!: string;

  @ViewChild('addTagWindow')
  private addTagWindowRef!: TemplateRef<NbWindowComponent>;

  public user?: User;
  public summary!: WeatherEventSummary;
  public loading: boolean = true;
  public isTracking: boolean = false;
  public addTagWindow?: NbWindowRef;

  constructor(
    private readonly windowService: NbWindowService,
    private readonly userService: UserService,
    private readonly service: WeatherEventService,
    private readonly eventBus: EventBusService,
  ) {}

  public get isActive(): boolean {
    return !this.summary.endDate;
  }

  public ngOnInit(): void {
    this.userService.currentUserChanged.subscribe((result) => {
      this.user = result;

      if (this.user) {
        this.service.getParticipantStatus(this.user.stormTrackerId, this.weatherEventId).subscribe({
          next: (result) => {
            if (result) {
              this.isTracking = result.participationMethod === ParticipationMethod.Tracked;
            }
          },
          error: () => {
            this.isTracking = false;
          },
        });
      }
    });

    this.service.getWeatherEventSummary(this.weatherEventId).subscribe({
      next: (result) => {
        this.summary = result;
        this.loading = false;
      },
      error: () => {
        console.error(`Failed to fetch Weather Event ID ${this.weatherEventId}`);
        this.loading = false;
      },
    });
  }

  public toggleTracking(): void {
    if (!this.user) return;

    const stormTrackerId = this.user.stormTrackerId;

    if (this.isTracking) {
      this.service.untrackWeatherEvent(this.weatherEventId, stormTrackerId).subscribe((result) => {
        if (result) {
          this.isTracking = false;

          this.eventBus.emit(new ParticipantRemovedEvent(stormTrackerId));
        }
      });
    } else {
      this.service.trackWeatherEvent(this.weatherEventId, stormTrackerId).subscribe((result) => {
        if (result) {
          this.isTracking = true;

          this.eventBus.emit(new ParticipantAddedEvent(stormTrackerId));
        }
      });
    }
  }

  public tryAddTag(): void {
    this.addTagWindow = this.windowService.open(this.addTagWindowRef, {
      title: 'Add Tag',
      context: {
        weatherEventId: this.weatherEventId,
      },
      buttons: {
        minimize: false,
        maximize: false,
        fullScreen: false,
        close: true,
      },
    });
  }

  public confirmAddTag(): void {
    this.addTagWindow?.close();

    this.addTagWindow = undefined;
  }
}
