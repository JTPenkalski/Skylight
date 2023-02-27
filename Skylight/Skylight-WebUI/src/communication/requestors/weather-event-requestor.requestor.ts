import { BaseRequestor } from './index';
import { IWeatherEventRequestor } from 'core/requestors';
import { WeatherEvent } from 'core/models';

export class WeatherEventRequestor extends BaseRequestor<WeatherEvent> implements IWeatherEventRequestor {
  public override get controller(): string { return WeatherEvent.name; }
}
