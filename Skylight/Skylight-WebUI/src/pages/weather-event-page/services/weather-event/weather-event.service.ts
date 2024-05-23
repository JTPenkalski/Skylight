import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { GetWeatherEventByIdQuery, SkylightClient } from 'web/clients';
import { WeatherEventSummary } from '../../models';

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
}
