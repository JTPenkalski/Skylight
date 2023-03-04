import { InjectionToken, Provider } from '@angular/core';

import { IHttpProtocol } from 'core/protocols';
import { HttpProtocol } from 'presentation/protocols';

import { IWeatherEventClient, IWeatherClient } from 'core/clients';
import { WeatherClient, WeatherEventClient } from 'web/clients';

import { WeatherEventWebModel, WeatherWebModel } from 'web/web-models';

// TOKENS
export const WEATHER_REQUESTOR = new InjectionToken<IWeatherClient>('WEATHER_REQUESTOR');
export const WEATHER_EVENT_REQUESTOR = new InjectionToken<IWeatherEventClient>('WEATHER_EVENT_REQUESTOR');

// SERVICES
// See src/web/requestors

// PROVIDERS
export const REQUESTOR_PROVIDERS: Provider[] = [
  { provide: WEATHER_REQUESTOR, useFactory: (client: IHttpProtocol<WeatherWebModel>) => new WeatherClient(client), deps: [HttpProtocol] },
  { provide: WEATHER_EVENT_REQUESTOR, useFactory: (client: IHttpProtocol<WeatherEventWebModel>) => new WeatherEventClient(client), deps: [HttpProtocol] }
];
