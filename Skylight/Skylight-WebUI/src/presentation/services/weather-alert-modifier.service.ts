import { Inject, Injectable } from '@angular/core';
import { Observable, map, of } from 'rxjs';

import { IWeatherAlertModifierService } from 'core/services';
import { WeatherAlertModifier } from 'presentation/models';
import { FormGuideContext, IWeatherAlertModifierClient, WeatherAlertModifierClient, WeatherAlertModifier as WeatherAlertModifierWebModel } from 'web/clients';
import { BaseService } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherAlertModifierService extends BaseService<WeatherAlertModifier> implements IWeatherAlertModifierService {
  constructor(@Inject(WeatherAlertModifierClient) protected client: IWeatherAlertModifierClient) { super(); }

  public override add(model: WeatherAlertModifier): Observable<WeatherAlertModifier | null> {
    return this.client.weatherAlertModifierPOST(new WeatherAlertModifierWebModel(model)).pipe(
      map(result => new WeatherAlertModifier(result))
    );
  }

  public override get(id: number): Observable<WeatherAlertModifier> {
    return this.client.weatherAlertModifierGET(id).pipe(
      map(result => new WeatherAlertModifier(result))
    );
  }

  public override getAll(): Observable<WeatherAlertModifier[]> {
    return this.client.weatherAlertModifierAll().pipe(
      map(results => results.map(result => new WeatherAlertModifier(result)))
    );
  }

  public override getFormGuide(model: WeatherAlertModifier, context?: FormGuideContext): Observable<undefined> {
    // Probably need to define new Guides/Directors on the backend when implementing this...
    throw new Error('Method not implemented.');
  }

  public override modify(id: number, model: WeatherAlertModifier) : Observable<boolean> {
    this.client.weatherAlertModifierPUT(id, new WeatherAlertModifierWebModel(model));
    return of(true); // TODO: Status response
  }

  public override remove(id: number): Observable<boolean> {
    this.client.weatherAlertModifierDELETE(id);
    return of(true); // TODO: Status response
  }
}