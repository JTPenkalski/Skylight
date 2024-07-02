import { Event } from 'shared/services/event-bus/event-bus.service';
import { WeatherEventAlert } from '../models';

export class WeatherAlertAddedEvent implements Event {
  constructor(public readonly alert: WeatherEventAlert) {}
}
