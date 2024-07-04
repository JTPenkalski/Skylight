import { WeatherEventParticipant as WebWeatherEventParticipant } from 'web/clients';
import { ParticipationMethod, mapParticipationMethod } from '.';

export class WeatherEventParticipant {
  constructor(
    public firstName: string,
    public lastName: string,
    public participationMethod: ParticipationMethod,
    public participationDate: Date,
  ) {}

  public static fromApi(data: WebWeatherEventParticipant): WeatherEventParticipant {
    return new WeatherEventParticipant(
      data.firstName!,
      data.lastName!,
      mapParticipationMethod(data.participationMethod),
      data.participationDate!,
    );
  }
}
