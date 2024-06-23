import { Component, Input, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import {
  NbCardModule,
  NbComponentStatus,
  NbIconModule,
  NbUserModule,
} from '@nebular/theme';
import { InfoCardComponent } from 'shared/components';
import { EventBusService } from 'shared/services';
import { WeatherEventHubConnectionService } from 'web/connections';
import {
  ParticipantAddedEvent,
  ParticipantRemovedEvent,
} from 'pages/weather-event-page/events';
import {
  ParticipationMethod,
  WeatherEventParticipant,
} from 'pages/weather-event-page/models';
import { WeatherEventService } from 'pages/weather-event-page/services';

@Component({
  selector: 'skylight-weather-event-participants-card',
  standalone: true,
  imports: [
    NbCardModule,
    NbEvaIconsModule,
    NbIconModule,
    NbUserModule,
    InfoCardComponent,
    DatePipe,
  ],
  templateUrl:
    './weather-event-participants-card.component.html',
  styleUrl: './weather-event-participants-card.component.scss',
})
export class WeatherEventParticipantsCardComponent
  implements OnInit
{
  @Input({ required: true }) public weatherEventId!: string;

  public loading: boolean = true;
  public participants: WeatherEventParticipant[] = [];

  constructor(
    private readonly eventBus: EventBusService,
    private readonly service: WeatherEventService,
    private readonly weatherEventHub: WeatherEventHubConnectionService,
  ) {}

  public get participantCount(): number {
    return this.participants.length;
  }

  public ngOnInit(): void {
    this.getParticipants();

    // TODO: Get individual info from API?
    this.eventBus
      .handle(ParticipantAddedEvent)
      .subscribe((event) => this.getParticipants());

    this.eventBus
      .handle(ParticipantRemovedEvent)
      .subscribe((event) => this.getParticipants());

    // this.weatherEventHub.newWeatherAlerts.subscribe(x => {
    //   this.participants = x.newWeatherEventAlerts.map(a => NewWeatherEventAlert.fromHub(a));
    // });
  }

  public getParticipantAccent(
    participant: WeatherEventParticipant,
  ): NbComponentStatus {
    switch (participant.participationMethod) {
      case ParticipationMethod.Chased:
        return 'success';
      case ParticipationMethod.Reported:
        return 'info';
      default:
        return 'basic';
    }
  }

  public getParticipantIcon(
    participant: WeatherEventParticipant,
  ): string {
    switch (participant.participationMethod) {
      case ParticipationMethod.Chased:
        return 'car';
      case ParticipationMethod.Reported:
        return 'file';
      default:
        return 'eye';
    }
  }

  public getParticipants(): void {
    this.participants = [];
    this.loading = true;

    this.service
      .getParticipants(this.weatherEventId)
      .subscribe({
        next: (result) => {
          this.participants = result;
          this.loading = false;
        },
        error: () => {
          console.error(
            `Failed to fetch Weather Event Participants for Weather Event ID ${this.weatherEventId}`,
          );
          this.loading = false;
        },
      });
  }
}
