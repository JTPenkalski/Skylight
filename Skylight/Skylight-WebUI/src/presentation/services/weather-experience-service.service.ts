import { Inject, Injectable } from '@angular/core';
import { Observable, map, of } from 'rxjs';

import { IWeatherExperienceService } from 'core/services';
import { WeatherExperience } from 'presentation/models';
import { FormGuideContext, IWeatherExperienceClient, WeatherExperienceClient, WeatherExperience as WeatherExperienceWebModel } from 'web/clients';
import { BaseService } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherExperienceService extends BaseService<WeatherExperience> implements IWeatherExperienceService {
  constructor(@Inject(WeatherExperienceClient) protected client: IWeatherExperienceClient) { super(); }

  public override add(model: WeatherExperience): Observable<WeatherExperience | null> {
    return this.client.weatherExperiencePOST(new WeatherExperienceWebModel(model)).pipe(
      map(result => new WeatherExperience(result))
    );
  }

  public override get(id: number): Observable<WeatherExperience> {
    return this.client.weatherExperienceGET(id).pipe(
      map(result => new WeatherExperience(result))
    );
  }

  public override getAll(): Observable<WeatherExperience[]> {
    return this.client.weatherExperienceAll().pipe(
      map(results => results.map(result => new WeatherExperience(result)))
    );
  }

  public override getFormGuide(model: WeatherExperience, context?: FormGuideContext): Observable<undefined> {
    // Probably need to define new Guides/Directors on the backend when implementing this...
    throw new Error('Method not implemented.');
  }

  public override modify(id: number, model: WeatherExperience) : Observable<boolean> {
    this.client.weatherExperiencePUT(id, new WeatherExperienceWebModel(model));
    return of(true); // TODO: Status response
  }

  public override remove(id: number): Observable<boolean> {
    this.client.weatherExperienceDELETE(id);
    return of(true); // TODO: Status response
  }
}