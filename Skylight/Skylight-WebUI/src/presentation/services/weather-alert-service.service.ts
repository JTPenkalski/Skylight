import { Inject, Injectable } from '@angular/core';
import { Observable, map, of } from 'rxjs';

import { IWeatherAlertService } from 'core/services';
import { WeatherAlert } from 'presentation/models';
import { FormGuideContext, IWeatherAlertClient, WeatherAlertClient, WeatherAlert as WeatherAlertWebModel } from 'web/clients';
import { BaseService } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherAlertService extends BaseService<WeatherAlert> implements IWeatherAlertService {
  constructor(@Inject(WeatherAlertClient) protected client: IWeatherAlertClient) { super(); }

  public override add(model: WeatherAlert): Observable<WeatherAlert | null> {
    return this.client.weatherAlertPOST(new WeatherAlertWebModel(model)).pipe(
      map(result => new WeatherAlert(result))
    );
  }

  public override get(id: number): Observable<WeatherAlert> {
    return this.client.weatherAlertGET(id).pipe(
      map(result => new WeatherAlert(result))
    );
  }

  public override getAll(): Observable<WeatherAlert[]> {
    return this.client.weatherAlertAll().pipe(
      map(results => results.map(result => new WeatherAlert(result)))
    );
  }

  public override getFormGuide(model: WeatherAlert, context?: FormGuideContext): Observable<undefined> {
    // Probably need to define new Guides/Directors on the backend when implementing this...
    throw new Error('Method not implemented.');
  }

  public override modify(id: number, model: WeatherAlert) : Observable<boolean> {
    this.client.weatherAlertPUT(id, new WeatherAlertWebModel(model));
    return of(true); // TODO: Status response
  }

  public override remove(id: number): Observable<boolean> {
    this.client.weatherAlertDELETE(id);
    return of(true); // TODO: Status response
  }
}