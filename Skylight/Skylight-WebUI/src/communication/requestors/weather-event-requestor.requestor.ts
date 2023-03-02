import { BaseRequestor } from './index';
import { IWeatherEventRequestor } from 'core/requestors';
import { IWeatherEventWebModel } from 'communication/web-models';

export class WeatherEventRequestor extends BaseRequestor<IWeatherEventWebModel> implements IWeatherEventRequestor {
  public override get controller(): string { return 'WeatherEvent'; }
}
