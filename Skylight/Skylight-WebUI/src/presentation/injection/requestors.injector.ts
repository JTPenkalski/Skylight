import { InjectionToken, Provider } from '@angular/core';

import { IHttpControllerClient } from 'core/clients';
import { WeatherRequestor, WeatherEventRequestor } from 'communication/requestors';
import { HttpControllerClient } from 'presentation/services/clients';
import { IWeatherEventWebModel, IWeatherWebModel } from 'communication/web-models';

// TOKEN
export const WEATHER_REQUESTOR: InjectionToken<IWeatherWebModel> = new InjectionToken<IWeatherWebModel>('WEATHER_REQUESTOR');
export const WEATHER_EVENT_REQUESTOR: InjectionToken<IWeatherEventWebModel> = new InjectionToken<IWeatherEventWebModel>('WEATHER_EVENT_REQUESTOR');

// SERVICES
// See src/communication/requestors

// PROVIDER
export const REQUESTOR_PROVIDERS: Provider[] = [
  { provide: WEATHER_REQUESTOR, useFactory: (client: IHttpControllerClient<IWeatherWebModel>) => new WeatherRequestor(client), deps: [HttpControllerClient] },
  { provide: WEATHER_EVENT_REQUESTOR, useFactory: (client: IHttpControllerClient<IWeatherEventWebModel>) => new WeatherEventRequestor(client), deps: [HttpControllerClient] }
];
