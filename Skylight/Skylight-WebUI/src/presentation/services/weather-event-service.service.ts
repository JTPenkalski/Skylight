import { Inject, Injectable } from '@angular/core';
import { Observable, map, of } from 'rxjs';

import { IWeatherEventService } from 'core/services';
import { WeatherEvent } from 'presentation/models';
import { IWeatherEventClient, WeatherEventClient, WeatherEvent as WeatherEventWebModel } from 'web/clients';
import { BaseService } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventService extends BaseService<WeatherEvent> implements IWeatherEventService {
  constructor(@Inject(WeatherEventClient) protected client: IWeatherEventClient) { super(); }

  public add(model: WeatherEvent): Observable<WeatherEvent | null> {
    return this.client.weatherEventPOST(new WeatherEventWebModel(model)).pipe(
      map(result => new WeatherEvent(result))
    );
  }

  public get(id: number): Observable<WeatherEvent> {
    return this.client.weatherEventGET(id).pipe(
      map(result => new WeatherEvent(result))
    );
  }

  public getAll(): Observable<WeatherEvent[]> {
    return this.client.weatherEventAll().pipe(
      map(results => results.map(result => new WeatherEvent(result)))
    );
  }

  public modify(id: number, model: WeatherEvent) : Observable<boolean> {
    this.client.weatherEventPUT(id, new WeatherEventWebModel(model));
    return of(true); // TODO: Status response
  }

  public remove(id: number): Observable<boolean> {
    this.client.weatherEventDELETE(id);
    return of(true); // TODO: Status response
  }
}