import { Inject, Injectable } from '@angular/core';

import { BaseService } from './index';
import { IWeatherEventService } from 'core/services';
import { IWeatherEventRequestor } from 'core/requestors';
import { WeatherEvent } from 'core/models';
import { WEATHER_EVENT_REQUESTOR } from 'presentation/injection';
import { IWeatherEventWebModel } from 'communication/web-models';

@Injectable()
export class WeatherEventService extends BaseService<IWeatherEventWebModel, WeatherEvent> implements IWeatherEventService {
  constructor(@Inject(WEATHER_EVENT_REQUESTOR) requestor: IWeatherEventRequestor) {
    super(requestor);
  }
}