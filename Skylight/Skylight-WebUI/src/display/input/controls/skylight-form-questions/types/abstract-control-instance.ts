import { AbstractControl } from '@angular/forms';

/**
 * Represents an actual AbstractControl within a FormGroup, associated with its declared name.
 **/
export interface IAbstractControlInstance {
  readonly name: string | number;
  readonly control: AbstractControl;
}
