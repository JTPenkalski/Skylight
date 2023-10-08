import { Inject, Injectable } from '@angular/core';
import { Observable, map, of } from 'rxjs';

import { IWeatherService } from 'core/services';
import { Weather } from 'presentation/models';
import { FormGuideContext, IWeatherClient, WeatherClient, Weather as WeatherWebModel } from 'web/clients';
import { BaseService } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherService extends BaseService<Weather> implements IWeatherService {
  constructor(@Inject(WeatherClient) protected client: IWeatherClient) { super(); }

  public override add(model: Weather): Observable<Weather | null> {
    return this.client.weatherPOST(new WeatherWebModel(model)).pipe(
      map(result => new Weather(result))
    );
  }

  public override get(id: number): Observable<Weather> {
    return this.client.weatherGET(id).pipe(
      map(result => new Weather(result))
    );
  }

  public override getAll(): Observable<Weather[]> {
    return this.client.weatherAll().pipe(
      map(results => results.map(result => new Weather(result)))
    );
  }

  public override getFormGuide(model: Weather, context?: FormGuideContext): Observable<undefined> {
    // Probably need to define new Guides/Directors on the backend when implementing this...
    throw new Error('Method not implemented.');
  }

  public override modify(id: number, model: Weather) : Observable<boolean> {
    this.client.weatherPUT(id, new WeatherWebModel(model));
    return of(true); // TODO: Status response
  }

  public override remove(id: number): Observable<boolean> {
    this.client.weatherDELETE(id);
    return of(true); // TODO: Status response
  }
}