import { AbstractControl } from '@angular/forms';

/**
 * Represents an actual FormControl within a FormGroup, associated with its declared name.
 **/
export interface IFormControlInstance {
  readonly name: string;
  readonly formControl: AbstractControl;
}
