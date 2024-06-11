import { Injectable } from '@angular/core';
import { Observable, flatMap, map, mergeMap } from 'rxjs';
import { AddWeatherEventParticipantCommand, FetchWeatherAlertsCommand, GetWeatherAlertsByEventIdQuery, GetWeatherEventByIdQuery, ParticipationMethod, SkylightClient } from 'web/clients';
import { NewWeatherEventAlert, WeatherEventAlert, WeatherEventSummary } from 'pages/weather-event-page/models';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventService {
  constructor(private readonly client: SkylightClient) { }

  public getWeatherEventSummary(id: string): Observable<WeatherEventSummary> {
    const request: GetWeatherEventByIdQuery = {
      id: id
    };

    return this.client.getWeatherEventById(request).pipe(
      map(result => WeatherEventSummary.fromApi(result))
    );
  }

  public trackWeatherEvent(weatherEventId: string, stormTrackerId: string): Observable<void> {
    const request: AddWeatherEventParticipantCommand = {
      weatherEventId: weatherEventId,
      stormTrackerId: stormTrackerId,
      participationMethod: ParticipationMethod.Tracked
    };

    return this.client.addWeatherEventParticipant(request);
  }

  public fetchWeatherAlerts(weatherEventId: string): Observable<NewWeatherEventAlert[]> {
    const fetchWeatherAlertsRequest: FetchWeatherAlertsCommand = {
      weatherEventId: weatherEventId
    };

    const getWeatherAlertsRequest: GetWeatherAlertsByEventIdQuery = {
      weatherEventId: weatherEventId
    };

    return this.client.fetchWeatherAlerts(fetchWeatherAlertsRequest).pipe(
      mergeMap(() => this.client.getWeatherAlertsByEventId(getWeatherAlertsRequest)),
      map(result =>
        result.weatherEventAlerts?.map(x =>
          WeatherEventAlert.fromApi(x)
        ) ?? []
      )
    );
  }
}
