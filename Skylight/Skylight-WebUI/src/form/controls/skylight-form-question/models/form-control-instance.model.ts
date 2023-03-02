import { AbstractControl } from '@angular/forms';

// TODO: Rename and rename file.

/**
 * Represents an actual FormControl within a FormGroup, associated with its declared name.
 **/
export interface IFormQuestionInstance {
  readonly name: string;
  readonly control: AbstractControl;
}
