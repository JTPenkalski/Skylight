import { Inject, Injectable } from '@angular/core';

import { BaseClient } from './index';
import { IWeatherEventClient } from 'core/clients';
import { IHttpProtocol } from 'core/protocols';
import { HttpProtocol } from 'presentation/protocols';
import { WeatherEventWebModel } from 'web/web-models';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventClient extends BaseClient<WeatherEventWebModel> implements IWeatherEventClient {
  public override get controller(): string { return 'WeatherEvent'; }

  constructor(@Inject(HttpProtocol) client: IHttpProtocol<WeatherEventWebModel>) { 
    super(client);
  }
}
