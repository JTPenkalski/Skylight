import { GetWeatherEventParticipantStatusResponse as WebWeatherEventParticipant } from 'web/clients';
import { ParticipationMethod, mapParticipationMethod } from '.';

export class WeatherEventParticipantStatus {
  constructor(
    public participationMethod: ParticipationMethod,
    public participationDate: Date,
  ) {}

  public static fromApi(
    data: WebWeatherEventParticipant,
  ): WeatherEventParticipantStatus {
    return new WeatherEventParticipantStatus(
      mapParticipationMethod(data.participationMethod),
      data.participationDate!,
    );
  }
}
