import { Inject, Injectable } from '@angular/core';
import { map, of, Observable } from 'rxjs';

import { environment } from 'core/environments/environment';
import { ISelectOption } from '../types/select-option';
import { IWeatherService } from 'core/services';
import { WeatherService } from 'presentation/services/weather-service.service';

/**
 * Retrieves options for a dropdown control from an endpoint on the server.
 **/
@Injectable()
export class SkylightServerOptionsService {
  private readonly url: string;

  constructor(
    @Inject(WeatherService) private weatherService: IWeatherService
  ) {
    this.url = `${environment.apiUrl}/${environment.apiVersion}/`;
  }

  /**
   * Makes a call to the server to get all values from the database for the specified endpoint.
   * @param controller The API Controller to call to retrieve values from the database.
   * @returns An Observable containing an array of all items from the database.
   **/
  public getOptions(controller: string): Observable<ISelectOption[]> {
    let values: Observable<any[]> = of([]);

    switch (controller.toUpperCase()) {
      case 'WEATHER':
        values = this.weatherService.getAll();
        break;
    }
    
    return values.pipe(
      map(response => {
        return response.map(x => {
          console.log({
            name: x.name,
            value: x
          });
          return {
            name: x.name,
            value: x
          };
        });
      })
    );
  }
}
