import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { AddWeatherEventParticipantCommand, FetchWeatherAlertsCommand, GetWeatherEventByIdQuery, ParticipationMethod, SkylightClient } from 'web/clients';
import { NewWeatherEventAlert, WeatherEventSummary } from '../../models';

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
    const request: FetchWeatherAlertsCommand = {
      weatherEventId: weatherEventId
    };

    return this.client.fetchWeatherAlerts(request).pipe(
      map(result =>
        result.newWeatherEventAlerts?.map(x =>
          NewWeatherEventAlert.fromApi(x)
        ) ?? []
      )
    );
  }
}
