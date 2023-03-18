import { Inject, Injectable } from '@angular/core';

import { BaseClient } from './index';
import { IWeatherClient } from 'core/clients';
import { IHttpProtocol } from 'core/protocols';
import { HttpProtocol } from 'presentation/protocols';
import { WeatherWebModel } from 'web/web-models';

@Injectable({
  providedIn: 'root'
})
export class WeatherClient extends BaseClient<WeatherWebModel> implements IWeatherClient {
  public override get controller(): string { return 'Weather'; }

  constructor(@Inject(HttpProtocol) client: IHttpProtocol<WeatherWebModel>) { 
    super(client);
  }
}
