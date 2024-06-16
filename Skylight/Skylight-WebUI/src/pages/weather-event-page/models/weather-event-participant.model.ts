import { WeatherEventParticipant as WebWeatherEventParticipant, ParticipationMethod as WebParticipationMethod } from 'web/clients';
import { ParticipationMethod } from '.';

export class WeatherEventParticipant {
  constructor(
    public firstName: string,
    public lastName: string,
    public participationMethod: ParticipationMethod,
    public participationDate: Date
  ) { }

  public static fromApi(data: WebWeatherEventParticipant): WeatherEventParticipant {
    return new WeatherEventParticipant(
      data.firstName!,
      data.lastName!,
      this.mapParticipationMethod(data.participationMethod),
      data.participationDate!
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