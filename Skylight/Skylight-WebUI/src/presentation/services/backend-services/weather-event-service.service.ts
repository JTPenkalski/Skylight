import { Inject, Injectable } from '@angular/core';

import { BaseService } from './index';
import { IWeatherEventService } from 'core/services';
import { IWeatherEventRequestor } from 'core/requestors';
import { WeatherEvent } from 'core/models';
import { WEATHER_EVENT_REQUESTOR } from 'presentation/injection';
import { Observable } from 'rxjs';

@Injectable()
export class WeatherEventService extends BaseService<WeatherEvent> implements IWeatherEventService {
  constructor(@Inject(WEATHER_EVENT_REQUESTOR) requestor: IWeatherEventRequestor) {
    super(requestor);
  }

  public override add(model: WeatherEvent): Observable<WeatherEvent | null>
  {
    console.log('Hello there!');
    throw new Error('This is expected.');
  }
}