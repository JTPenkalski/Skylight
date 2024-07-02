import { Event } from 'shared/services/event-bus/event-bus.service';

export class ParticipantRemovedEvent implements Event {
  constructor(public readonly stormTrackerId: string) {}
}
