import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NbAccordionComponent, NbAccordionModule, NbButtonModule, NbListModule } from '@nebular/theme';
import { InfoCardComponent } from 'shared/components';
import { EventBusService } from 'shared/services';
import { WeatherEventAlertButtonComponent } from 'pages/weather-event-page/components';
import { WeatherAlertLevel, WeatherEventAlertLocation } from 'pages/weather-event-page/models';
import { WeatherAlertAddedEvent, WeatherAlertsRefreshedEvent } from 'pages/weather-event-page/events';
import { StateNamePipe } from 'shared/pipes';
import { DarkenDirective } from 'shared/directives';

type LocationGroup = {
  state: string,
  locations: WeatherEventAlertLocation[]
};

@Component({
  selector: 'skylight-weather-event-locations-card',
  standalone: true,
  imports: [
    NbAccordionModule,
    NbButtonModule,
    NbListModule,
    InfoCardComponent,
    WeatherEventAlertButtonComponent,
    DarkenDirective,
    StateNamePipe
  ],
  templateUrl: './weather-event-locations-card.component.html',
  styleUrl: './weather-event-locations-card.component.scss'
})
export class WeatherEventLocationsCardComponent implements OnInit {
  private readonly defaultLocationName: string = 'Other';
  
  @Input({ required: true }) public weatherEventId!: string;
  @ViewChild('locationGroupsElement') public locationGroupsElement?: NbAccordionComponent;

  public locations: WeatherEventAlertLocation[] = [];

  constructor(
    private readonly eventBus: EventBusService
  ) { }

  public get locationCount(): number {
    return this.locations.length;
  }

  public get locationGroupsCount(): number {
    return this.locations
      .map(x => x.state ?? this.defaultLocationName)
      .filter((x, i, values) => values.indexOf(x) === i)
      .length;
  }

  public get locationGroups(): LocationGroup[] {
    return this.locations
      .reduce<LocationGroup[]>((prev, curr) => {
        const state: string = curr.state ?? this.defaultLocationName;
        const existingGroup: LocationGroup | undefined = prev.find(x => x.state === state)

        if (existingGroup) {
          if (!existingGroup.locations.find(x => x.name === curr.name)) {
            existingGroup.locations.push(curr);
          }
        } else {
          prev.push({
            state: state,
            locations: [curr]
          });
        }

        prev
          .find(x => x.state === state)?.locations
          .sort((x, y) => x.name.localeCompare(y.name));

        return prev;
      }, [])
      .sort((x, y) => x.state.localeCompare(y.state));
  }

  public ngOnInit(): void {
    this.eventBus.handle(WeatherAlertsRefreshedEvent)
      .subscribe(() => this.locations = []);

    this.eventBus.handle(WeatherAlertAddedEvent)
      .subscribe(event => {
        event.alert.locations?.forEach(l => {
          if (![WeatherAlertLevel.None, WeatherAlertLevel.Advisory].find(x => x === event.alert.level)) {
            this.locations.push(l)
          }
        })
      });
  }

  public collapseAll(): void {
    this.locationGroupsElement?.closeAll();
  }

  public expandAll(): void {
    this.locationGroupsElement?.openAll();
  }
}

