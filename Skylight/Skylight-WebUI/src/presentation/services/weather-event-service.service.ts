import { Inject, Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';

import { IWeatherEventService } from 'core/services';
import { IWeatherEventClient } from 'core/clients';
import { WeatherEvent } from 'presentation/models';
import { WeatherEventClient } from 'web/clients';
import { WeatherEventWebMapper } from 'web/mappings';
import { WeatherEventWebModel } from 'web/web-models';
import { BaseService } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventService extends BaseService<WeatherEventWebModel, WeatherEvent> implements IWeatherEventService {
  constructor(
    @Inject(WeatherEventClient) client: IWeatherEventClient,
    mapper: WeatherEventWebMapper
  ) {
    super(client, mapper);
  }

  public add(model: WeatherEvent): Observable<WeatherEvent | null> {
    return this.client.post(this.mapper.toWebModel(model)).pipe(
      map(result => result.value ? this.mapper.toPresentationModel(result.value) : null)
    );
  }

  public get(id: number): Observable<WeatherEvent> {
    return this.client.get(id).pipe(
      map(result => this.mapper.toPresentationModel(result))
    );
  }

  public getAll(): Observable<WeatherEvent[]> {
    return this.client.getAll().pipe(
      map(results => results.map(result => this.mapper.toPresentationModel(result)))
    );
  }

  public modify(id: number, model: WeatherEvent) : Observable<boolean> {
    throw new Error('Not implemented.');
  }

  public remove(id: number): Observable<boolean> {
    throw new Error('Not implemented.');
  }
}