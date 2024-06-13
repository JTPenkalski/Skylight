import { GetWeatherEventParticipantStatusResponse as WebWeatherEventParticipant, ParticipationMethod as WebParticipationMethod } from 'web/clients';
import { ParticipationMethod } from '.';

export class WeatherEventParticipantStatus {
  constructor(
    public participationMethod: ParticipationMethod,
    public participationDate: Date
  ) { }

  public static fromApi(data: WebWeatherEventParticipant): WeatherEventParticipantStatus {
    return new WeatherEventParticipantStatus(
      this.mapParticipationMethod(data.participationMethod),
      data.participationDate!,
    )
  }

  private static mapParticipationMethod(webParticipationMethod?: WebParticipationMethod): ParticipationMethod {
    switch (webParticipationMethod) {
      case WebParticipationMethod.Viewed: return ParticipationMethod.Reported;
      case WebParticipationMethod.Chased: return ParticipationMethod.Chased;
      default: return ParticipationMethod.Tracked;
    }
  }
}
