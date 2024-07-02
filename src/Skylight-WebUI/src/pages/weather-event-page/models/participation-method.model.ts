import { ParticipationMethod as WebParticipationMethod } from 'web/clients';

export enum ParticipationMethod {
  None = 'None',
  Tracked = 'Tracked',
  Reported = 'Reported',
  Chased = 'Chased',
}

export function mapParticipationMethod(
  webParticipationMethod?: WebParticipationMethod,
): ParticipationMethod {
  switch (webParticipationMethod) {
    case WebParticipationMethod.None:
      return ParticipationMethod.None;
    case WebParticipationMethod.Viewed:
      return ParticipationMethod.Reported;
    case WebParticipationMethod.Chased:
      return ParticipationMethod.Chased;
    default:
      return ParticipationMethod.Tracked;
  }
}
