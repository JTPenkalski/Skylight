import { Injectable } from '@angular/core';
import { WeatherEventSummary } from 'pages/all-weather-events-page/models';
import { Observable, map } from 'rxjs';
import {
  GetAllWeatherEventsQuery,
  SkylightClient,
} from 'web/clients';

@Injectable({
  providedIn: 'root',
})
export class AllWeatherEventsService {
  constructor(private readonly client: SkylightClient) {}

  public getAllWeatherEvents(): Observable<
    WeatherEventSummary[]
  > {
    const request: GetAllWeatherEventsQuery = {};

    return this.client
      .getAllWeatherEvents(request)
      .pipe(
        map((result) => WeatherEventSummary.fromApi(result)),
      );
  }
}
