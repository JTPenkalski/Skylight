import { CurrencyPipe, DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import {
  NbBadgeModule,
  NbButtonModule,
  NbCardModule,
  NbIconModule,
  NbListModule,
} from '@nebular/theme';
import { WeatherEventSummary } from 'pages/all-weather-events-page/models';
import { IconCardComponent } from 'shared/components';
import { WeatherEventCardComponent } from './components';
import { AllWeatherEventsService } from './services';

@Component({
  selector: 'skylight-all-weather-events-page',
  standalone: true,
  imports: [
    NbBadgeModule,
    NbButtonModule,
    NbCardModule,
    NbEvaIconsModule,
    NbIconModule,
    NbListModule,
    IconCardComponent,
    WeatherEventCardComponent,
    CurrencyPipe,
    DatePipe,
  ],
  templateUrl: './all-weather-events-page.component.html',
  styleUrl: './all-weather-events-page.component.scss',
})
export class AllWeatherEventsPageComponent implements OnInit {
  public summaries!: WeatherEventSummary[];

  constructor(
    private readonly router: Router,
    private readonly service: AllWeatherEventsService,
  ) {}

  public ngOnInit(): void {
    this.service.getAllWeatherEvents().subscribe((result) => {
      this.summaries = result.sort((x, y) => -x.startDate.getTime() - y.startDate.getTime());
    });
  }

  public navigateToEvent(id: string): void {
    this.router.navigate(['/weather-event'], {
      queryParams: { id: id },
    });
  }
}
