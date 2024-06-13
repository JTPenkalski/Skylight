import { Injectable } from '@angular/core';
import { Observable, map, mergeMap } from 'rxjs';
import { AddWeatherEventParticipantCommand, FetchWeatherAlertsCommand, GetWeatherAlertsByEventIdQuery, GetWeatherEventByIdQuery, GetWeatherEventParticipantsByEventIdQuery, GetWeatherEventParticipantStatusQuery, ParticipationMethod, RemoveWeatherEventParticipantCommand, SkylightClient } from 'web/clients';
import { NewWeatherEventAlert, WeatherEventAlert, WeatherEventParticipant, WeatherEventParticipantStatus, WeatherEventSummary } from 'pages/weather-event-page/models';

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

  public trackWeatherEvent(weatherEventId: string, stormTrackerId: string): Observable<boolean> {
    const request: AddWeatherEventParticipantCommand = {
      weatherEventId: weatherEventId,
      stormTrackerId: stormTrackerId,
      participationMethod: ParticipationMethod.Tracked
    };

    return this.client.addWeatherEventParticipant(request).pipe(
      map(result => {
        return !!result.added;
      })
    );
  }

  public untrackWeatherEvent(weatherEventId: string, stormTrackerId: string): Observable<boolean> {
    const request: RemoveWeatherEventParticipantCommand = {
      weatherEventId: weatherEventId,
      stormTrackerId: stormTrackerId
    };

    return this.client.removeWeatherEventParticipant(request).pipe(
      map(result => !!result.removed)
    );
  }

  public getWeatherAlerts(weatherEventId: string): Observable<NewWeatherEventAlert[]> {
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

  public getParticipants(weatherEventId: string): Observable<WeatherEventParticipant[]> {
    const request: GetWeatherEventParticipantsByEventIdQuery = {
      weatherEventId: weatherEventId
    };

    return this.client.getWeatherEventParticipantsByEventId(request).pipe(
      map(result => 
        result.weatherEventParticipants?.map(x =>
          WeatherEventParticipant.fromApi(x)
        ) ?? []
      )
    );
  }

  public getParticipantStatus(stormTrackerId: string, weatherEventId: string): Observable<WeatherEventParticipantStatus | undefined> {
    const request: GetWeatherEventParticipantStatusQuery = {
      stormTrackerId: stormTrackerId,
      weatherEventId: weatherEventId
    };

    return this.client.getWeatherEventParticipantsStatus(request).pipe(
      map(result => WeatherEventParticipantStatus.fromApi(result))
    );
  }
}
