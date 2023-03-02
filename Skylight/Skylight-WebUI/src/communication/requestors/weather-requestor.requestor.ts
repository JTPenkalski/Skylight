import { BaseRequestor } from './index';
import { IWeatherRequestor } from 'core/requestors';
import { IWeatherWebModel } from 'communication/web-models';

export class WeatherRequestor extends BaseRequestor<IWeatherWebModel> implements IWeatherRequestor {
  public override get controller(): string { return 'Weather'; }
}
