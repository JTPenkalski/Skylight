import { Event } from 'shared/services/event-bus/event-bus.service';
import { NewWeatherEventAlert } from '../models';

export class WeatherAlertAddedEvent implements Event {
  constructor(public readonly alert: NewWeatherEventAlert) { }
}