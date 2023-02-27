import { BaseRequestor } from './index';
import { IWeatherRequestor } from 'core/requestors';
import { Weather } from 'core/models';

export class WeatherRequestor extends BaseRequestor<Weather> implements IWeatherRequestor {
  public override get controller(): string { return Weather.name; }
}
