import { Inject, Injectable } from '@angular/core';
import { Observable, map, of } from 'rxjs';

import { IWeatherEventService } from 'core/services';
import { WeatherEvent } from 'presentation/models';
import { FormGuideContext, IWeatherEventClient, WeatherEventClient, WeatherEventFormGuide, WeatherEventFormGuideRequest, WeatherEvent as WeatherEventWebModel } from 'web/clients';
import { BaseService } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventService extends BaseService<WeatherEvent, WeatherEventFormGuide> implements IWeatherEventService {
  constructor(@Inject(WeatherEventClient) protected readonly client: IWeatherEventClient) { super(); }

  public override add(model: WeatherEvent): Observable<WeatherEvent | null> {
    return this.client.weatherEventPOST(new WeatherEventWebModel(model)).pipe(
      map(result => new WeatherEvent(result))
    );
  }

  public override get(id: number): Observable<WeatherEvent> {
    return this.client.weatherEventGET(id).pipe(
      map(result => new WeatherEvent(result))
    );
  }

  public override getAll(): Observable<WeatherEvent[]> {
    return this.client.weatherEventAll().pipe(
      map(results => results.map(result => new WeatherEvent(result)))
    );
  }

  public override getFormGuide(model: WeatherEvent, context?: FormGuideContext) : Observable<WeatherEventFormGuide> {
    return this.client.formGuidePOST(
      new WeatherEventFormGuideRequest({
        model: new WeatherEventWebModel(model),
        context: context ?? new FormGuideContext()
      })
    );
  }

  public override modify(id: number, model: WeatherEvent) : Observable<boolean> {
    this.client.weatherEventPUT(id, new WeatherEventWebModel(model));
    return of(true); // TODO: Status response
  }

  public override remove(id: number): Observable<boolean> {
    this.client.weatherEventDELETE(id);
    return of(true); // TODO: Status response
  }
}