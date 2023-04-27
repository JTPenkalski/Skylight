import { Inject, Injectable } from '@angular/core';
import { map, of, Observable } from 'rxjs';

import { ISelectOption } from '../types/select-option';
import { IWeatherService, IWeatherAlertService, IWeatherAlertModifierService, IWeatherExperienceService } from 'core/services';
import { WeatherService, WeatherAlertService, WeatherAlertModifierService, WeatherExperienceService } from 'presentation/services';

/**
 * Retrieves options for a dropdown control from an endpoint on the server.
 **/
@Injectable()
export class SkylightServerOptionsService {
  constructor(
    @Inject(WeatherService) private weatherService: IWeatherService,
    @Inject(WeatherAlertService) private weatherAlertService: IWeatherAlertService,
    @Inject(WeatherAlertModifierService) private weatherAlertModifierService: IWeatherAlertModifierService,
    @Inject(WeatherExperienceService) private weatherExperienceService: IWeatherExperienceService
  ) { }

  /**
   * Makes a call to the server to get all values from the database for the specified endpoint.
   * @param controller The API Controller to call to retrieve values from the database.
   * @returns An Observable containing an array of all ISelectOptions from the database.
   **/
  public getOptions(controller: string): Observable<ISelectOption[]> {
    let values: Observable<any[]> = of([]);

    switch (controller.toUpperCase()) {
      case 'WEATHER':
        values = this.weatherService.getAll();
        break;
      case 'WEATHERALERT':
        values = this.weatherAlertService.getAll();
        break;
      case 'WEATHERALERTMODIFIER':
        values = this.weatherAlertModifierService.getAll();
        break;
      case 'WEATHEREXPERIENCE':
        values = this.weatherExperienceService.getAll();
        break;
    }
    
    return values.pipe(
      map(response => {
        return response.map(x => {
          return {
            name: x.name,
            value: x
          };
        });
      })
    );
  }
}
