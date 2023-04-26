import { AbstractControl } from '@angular/forms';

/**
 * Represents an actual AbstractControl within a FormGroup, associated with its declared name.
 **/
export interface IAbstractControlInstance {
  readonly name: string | number; // Name can be a name within a FormGroup or an index within a FormArray
  readonly control: AbstractControl;
}
