import { InjectionToken, Provider } from '@angular/core';
import { Weather } from 'core/models';
import { IHttpControllerClient } from 'core/services';
import { WeatherRequestor } from 'communication/requestors';
import { HttpControllerClient } from 'presentation/services/http-controller-client.service';

export const WEATHER_REQUESTOR: InjectionToken<Weather> = new InjectionToken<Weather>('WEATHER_REQUESTOR');

export const REQUESTORS: Provider[] = [
  { provide: WEATHER_REQUESTOR, useFactory: (client: IHttpControllerClient<Weather>) => new WeatherRequestor(client), deps: [HttpControllerClient] }
];
