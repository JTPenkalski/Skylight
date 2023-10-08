import { EventEmitter } from '@angular/core';

/**
 * A set of properties that all custom Skylight form components must have.
 **/
export interface ISkylightFormComponent {
  label: string;
  formGuideRequested: EventEmitter<undefined>;

  /**
   * Emits an event to parents that this control has been modified.
   * A new Form Guide may need to be fetched to ensure the form remains in a valid state.
   */
  requestFormGuide(): void;
}