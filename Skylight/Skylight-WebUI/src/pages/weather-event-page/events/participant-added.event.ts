import { Event } from 'shared/services/event-bus/event-bus.service';

export class ParticipantAddedEvent implements Event {
  constructor(public readonly stormTrackerId: string) { }
}