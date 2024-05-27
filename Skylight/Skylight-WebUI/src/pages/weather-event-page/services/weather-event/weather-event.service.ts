import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { AddWeatherEventParticipantCommand, FetchWeatherAlertsCommand, GetWeatherEventByIdQuery, ParticipationMethod, SkylightClient, WeatherAlertLevel as WebWeatherAlertLevel } from 'web/clients';
import { NewWeatherEventAlert, WeatherAlertLevel, WeatherEventSummary } from '../../models';

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
      map(result => {
        return new WeatherEventSummary(
          result.name!,
          result.description!,
          result.startDate!,
          result.endDate,
          result.damageCost,
          result.affectedPeople
        );
      })
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
      map(result => result.newWeatherEventAlerts?.map(x => new NewWeatherEventAlert(
        x.sender!,
        x.headline!,
        x.instruction!,
        x.description!,
        x.sent!,
        x.effective!,
        x.expires!,
        x.name!,
        x.source!,
        this.mapWeatherAlertLevel(x.level),
        x.code
      )) ?? [])
    );
  }

  private mapWeatherAlertLevel(webWeatherAlertLevel?: WebWeatherAlertLevel): WeatherAlertLevel {
    switch (webWeatherAlertLevel) {
      case WebWeatherAlertLevel.Warning: return WeatherAlertLevel.Warning;
      case WebWeatherAlertLevel.Watch: return WeatherAlertLevel.Watch;
      case WebWeatherAlertLevel.Advisory: return WeatherAlertLevel.Advisory;
      default: return WeatherAlertLevel.None;
    }
  }
}
