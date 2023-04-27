import { Inject, Injectable } from '@angular/core';
import { Observable, map, of } from 'rxjs';

import { IWeatherService } from 'core/services';
import { Weather } from 'presentation/models';
import { IWeatherClient, WeatherClient, Weather as WeatherWebModel } from 'web/clients';
import { BaseService } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherService extends BaseService<Weather> implements IWeatherService {
  constructor(@Inject(WeatherClient) protected client: IWeatherClient) { super(); }

  public add(model: Weather): Observable<Weather | null> {
    return this.client.weatherPOST(new WeatherWebModel(model)).pipe(
      map(result => new Weather(result))
    );
  }

  public get(id: number): Observable<Weather> {
    return this.client.weatherGET(id).pipe(
      map(result => new Weather(result))
    );
  }

  public getAll(): Observable<Weather[]> {
    return this.client.weatherAll().pipe(
      map(results => results.map(result => new Weather(result)))
    );
  }

  public modify(id: number, model: Weather) : Observable<boolean> {
    this.client.weatherPUT(id, new WeatherWebModel(model));
    return of(true); // TODO: Status response
  }

  public remove(id: number): Observable<boolean> {
    this.client.weatherDELETE(id);
    return of(true); // TODO: Status response
  }
}