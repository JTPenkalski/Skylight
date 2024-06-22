import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject, filter } from 'rxjs';
import { Constructor } from 'shared/models';

/**
 * An abstract event that a component may emit.
 */
export interface Event { }

/**
 * Global event emitter for communicating between components.
 */
@Injectable({
  providedIn: 'root'
})
export class EventBusService {
  private readonly subject: Subject<Event> = new BehaviorSubject<Event>({});

  /**
   * Emits a global event for all handlers to respond to.
   * @param event The event to emit.
   */
  public emit<T extends Event>(event: T): void {
    this.subject.next(event);
  }

  /**
   * Allows for registering a handler for a specific type of event.
   * @param event The type of event to respond to.
   * @returns The Observable to subscribe a callback to.
   */
  public handle<T extends Event>(event: Constructor<T>): Observable<T> {
    return <Observable<T>>this.subject.asObservable().pipe(
      filter(e => e instanceof event)
    );
  }
}
